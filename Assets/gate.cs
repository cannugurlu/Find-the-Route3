using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gate : MonoBehaviour
{
    string[] colors;
    //string[] colors= { "B02325", "0E11CF", "FFF02C", "FF4900" };
    Renderer renderer;
    Renderer renderer2;
    GameObject stick;
    int a;
    int i = 1;
    private void Start()
    {
        renderer = gameObject.transform.GetChild(0).GetComponent<Renderer>();
        renderer2 = gameObject.transform.GetChild(1).GetComponent<Renderer>();
        stick = gameObject.transform.GetChild(1).gameObject;
        print(stick.transform.rotation.eulerAngles);


        if (SceneManager.GetActiveScene().buildIndex == 12)
        {
            colors = new string[] { "B02325", "0E11CF" };
        }
        else if (SceneManager.GetActiveScene().buildIndex == 13)
        {
            colors = new string[] { "B02325", "0E11CF", "FF5100" };
        }
        else if (SceneManager.GetActiveScene().buildIndex == 14)
        {
            colors = new string[] { "FFF02C", "0E11CF" };
        }
        else if (SceneManager.GetActiveScene().buildIndex == 17)
        {
            colors = new string[] { "B02325", "0E11CF", "FF5100" };
        }
        else if (SceneManager.GetActiveScene().buildIndex == 18)
        {
            colors = new string[] { "0E11CF", "FFF02C",  };
        }

        UnityEngine.Color color;
        if (UnityEngine.ColorUtility.TryParseHtmlString("#" + colors[0], out color))
        {
            color.a = 0.5f;
            renderer.material.color = color;
            renderer2.material.color = color;

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        UnityEngine.Color vehicleColor = UnityEngine.Color.black;
        if(other.gameObject.name == "buldozer")
        {
            vehicleColor = new UnityEngine.Color(1f, 0.94f, 0.17f);
        }
        if (other.gameObject.tag == "Car")
        {
            vehicleColor = other.transform.GetChild(1).GetComponent<MeshRenderer>().material.color;
        }

        if (ColorsApproximatelyEqual(vehicleColor, renderer.material.color, 0.1f))
        {
            print("buldozer geldi");

            StartCoroutine(RotateChildObject(stick.transform, new Vector3(135, stick.transform.rotation.eulerAngles.y, stick.transform.rotation.eulerAngles.z), 0.2f));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Rigidbody>().velocity != Vector3.zero)
        {
            StartCoroutine(ChangeColor());
            StartCoroutine(RotateChildObject(stick.transform, new Vector3(90, stick.transform.rotation.eulerAngles.y, stick.transform.rotation.eulerAngles.z), 0.2f));


        }


    }

    IEnumerator ChangeColor()
    {
        yield return new WaitForSeconds(0.05f);
        if (i == colors.Length)
        {
            i = 0;
        }
        UnityEngine.Color color;
        if (UnityEngine.ColorUtility.TryParseHtmlString("#" + colors[i], out color))
        {
            color.a = 0.5f;
            renderer.material.color = color;
            renderer2.material.color = color;
        }
        i++;

    }

    IEnumerator RotateChildObject(Transform childTransform, Vector3 targetEulerAngles, float duration)
    {
        Vector3 startEulerAngles = childTransform.eulerAngles;
        Vector3 currentEulerAngles = startEulerAngles;
        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            currentEulerAngles = Vector3.Lerp(startEulerAngles, targetEulerAngles, elapsedTime / duration);
            childTransform.eulerAngles = currentEulerAngles;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the final rotation is set correctly
        childTransform.eulerAngles = targetEulerAngles;
    }

    private bool ColorsApproximatelyEqual(UnityEngine.Color color1, UnityEngine.Color color2, float tolerance)
    {
        float rDiff = Mathf.Abs(color1.r - color2.r);
        float gDiff = Mathf.Abs(color1.g - color2.g);
        float bDiff = Mathf.Abs(color1.b - color2.b);

        return rDiff <= tolerance && gDiff <= tolerance && bDiff <= tolerance;
    }
}
