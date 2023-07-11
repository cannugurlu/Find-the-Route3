using System.Collections;
using System.Collections.Generic;
//using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

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
    public RectTransform panelRectTransform;
    public RectTransform textRectTransform;
    public RectTransform buttonRectTransform;
    public RectTransform button2RectTransform;



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
        panelRectTransform.DOAnchorPos(new Vector2(0.0f,179.0f), 0.4f);
        buttonRectTransform.DOAnchorPos(new Vector2(0.0f, 170.0f), 0.2f);
        textRectTransform.DOAnchorPos(new Vector2(106.0f, -160.0f), 0.4f);
        button2RectTransform.DOAnchorPos(new Vector2(-270, -46.8999f), 0.4f);
    }
    public void closeSettings()
    {
        panelRectTransform.DOAnchorPos(new Vector2(1100.0f, 179.0f), 0.4f).OnComplete(()=>
        panelRectTransform.anchoredPosition=new Vector2(-1100,179));

        buttonRectTransform.DOAnchorPos(new Vector2(0.0f, -36.0f), 0.2f);
        textRectTransform.DOAnchorPos(new Vector2(106.0f, -328.0f), 0.4f);
        button2RectTransform.DOAnchorPos(new Vector2(36.09998f, -46.8999f), 0.4f);
    }

    
}
