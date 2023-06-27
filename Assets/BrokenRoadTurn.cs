using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenRoadTurn : MonoBehaviour
{

    bool broken;
    void Start()
    {
        broken = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!broken)
        {
            transform.GetChild(3).GetComponent<MeshRenderer>().enabled = true;
            
        }
        else
        {
            transform.GetChild(3).GetComponent<MeshRenderer>().enabled = false;
            transform.GetChild(4).GetComponent<MeshRenderer>().enabled = true;
            transform.GetChild(0).gameObject.tag = "brokenroad";
            transform.GetChild(1).gameObject.tag = "brokenroad";
        }
    }
    /*private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Car")
        {
            broken = true;
        }
    }*/
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Car")
        {
            Invoke("Break", 0.66f);
        }
    }
    void Break()
    {
        broken = true;
    }
}
