using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class CameraScript : MonoBehaviour
{
    void Start()
    {
        Camera camera= GetComponent<Camera>(); 
        float screenRatio = (float)Screen.height / (float)Screen.width;
        float targetRatio =1920f / 1080;
        
        if(screenRatio > targetRatio)
        {
            camera.fieldOfView = 62;
        }
        else if(screenRatio == targetRatio)
        {
            camera.fieldOfView = 52;
                
        }
        else
        {
            camera.fieldOfView = 40;
        }
    }
}