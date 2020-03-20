using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject[] vanilyas;
    public GameObject[] karpuzs;
    public Button beyaz;
    public Button kirmizi;
    public Text progressText;
    public Text matchRateText;
    public GameObject[] progressImages;
    public GameObject[] matchRateImages;
    public GameObject ornekKulah;
    public GameObject canvas;

    private bool vanilya1=false;
    private bool vanilya2 = false;
    private bool vanilya3 = false;
    private bool karpuz1 = false;
    private bool karpuz2 = false;
    private bool karpuz3 = false;
    private bool endGame = false;
    private int buttonInt;
    private string childIndex0;
    private string childIndex1;
    private int matchRateShowInt = 0;

    // Start is called before the first frame update
    private void OnEnable()
    {
        buttonInt = 0;
        endGame = false;

    }
    void Start()
    {
        childIndex0 = ornekKulah.transform.GetChild(0).name;
        childIndex1 = ornekKulah.transform.GetChild(1).name;


    }

    // Update is called once per frame
    void Update()
    {
        if (buttonInt == ornekKulah.transform.childCount)
        {
            beyaz.interactable = false;
            kirmizi.interactable = false;
        }

        if (buttonInt == 0)
        {
            beyaz.interactable = true;
            kirmizi.interactable = true;
        }

        progressBarControl();
        matchRate();

    }

    

    public void Vanilya()
    {
        if (vanilya1 == false && karpuz1 == false)
        {
            Instantiate(vanilyas[0], new Vector3(0, 0, 0), Quaternion.identity);
            vanilya1 = true;
            buttonInt++;
        }
        else if(vanilya2== false && karpuz2 == false)
        {
            Instantiate(vanilyas[1], new Vector3(0, 0.5f, 0), Quaternion.identity);
            vanilya2 = true;
            buttonInt++;
        }
        else
        {
            Instantiate(vanilyas[2], new Vector3(0, 1, 0), Quaternion.identity);
            vanilya3 = true;
            buttonInt++;
        }

    }
    public void Karpuz()
    {
        if (vanilya1 == false && karpuz1 == false)
        {
            Instantiate(karpuzs[0], new Vector3(0, 0, 0), Quaternion.identity);
            karpuz1 = true;
            buttonInt++;
        }
        else if (vanilya2==false && karpuz2==false)
        {
            Instantiate(karpuzs[1], new Vector3(0, 0.5f, 0), Quaternion.identity);
            karpuz2 = true;
            buttonInt++;
        }
        else
        {
            Instantiate(karpuzs[2], new Vector3(0, 1, 0), Quaternion.identity);
            karpuz3 = true;
            buttonInt++;
        }
    }

    public void progressBarControl()
    {
        //4 top dondurma varsa
        if (buttonInt == 1 && ornekKulah.transform.childCount == 4)
        {
            progressImages[0].SetActive(true);
            progressText.text = "%25";
        }
        else if (buttonInt == 2 && ornekKulah.transform.childCount == 4)
        {
            progressImages[1].SetActive(true);
            progressText.text = "%50";
        }
        else if (buttonInt == 3 && ornekKulah.transform.childCount == 4)
        {
            progressImages[2].SetActive(true);
            progressText.text = "%75";
        }
        else if(buttonInt ==4 && ornekKulah.transform.childCount == 4)
        {
            progressImages[3].SetActive(true);
            progressText.text = "%100";
            endGame = true;
        }

        //3 top dondurma varsa
        if (buttonInt == 1 && ornekKulah.transform.childCount == 3)
        {
            progressImages[0].SetActive(true);
            progressText.text = "%33";
        }
        else if (buttonInt == 2 && ornekKulah.transform.childCount == 3)
        {
            progressImages[1].SetActive(true);
            progressImages[2].SetActive(true);
            progressText.text = "%66";
        }
        else if (buttonInt == 3 && ornekKulah.transform.childCount == 3)
        {
            progressImages[3].SetActive(true);
            progressText.text = "%100";
            endGame = true;
        }

        //2 top dondurma varsa

        if (buttonInt == 1 && ornekKulah.transform.childCount == 2)
        {
            progressImages[0].SetActive(true);
            progressImages[1].SetActive(true);
            progressText.text = "%50";
        }
        else if (buttonInt == 2 && ornekKulah.transform.childCount == 2)
        {
            progressImages[2].SetActive(true);
            progressImages[3].SetActive(true);
            progressText.text = "%100";
            endGame = true;
        }

        //1 top dondurma varsa

        if (buttonInt == 1 && ornekKulah.transform.childCount == 1)
        {
            progressImages[0].SetActive(true);
            progressImages[1].SetActive(true);
            progressImages[2].SetActive(true);
            progressImages[3].SetActive(true);
            progressText.text = "%100";
            endGame = true;
        }

    }

    private void matchRate()
    {

        if (endGame)
        {
                if (ornekKulah.transform.childCount == 1)
                {
                    if (childIndex0 == "VanilyaTop" && vanilya1)
                    {
                        Debug.Log("%100");
                        matchRateShowInt = 0;
                    }
                    if (childIndex1 == "KarpuzTop" && karpuz1)
                    {
                        Debug.Log("%100");
                        matchRateShowInt = 1;
                    }
                }

                if (ornekKulah.transform.childCount == 2)
                {
                    if (childIndex0=="VanilyaTop" && vanilya1)
                    {
                        Debug.Log("%50");
                        matchRateShowInt = 2;
                    }
                    if (childIndex1=="KarpuzTop" && karpuz1)
                    {
                        Debug.Log("%50");
                        matchRateShowInt = 3;
                    }
                    if ( !vanilya1 && vanilya2)
                    {
                        Debug.Log("%100");
                        matchRateShowInt = 4;
                    }
                    if ( !karpuz1 && karpuz2)
                    {
                        Debug.Log("%100");
                        matchRateShowInt = 5;
                    }

                }

                if (ornekKulah.transform.childCount == 3)
                {
                if (childIndex0 == "VanilyaTop" && vanilya1)
                {
                    Debug.Log("%33");
                    matchRateShowInt = 6;
                }
                if (childIndex1 == "KarpuzTop" && karpuz1)
                {
                    Debug.Log("%33");
                    matchRateShowInt = 7;
                }
                if(childIndex1 == "KarpuzTop" && vanilya1 && karpuz2)
                {
                    Debug.Log("%66");
                    matchRateShowInt = 8;
                }
                if (ornekKulah.transform.GetChild(2).name == "VanilyaTop" && vanilya1 && !karpuz2 && vanilya3)
                {
                    Debug.Log("%100");
                    matchRateShowInt = 9;
                }
                if (ornekKulah.transform.GetChild(2).name == "VanilyaTop" && vanilya1 && karpuz2 && vanilya3)
                {
                    Debug.Log("%100");
                    matchRateShowInt = 10;
                }
            }
            Invoke("matchRateShow", 1);
        }

        
    }

    private void matchRateShow()
    {
        canvas.SetActive(true);
        if (matchRateShowInt == 2 || matchRateShowInt == 3)
        {
            matchRateImages[0].SetActive(true);
            matchRateImages[1].SetActive(true);
            matchRateText.text = "%50";
        }
        else if(matchRateShowInt == 4 || matchRateShowInt == 5)
        {
            matchRateImages[0].SetActive(true);
            matchRateImages[1].SetActive(true);
            matchRateImages[2].SetActive(true);
            matchRateImages[3].SetActive(true);
            matchRateText.text = "%100";
        }
        if(matchRateShowInt==6 || matchRateShowInt == 7)
        {
            matchRateImages[0].SetActive(true);
            matchRateText.text = "%33";
        }
        else if(matchRateShowInt == 8 || matchRateShowInt ==9)
        {
            matchRateImages[0].SetActive(true);
            matchRateImages[1].SetActive(true);
            matchRateImages[2].SetActive(true);
            matchRateText.text = "%66";
        }
        else if(matchRateShowInt == 10)
        {
            matchRateImages[0].SetActive(true);
            matchRateImages[1].SetActive(true);
            matchRateImages[2].SetActive(true);
            matchRateImages[3].SetActive(true);
            matchRateText.text = "%100";
        }
    }


    public void levelPass()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    //GameObject GetChildWithName(GameObject obj, string name)
    //{
    //    Transform trans = obj.transform;
    //    Transform childTrans = trans.Find(name);
    //    if (childTrans != null)
    //    {
    //        return childTrans.gameObject;
    //    }
    //    else
    //    {
    //        return null;
    //    }
}



