using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveManager : MonoBehaviour
{
    public float velocity = 10.0f;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit raycast;

        if (Physics.Raycast(this.transform.position, transform.TransformDirection(Vector3.forward), out raycast))
        {
            Debug.DrawRay(this.transform.position, transform.TransformDirection(Vector3.forward) * raycast.distance, Color.green);
            if (raycast.distance>0 && raycast.distance < 3.0f)
            {
                    this.gameObject.GetComponent<Rigidbody>().velocity = velocity * transform.forward * Time.deltaTime;
            }
        }
        if (raycast.distance == 0.0f)
        {
            print("önünde bir þey yok");
            this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            horizontalRaycast();
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "GameController")
        {
            Destroy(other.gameObject);
        }
    }

    void horizontalRaycast()
    {
        print("sað sol taranýyor");
        RaycastHit horizontalRaycast;
        if (Physics.Raycast(transform.position, transform.TransformDirection(-transform.right), out horizontalRaycast))
        {
            if (horizontalRaycast.distance > 0)
            {
                turnRight();
            }
        }
        if (Physics.Raycast(transform.position, transform.TransformDirection(transform.right), out horizontalRaycast))
        {
            if (horizontalRaycast.distance > 0)
            {
                turnLeft();
            }
        }
    }
    void turnRight()
    {
        Quaternion targetRotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y + 90.0f, transform.rotation.z);
        transform.rotation = targetRotation;
    }
    void turnLeft()
    {
        Quaternion targetRotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y - 90.0f, transform.rotation.z);
        transform.rotation = targetRotation;
    }
}
