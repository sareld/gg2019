using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TidyController : MonoBehaviour
{
    public float speed = 6.0f;
    public Transform pos;
    public float gravity = 20.0f;
    [Range(0, 1)]
    
    public float turnSpeed = 0.1f;
    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;
    
    private bool ObjInHand = false;
    public List<GameObject> ObjectsInHand;


    void Start()
    {
        controller = GetComponent<CharacterController>();

    }

    void Update()
    {
        if (controller.isGrounded)
        {
            // We are grounded, so recalculate
            // move direction directly from axes

            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection = moveDirection * speed;
            if (Input.GetButton("Fire1"))
            {
                for (int i = 0; i < ObjectsInHand.Capacity; i++)
                {
                    ObjectsInHand[i].GetComponent<Rigidbody>().isKinematic = false;
                    ObjectsInHand[i].transform.position = pos.position;

                }

            }





        }

        // Apply gravity
        moveDirection.y = moveDirection.y - (gravity * Time.deltaTime);

        // Move the controller
        controller.Move(moveDirection * Time.deltaTime);

    }

    private void FixedUpdate()
    {
        if (controller.isGrounded)
        {
            Vector3 f = Vector3.Lerp(transform.forward, -moveDirection.normalized, turnSpeed);
            f.y = 0;
            transform.forward = f;
            
        }
    }
    private void Get()

    {

            
    }
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Obj"))
        {
            ObjectsInHand.Add(collision.gameObject);
            print("s");
            print("s");
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obj"))
        {
            //ObjectsInHand.Contains
        }
    }

}
