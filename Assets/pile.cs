using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pile : MonoBehaviour
{
    public List<GameObject> objects;
    public GameObject o;
    // Start is called before the first frame update
    void Start()
    {


    }

    public void add(List<GameObject> adds)
    {
        objects.AddRange(adds);

        objects[0].transform.position = this.transform.position;
        objects[0].transform.parent = this.transform;
        objects[0].tag = "handPile";

        for (int i = 1; i<objects.Count;i++)
        {
            float y = (objects[i - 1].transform.position.y - this.transform.position.y) + objects[i-1].GetComponent<Collider>().bounds.size.y;
            objects[i].transform.position = this.transform.position + new Vector3(0, y, 0);
            objects[i].transform.parent = this.transform;
            objects[i].tag = "";
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
