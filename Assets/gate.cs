using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gate : MonoBehaviour
{
    string[] colors;
    //string[] colors= { "B02325", "0E11CF", "FFF02C", "FF4900" };
    Renderer renderer;
    int a;
    int i = 1;
    private void Start()
    {
        renderer = gameObject.GetComponent<Renderer>();
        
        if (SceneManager.GetActiveScene().buildIndex == 12)
        {
            colors = new string[] { "B02325", "0E11CF" };
        }
        else if (SceneManager.GetActiveScene().buildIndex == 13)
        {
            colors = new string[] { "B02325", "0E11CF", "FF4900" };
        }
        else if (SceneManager.GetActiveScene().buildIndex == 14)
        {
            colors = new string[] { "FFF02C", "0E11CF" };
        }


        UnityEngine.Color color;
        if (ColorUtility.TryParseHtmlString("#" + colors[0], out color))
        {
            color.a = 0.5f;
            renderer.material.color = color;
        }
    }
      

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Rigidbody>().velocity != Vector3.zero)
        {
            StartCoroutine(ChangeColor());
        }
        
       
    }

    IEnumerator ChangeColor()
    {
        yield return new WaitForSeconds(0.1f);
        if (i == colors.Length)
        {
            i = 0;
        }
        UnityEngine.Color color;
        if (ColorUtility.TryParseHtmlString("#" + colors[i], out color))
        {
            color.a = 0.5f;
            renderer.material.color = color;
        }
        i++;

    }

   
}
