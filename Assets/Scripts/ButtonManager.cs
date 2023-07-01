using System.Collections;
using System.Collections.Generic;
//using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEngine.UI;
using TMPro;

public class ButtonManager : MonoBehaviour
{
    GameObject car;
    Vector3 carPos;
    Quaternion carRot;
    GameObject car2;
    Vector3 carPos2;
    Quaternion carRot2;
    GameObject bul;
    Vector3 bulPos;
    Quaternion bulRot;
    GameObject stone;
    Vector3 stonePos;
    Quaternion stoneRot;
    public int carNumber;
    public TextMeshProUGUI leveltext;
    public GameObject carPrefab;
    GameObject newcar;
    

    private void Awake()
    {
        car = GameObject.Find("car");
        if (car)
        {
            carPos = car.transform.position;
            carRot = car.transform.rotation;
        }
        car2 = GameObject.Find("car2");
        if ( car2)
        {
            carPos2 = car2.transform.position;
            carRot2 = car2.transform.rotation;
        }
        bul = GameObject.Find("buldozer");
        if (bul)
        {
            bulPos = bul.transform.position;
            bulRot = bul.transform.rotation;
            stone = GameObject.FindGameObjectWithTag("stone");
            stonePos = stone.transform.position;
            stoneRot = stone.transform.rotation;

        }
        leveltext.text = "Level " + SceneManager.GetActiveScene().buildIndex.ToString();
        
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void nextLevel()
    {
        if (PlayerPrefs.GetInt("SavedLevel") == null || PlayerPrefs.GetInt("SavedLevel") == 0) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        else SceneManager.LoadScene(PlayerPrefs.GetInt("SavedLevel"));

    }

    public void clearSavedLevel()
    {
        PlayerPrefs.SetInt("SavedLevel", 0);
    }

    public void menu()
    {
        SceneManager.LoadScene(0);
    }


}
