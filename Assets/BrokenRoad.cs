using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenRoad : MonoBehaviour
{
    public bool broken;
    public ParticleSystem dust;

    private void Awake()
    {
        broken = false;
        dust.Stop();
    }
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (!broken)
        {
            transform.GetChild(0).GetComponent<MeshRenderer>().enabled = true;
            transform.GetChild(1).GetComponent<MeshRenderer>().enabled = false;
            gameObject.tag = "yol";
        }
        else
        {
            transform.GetChild(0).GetComponent<MeshRenderer>().enabled = false;
            transform.GetChild(1).GetComponent<MeshRenderer>().enabled = true;
            gameObject.tag = "brokenroad";
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
        if((other.gameObject.tag == "Car" || other.gameObject.name == "buldozer") && broken == false)
        {
            Invoke("Break", 0.5f);
        }

        
    }
    void Break()
    {
        broken = true;
        dust.Play();
    }
}

