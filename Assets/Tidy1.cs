using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tidy1 : MonoBehaviour
{

    private bool ObjInHand = false;
    public Transform pivotPos;
    public List<GameObject> ObjectsInHand;
    public float radius = 2f;
        
    private bool handsFree = true;
    private bool keyIsDown = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        GameObject tMin = null;
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("freePile"))
        {
            float distance = Vector3.Distance(obj.transform.position, currentPos);
            if (distance < minDist)
            {
                tMin = obj;
                minDist = distance;
            }

        }
        //print(minDist);
        if (Input.GetButton("Fire1"))
        {
            if (keyIsDown == false)
            {
                keyIsDown = true;
                if (handsFree)
                {

                    if (minDist < radius)
                    {
                        print("free hands");
                        handsFree = false;
                        List<GameObject> l = new List<GameObject>();
                        l.Add(tMin);
                        pile p = GetComponentInChildren<pile>();
                        p.add(l);
                        print(l);
                    }
                }
                else
                {
                    print("full hands");
                    GameObject mypile = GameObject.Find("pile");
                    mypile.transform.parent = null;
                    handsFree = true;

                }
            }

        }
        else
        {
            keyIsDown = false;
        }
    }

    private static void NewMethod()
    {
        print("onnnn");
    }
}
