using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public Rigidbody cloud;
    float time = 50;
    float duration = 0;
    
    
    void Start()
    {
        duration = Time.time + 10f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > duration)
        {
            float randZ = Random.Range(-1f, +1f);
            Vector3 randomPos = new Vector3(transform.position.x+randZ, transform.position.y+randZ, transform.position.z + randZ);
            duration = Time.time + time;
            //Rigidbody cloudInstance;
            Instantiate(cloud, randomPos, cloud.rotation);
            //cloudInstance.velocity = new Vector3(-0.5f, 0, 0);
        }
        
        
    }
}
