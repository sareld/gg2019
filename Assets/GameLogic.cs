using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour

{
    
    private Scene level;
    [SerializeField] private float timer;
    [SerializeField] private Text uiText;
    private bool canCount = true;
    public float timeInit = 10f;
    // Start is called before the first frame update
    void Start()
    {

        

    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0f && canCount)
        {
            timer -= Time.deltaTime;
            uiText.text = timer.ToString("f");

        }
        

        if (timer < 0)
        {
            timer = 0;
            SceneManager.LoadScene("clean experiment");
            timer = timeInit;
        }
        
    }
}
