using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{

    private GameObject p1;
    private GameObject p2;
    private Vector3 cur;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        p1 = GameObject.FindGameObjectWithTag("P1");
        p2 = GameObject.FindGameObjectWithTag("P2");
        cur = this.transform.position;
        print(p1.transform.position);
        this.transform.position = (p1.transform.position + p2.transform.position) / 2;



    }
}
