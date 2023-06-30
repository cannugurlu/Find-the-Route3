using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class moveController2 : MonoBehaviour
{
    public float velocity=175.0f;
    [SerializeField] float yolYRot, carYRot;
    public bool isTrigger=false;
    public bool isMove=false;
    public bool isClickable = true;
    private string objName;
    public GameObject winPanel;
    public bool win = false;
    ButtonManager buttonManager;
    public ParticleSystem konfeti;
    public bool isAvailable = true;
    

    private void Awake()
    {
        if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            konfeti = GameObject.Find("konfeti").GetComponent<ParticleSystem>();
            winPanel = GameObject.Find("Canvas").transform.GetChild(2).gameObject;
        }

        buttonManager = GameObject.FindObjectOfType<ButtonManager>();
        konfeti.Stop();
    }
 
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit = CastRay();

            if (hit.collider != null)
            {
                if (hit.collider.CompareTag("bas") && isClickable)
                {
                    objName = "car";

                    if (this.gameObject.name == objName)
                    {
                        isMove = true;
                        isClickable = false;
                    }
                }
                else if (hit.collider.CompareTag("bas2") && isClickable)
                {
                    objName = "car2";

                    if (this.gameObject.name == objName)
                    {
                        isMove = true;
                        isClickable = false;
                    }
                    
                }
                else if (hit.collider.CompareTag("bas3") && isClickable)
                {
                    objName = "car3";

                    if (this.gameObject.name == objName)
                    {
                        isMove = true;
                        isClickable = false;
                    }

                }
                else if(gameObject.GetComponent<Rigidbody>().velocity != Vector3.zero) // hareket ederken baþka yere týklandýðýnda hareket etmeye devam etmesi için
                {
                    isMove = true;
                }
                else
                {
                    isMove = false;
                }
            }
      
        }
        carYRot = transform.rotation.eulerAngles.y;
     
    }
    
    void OnTriggerStay(Collider other)
    {
       
        

        if (this.gameObject.name== objName && isMove)
        {
            
           
            if ((other.gameObject.tag == "yol" || other.gameObject.tag == "up" || other.gameObject.tag == "forward" || other.gameObject.tag == "down"))
            {
             

                if (isAvailable)
                {
                    this.gameObject.GetComponent<Rigidbody>().velocity = velocity * transform.forward * Time.deltaTime;
                    isTrigger = true;
                }
                else
                {
                    print("isAvailable falseoldu");
                    this.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                    print(this.gameObject.GetComponent<Rigidbody>().velocity);
                }
            }

            if (other.gameObject.tag == "start")
            {
                this.gameObject.GetComponent<Rigidbody>().velocity = velocity * transform.forward * Time.deltaTime;
                isTrigger = true;
            }
            if (other.gameObject.tag == "finish")
            {
                this.gameObject.GetComponent<Rigidbody>().velocity = velocity * transform.forward * Time.deltaTime;
                isTrigger = true;
            }
        }
        

    }
    void OnTriggerExit(Collider other)
    {
            this.gameObject.GetComponent<Rigidbody>().velocity = 0.0f * transform.forward * Time.deltaTime;
            isTrigger = false;
          
        if (gameObject.name == "car")
        {
            if (other.gameObject.name == "finish")
            {
                buttonManager.carNumber--;
                win = true;
                if (buttonManager.carNumber == 0)
                {
                    konfeti.Play();
                    Invoke("WinPanel", 1.5f);
                    Invoke("nextLevel", 3f);
                }
            }
        }
        if (gameObject.name == "car2")
        {
            if (other.gameObject.name == "finish2")
            {
                buttonManager.carNumber--;
                win = true;
                if (buttonManager.carNumber == 0)
                {
                    konfeti.Play();
                    Invoke("WinPanel", 1.5f);
                    Invoke("nextLevel", 3f);
                }
            }
        }
        if (gameObject.name == "car3")
        {
            if (other.gameObject.name == "finish3")
            {
                buttonManager.carNumber--;
                win = true;
                if (buttonManager.carNumber == 0)
                {
                    konfeti.Play();
                    Invoke("WinPanel", 1.5f);
                    Invoke("nextLevel", 3f);
                }
            }
        }
        if (other.gameObject.tag == "down")
        {
            gameObject.transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x - 10, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);

        }

    }
    
    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("gate"))
        {
            isAvailable = true;
            Color colorCar = transform.GetChild(1).GetComponent<MeshRenderer>().material.color;
            Color colorGate = other.gameObject.GetComponent<MeshRenderer>().material.color;



            if (ColorsApproximatelyEqual(colorCar, colorGate, 0.1f))
            {
                print("Car color: " + colorCar);
                print("Gate color: " + colorGate);
                isAvailable = true;
                print("is available true");
            }
            else
            {
                isAvailable = false;
            }
        }

        if (this.gameObject.name == objName)
        {
            if (other.gameObject.tag == "yol")
            {
                isTrigger = true;
            }
        }
        if (other.gameObject.tag == "turn")
        {
                yolYRot = other.transform.rotation.eulerAngles.y;

                if (Mathf.RoundToInt(yolYRot + carYRot) % 180 == 0)
                {
                gameObject.transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + 90.0f, transform.rotation.eulerAngles.z);
                }
                else
                {
                gameObject.transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y - 90.0f, transform.rotation.eulerAngles.z);

            }
        }

        if(other.gameObject.tag == "up")
        {
            gameObject.transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x-10, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
            
        }
        if (other.gameObject.tag == "forward")
        {
            gameObject.transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x + 10, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);

        }
        if (other.gameObject.tag == "down")
        {
            gameObject.transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x + 10, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "stone" || collision.gameObject.tag == "obstacle")
        {
            this.gameObject.GetComponent<Rigidbody>().velocity = 0.0f * transform.forward * Time.deltaTime;
            isTrigger = false;

        }
    }
    
    void WinPanel()
    {
        winPanel.SetActive(true);

    }
    public void nextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    RaycastHit CastRay()
    {
        Vector3 screenMousePosFar = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.farClipPlane);
        Vector3 screenMousePosNear = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane);
        Vector3 worldMousePosFar = Camera.main.ScreenToWorldPoint(screenMousePosFar);
        Vector3 worldMousePosNear = Camera.main.ScreenToWorldPoint(screenMousePosNear);
        RaycastHit hit;
        Physics.Raycast(worldMousePosNear, worldMousePosFar - worldMousePosNear, out hit);

        return hit;
    }

    private bool ColorsApproximatelyEqual(Color color1, Color color2, float tolerance)
    {
        float rDiff = Mathf.Abs(color1.r - color2.r);
        float gDiff = Mathf.Abs(color1.g - color2.g);
        float bDiff = Mathf.Abs(color1.b - color2.b);

        return rDiff <= tolerance && gDiff <= tolerance && bDiff <= tolerance;
    }
}
