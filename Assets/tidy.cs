using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tidy : MonoBehaviour
{


    public AudioClip drop;
    public AudioClip pickup;

    private bool ObjInHand = false;
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
        float minDistObj = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        GameObject minObj = null;
        bool isPile = false;


        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("freeObj"))
        {
            float distance = Vector3.Distance(obj.transform.position, currentPos);
            if (obj.GetComponentInParent<pile>() != this.GetComponentInChildren<pile>())
            {
                if (distance < minDistObj)
                {
                    minObj = obj;
                    minDistObj = distance;
                }
            }
        }



        pile parent_pile = minObj.GetComponentInParent<pile>();
        if (parent_pile != null)
        {
            isPile = true;
            minObj = parent_pile.gameObject;
        }


        //print(minDist);
        
        if (Input.GetButton("Fire1"))
        {
            if (keyIsDown == false)
            {
                keyIsDown = true;
                if (minDistObj < radius)
                {
                    print("close to");
                    if (!isPile)
                    {
                        pile myPile = GetComponentInChildren<pile>();
                        print("object");
                        handsFree = false;
                        List<GameObject> l = new List<GameObject>();
                        l.Add(minObj);
                        myPile.add(l);
                    }
                    else
                    {
                        pile myPile = GetComponentInChildren<pile>();
                        pile otherPile = minObj.GetComponent<pile>();
                        if (handsFree)
                        {
                            handsFree = false;
                            myPile.add(otherPile.objects);
                            Destroy(otherPile.gameObject);
                        }
                        else
                        {
                            otherPile.add(myPile.objects);
                            myPile.clear();
                            handsFree = true;
                        }
                        //print("full hands");
                        //GameObject mypile = GameObject.Find("pile");
                        //mypile.transform.parent = null;
                        //handsFree = true;
                    }
                }
                else if (!handsFree)
                {
                    pile myPile = GetComponentInChildren<pile>();
                    print("Not close to");
                    GameObject newPile = Instantiate(myPile.gameObject, this.transform);
                    newPile.GetComponent<pile>().clear();
                    newPile.name = "pile";
                    newPile.transform.parent = this.transform;
                    myPile.gameObject.transform.parent = null;

                    pile p = GetComponentInChildren<pile>();
                    p.clear();
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
