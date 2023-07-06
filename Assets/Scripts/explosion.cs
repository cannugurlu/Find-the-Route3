using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class explosion : MonoBehaviour
{
    public ParticleSystem boom;
    [SerializeField] private AudioSource audioSource;

    private void Awake()
    {
        audioSource=GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Car")
        {
            Patlama(collision.gameObject);
            StartCoroutine(patlamaDurdur());
            audioSource.Play();
        }
    }




    void Patlama(GameObject car)
    {
        boom.transform.position = car.transform.position;
        boom.Play();
        Destroy(car);
    }

    IEnumerator patlamaDurdur()
    {
        yield return new WaitForSeconds(0.6f);

        boom.Stop();
    }
}
