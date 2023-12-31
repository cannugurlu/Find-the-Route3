using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicManager : MonoBehaviour
{
    void Awake()
    {
        GameObject[] musicObjects = GameObject.FindGameObjectsWithTag("Music");
        if (musicObjects.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
