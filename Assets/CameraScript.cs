using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    //public SpriteRenderer outline;
  
    // Use this for initialization
    void Start()
    {
        float screenRatio = (float)Screen.width / (float)Screen.height;
        float targetRatio =1080 / 1920;

        if (screenRatio >= targetRatio)
        {
            Camera.main.orthographicSize = 1920 / 2;
        }
        else
        {
            float differenceInSize = targetRatio / screenRatio;
            Camera.main.orthographicSize = 1920 / 2 * differenceInSize;
        }
    }
}