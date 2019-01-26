using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessScore : MonoBehaviour
{
    public RenderTexture dirtTex;
    public Texture2D tex;
    public float score;

    public float minScore = 6553;
    public float maxScore = 65536;
    private void Awake()
    {
        tex = new Texture2D(dirtTex.width,dirtTex.height, TextureFormat.RGB24, false);
    }
    private void Update()
    {
        score = 0;
        RenderTexture.active = dirtTex;
        tex.ReadPixels(new Rect(0, 0, tex.width, tex.height), 0, 0);
        for(int i = 0; i < tex.width; i++){
            for(int j = 0; j < tex.height; j++){
                if(tex.GetPixel(i,j).r>0){
                    score++;
                }
            }
        }
        score = score;
    }
    public GUIStyle style;
    void OnGUI()
    {
        int percent = Mathf.RoundToInt((Mathf.Clamp01((score - minScore) / maxScore) * 100));
        GUI.Label(new Rect(10, 30, 100, 50),"mess % "+ percent.ToString(), style);
    }
}
