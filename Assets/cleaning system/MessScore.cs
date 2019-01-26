using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MessScore : MonoBehaviour
{
    public bool reverse = true;
    public Slider slider;

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
        float maxSquer = 0;
        foreach(GameObject obj in GameObject.FindGameObjectsWithTag("freeObj"))
        {
            maxSquer += obj.GetComponent<Collider>().bounds.size.x* obj.GetComponent<Collider>().bounds.size.z;
        }

        RenderTexture.active = dirtTex;
        tex.ReadPixels(new Rect(0, 0, tex.width, tex.height), 0, 0);
        for(int i = 0; i < tex.width; i++){
            for(int j = 0; j < tex.height; j++){
                if(tex.GetPixel(i,j).r>0){
                    score++;
                }
            }
        }
        
        score = score/maxSquer*100f;
        print(maxSquer);
        //print(score);
    }
    void OnGUI()
    {
        if(slider){
            slider.value = (score - minScore) / maxScore;
            if(reverse){
                slider.value = 1 - slider.value;
            }
        }
    }
}
