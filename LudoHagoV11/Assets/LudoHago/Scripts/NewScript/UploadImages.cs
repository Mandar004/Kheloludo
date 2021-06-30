using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class UploadImages : MonoBehaviour
{


    public void SetImage1()
    {
        PlayerPrefs.SetInt("1", 1);
        PlayerPrefs.Save();
      
    }
    public void SetImage2()
    {
        PlayerPrefs.SetInt("1", 2);
        PlayerPrefs.Save();
       
    }
    public void SetImage3()
    {
        PlayerPrefs.SetInt("1", 3);
        PlayerPrefs.Save();
       
    }
    public void SetImage4()
    {
        PlayerPrefs.SetInt("1", 4);
        PlayerPrefs.Save();
    }
    public void SetImage5()
    {
        PlayerPrefs.SetInt("1", 5);
        PlayerPrefs.Save();
    }
    public void SetImage6()
    {
        PlayerPrefs.SetInt("1", 6);
        PlayerPrefs.Save();
        Debug.Log(PlayerPrefs.GetInt("6"));
    }
    public void SetImage7()
    {
        PlayerPrefs.SetInt("1", 7);
        PlayerPrefs.Save();
    }
    public void SetImage8()
    {
        PlayerPrefs.SetInt("1", 8);
        PlayerPrefs.Save();
    }
    public void SetImage9()
    {
        PlayerPrefs.SetInt("1", 9);
        PlayerPrefs.Save();
    }
}
