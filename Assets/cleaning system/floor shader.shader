﻿Shader "Custom/NewSurfaceShader"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Floor (RGB)", 2D) = "white" {}
        _DirtTex ("Dirt (RGB)", 2D) = "white" {}
        _MaskTex ("MASK (R)", 2D) = "white" {}
        _SpecularTex ("_SpecMap (RGB)", 2D) = "white" {}
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;
        sampler2D _DirtTex;
        sampler2D _MaskTex;
        sampler2D _SpecularTex;
        struct Input
        {
            float2 uv_MainTex;
            float2 uv_DirtTex;
            float2 uv_MaskTex;
            float2 uv_SpecularTex;
        };

        half _Glossiness;
        half _Metallic;
        fixed4 _Color;

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            // Albedo comes from a texture tinted by color
            fixed4 mask = tex2D (_MaskTex, IN.uv_MaskTex);
            fixed4 main = tex2D (_MainTex, IN.uv_MainTex);
            fixed4 dirt = (float4(1,1,1,1) * (1-mask.r)) + (tex2D (_DirtTex, IN.uv_DirtTex) * mask.r);
            fixed4 c = main * dirt * _Color;
            o.Albedo = c.rgb;
            // Metallic and smoothness come from slider variables
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness * tex2D (_SpecularTex, IN.uv_SpecularTex).r;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
