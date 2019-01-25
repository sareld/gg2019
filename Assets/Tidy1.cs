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
        float minDistPile = Mathf.Infinity;
        float minDist = Mathf.Infinity;
        float minDistObj = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        GameObject minPile = null;
        GameObject minObj = null;
        bool isPile = false;

        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("freePile"))
        {
            float distance = Vector3.Distance(obj.transform.position, currentPos);
            if (distance < minDistPile)
            {
                minPile = obj;
                minDistPile = distance;
            }
        }

        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("freeObj"))
        {
            float distance = Vector3.Distance(obj.transform.position, currentPos);
            if (distance < minDistObj)
            {
                minObj = obj;
                minDistObj = distance;
            }
        }

        if (minDistObj < minDistPile)
        {
            isPile = false;
            minDist = minDistObj;
        }
        else
        {
            isPile = true;
            minDist = minDistPile;
        }

        //print(minDist);
        if (Input.GetButton("Fire1"))
        {
            if (keyIsDown == false)
            {
                print("fire!");
                keyIsDown = true;
                if (!isPile)
                {
                    print("object");
                    if (minDist < radius)
                    {
                        print("free hands");
                        handsFree = false;
                        List<GameObject> l = new List<GameObject>();
                        l.Add(minObj);
                        pile p = GetComponentInChildren<pile>();
                        p.add(l);
                        print(l);
                    }
                    else if (!handsFree)
                    {
                        GameObject mypile = GameObject.Find("pile");
                        GameObject newPile = Instantiate(mypile, this.transform);
                        newPile.name = "pile";
                        newPile.transform.parent = this.transform;
                        mypile.transform.parent = null;

                        pile p = GetComponentInChildren<pile>();
                        p.clear();
                        handsFree = true;

                    }

                }
                else
                {
                    //print("full hands");
                    //GameObject mypile = GameObject.Find("pile");
                    //mypile.transform.parent = null;
                    //handsFree = true;
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
