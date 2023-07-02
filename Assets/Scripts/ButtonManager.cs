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
    public GameObject settingsPanel;
    

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
        if (PlayerPrefs.GetInt("SavedLevel") < 19)
        {
            leveltext.text = "Level " + SceneManager.GetActiveScene().buildIndex.ToString();
        }
        else
        {
            leveltext.text = "Level " + (PlayerPrefs.GetInt("SavedLevel"));
        }
        
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void nextLevel()
    {
        if (PlayerPrefs.GetInt("SavedLevel") == null || PlayerPrefs.GetInt("SavedLevel") == 0) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        else if (PlayerPrefs.GetInt("SavedLevel") < 19) {
            SceneManager.LoadScene(PlayerPrefs.GetInt("SavedLevel"));
                }
        else
        {
            SceneManager.LoadScene(PlayerPrefs.GetInt("SavedRandomLevel"));
        }

    }

    public void clearSavedLevel()
    {
        PlayerPrefs.SetInt("SavedLevel", 0);
        PlayerPrefs.SetInt("SavedRandomLevel", 0);
    }

    public void menu()
    {
        SceneManager.LoadScene(0);
    }

    public void settings()
    {
        settingsPanel.SetActive(true);
    }
    public void closeSettings()
    {
        settingsPanel.SetActive(false);
    }
}
