using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clean : MonoBehaviour
{
    public float radius = 2f;
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

                if (distance < minDistObj)
                {
                    minObj = obj;
                    minDistObj = distance;
                }

        }

        //print(minDistObj);
        if (minDistObj < radius)
        {
            pile parent_pile = minObj.GetComponentInParent<pile>();
            if (parent_pile != null && parent_pile.gameObject.transform.parent == null)
            {
                isPile = true;
                minObj = parent_pile.gameObject;
                parent_pile.break_pile();
            }
        }


    }
}
