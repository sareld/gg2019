using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
    
    private Scene level;
    [SerializeField] private float timer;
    public Text uiText;
    public bool canCount = true;
    public float timeInit = 10f;
    // Start is called before the first frame update
    void Start()
    {
        //canCount = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0f && canCount)
        {
            timer -= Time.deltaTime;

            int minutes = Mathf.RoundToInt(Mathf.Floor(timer / 60));
            int seconds = Mathf.RoundToInt(timer%60);

            uiText.text = minutes.ToString()+":"+seconds.ToString();    
        }
        

        if (timer < 0)
        {
            uiText.text = "TimeOut!!!";
            //timer = 0;
            //SceneManager.LoadScene("main");
            //timer = timeInit;
        }
        
    }
}
