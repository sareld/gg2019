using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pile : MonoBehaviour
{
    public List<GameObject> objects;
    public GameObject o;
    public Transform floor;
    // Start is called before the first frame update
    void Start()
    {


    }

    public void clear()
    {
        objects.Clear();
        foreach (Transform child in this.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }

    public void break_pile()
    {
        foreach(GameObject obj in objects)
        {
            obj.GetComponent<Rigidbody>().isKinematic = false;
            obj.transform.parent = null;
        }
        Destroy(this);
    }

    public void add(List<GameObject> adds)
    {
        objects.AddRange(adds);
        for (int i = 0; i<objects.Count;i++)
        {
            if (i == 0)
            {
                objects[0].transform.position = this.transform.position;
                objects[0].transform.parent = this.transform;
                objects[0].GetComponent<Rigidbody>().isKinematic = true;
            }
            else
            {
                float y = (objects[i - 1].transform.position.y - this.transform.position.y) + objects[i - 1].GetComponent<Collider>().bounds.size.y;
                objects[i].transform.position = this.transform.position + new Vector3(0, y, 0);
                objects[i].transform.parent = this.transform;
                objects[i].GetComponent<Rigidbody>().isKinematic = true;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.parent == null && objects.Count>0)
        {

            Vector3 position = transform.position;
            position.y = floor.position.y + objects[0].GetComponent<Collider>().bounds.size.y/2;
            transform.position = position;
        }
    }
}
