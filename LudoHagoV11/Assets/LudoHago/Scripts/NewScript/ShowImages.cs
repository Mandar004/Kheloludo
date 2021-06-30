using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowImages : MonoBehaviour
{
    public Sprite avt0;
    public Sprite avt1;
    public Sprite avt2;
    public Sprite avt3;
    public Sprite avt4;
    public Sprite avt5;
    public Sprite avt6;
    public Sprite avt7;
    public Sprite avt8;
    public Sprite avt9;


    private void Update()
    {

        if (PlayerPrefs.GetInt("1") == 1) { gameObject.GetComponent<Image>().sprite = avt1; }
        else if (PlayerPrefs.GetInt("1") == 2) { gameObject.GetComponent<Image>().sprite = avt2; }
        else if (PlayerPrefs.GetInt("1") == 3) { gameObject.GetComponent<Image>().sprite = avt3; }
        else if (PlayerPrefs.GetInt("1") == 4) { gameObject.GetComponent<Image>().sprite = avt4; }
        else if (PlayerPrefs.GetInt("1") == 5) { gameObject.GetComponent<Image>().sprite = avt5; }
        else if (PlayerPrefs.GetInt("1") == 6) { gameObject.GetComponent<Image>().sprite = avt6; }
        else if (PlayerPrefs.GetInt("1") == 7) { gameObject.GetComponent<Image>().sprite = avt7; }
        else if (PlayerPrefs.GetInt("1") == 8) { gameObject.GetComponent<Image>().sprite = avt8; }
        else if (PlayerPrefs.GetInt("1") == 9) { gameObject.GetComponent<Image>().sprite = avt9; }
        else
        {
            gameObject.GetComponent<Image>().sprite = avt0;
        }
    
           
       
    }

    public void ChangeProfileImages()
    {
     
        if (PlayerPrefs.HasKey("1"))
        {
            gameObject.GetComponent<Image>().sprite = avt1;

        }
        else if (PlayerPrefs.HasKey("2"))
        {
            gameObject.GetComponent<Image>().sprite = avt2;
           
        }
        else if (PlayerPrefs.HasKey("3"))
        {
            gameObject.GetComponent<Image>().sprite = avt3;
        }
        else if (PlayerPrefs.HasKey("4"))
        {
            gameObject.GetComponent<Image>().sprite = avt4;
        }
        else if (PlayerPrefs.HasKey("5"))
        {
            gameObject.GetComponent<Image>().sprite = avt5;
        }
        else if (PlayerPrefs.HasKey("6"))
        {
            Debug.Log(PlayerPrefs.GetInt("6"));
            gameObject.GetComponent<Image>().sprite = avt6;
        }
        else if (PlayerPrefs.HasKey("7"))
        {
            gameObject.GetComponent<Image>().sprite = avt7;
        }
        else if (PlayerPrefs.HasKey("8"))
        {
            gameObject.GetComponent<Image>().sprite = avt8;
        }
        else if (PlayerPrefs.HasKey("9"))
        {
            gameObject.GetComponent<Image>().sprite = avt9;
        }
        else
        {
            gameObject.GetComponent<Image>().sprite = avt0;
        }
    }


   
}
