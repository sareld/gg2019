using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
  
    public Transform lookAt;
    private GameObject p1;
    private float dist;
    public float rot = 0.02f;

    private float camDist;

    // Start is called before the first frame update
    void Start()
    {
        
        

    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(lookAt);
        p1 = GameObject.FindGameObjectWithTag("P1");
        dist = Vector3.Distance(lookAt.position, p1.transform.position);
        camDist = Vector3.Distance(lookAt.position, this.transform.position);

        print(dist);
        if (dist < 3  && camDist > 12)
        {
            
            transform.Translate(new Vector3( - rot, 0, 1) * Time.deltaTime);

        }
        if (dist > 6 && camDist < 17)
        {
            
            transform.Translate(new Vector3 (rot, 0,- 1) * Time.deltaTime);

        }
   



    }

    
}
