using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestScript : MonoBehaviour
{
    public Text bidValue;
    public Text bidValue50;
    public int bid;
    //public Button btn;
    string urlbal = "http://instantservice.in/lightningminds/admin/adminsyf/jobboardfi/betamount.php";
    string urlcountplayer = "http://instantservice.in/lightningminds/admin/adminsyf/jobboardfi/playergamaplaycount.php";
    public GameObject noBalPanel;


    private WWWForm form;
    void Start()
    {
        bid = 5;
     
        // Debug.Log(test.text);


    }

    // Update is called once per frame
    void Update()
    {
       //Debug.Log( PlayerPrefs.GetString("balance"));
        bidValue.text = bid.ToString();
      

    }



    public void Onbutton() {
        
        bid += 10;
        Debug.Log(bid);


    }
    public void OnbuttonDecrase()
    {
        if (bid>5)
        {

            bid -= 10;

        }
           
    }
    public void OnbuttonIncrease50()
    {

        bid += 50;
        Debug.Log(bid);


    }

    public void OnbuttonDecrase50()
    {
        if (bid > 50)
        {

            bid -= 50;

        }

    }
    public void OnPlayDataSend()
    {
       
        StartCoroutine(Deductbal());
        StartCoroutine(PlayCount());
        //Debug.Log(PlayerPrefs.GetInt("fourplayer"));
        // Debug.Log(PlayerPrefs.GetInt("twoplayer"));
       
    }


     IEnumerator Deductbal()
    {

        //mobile.text = PlayerPrefs.GetString("mobileno");
        form = new WWWForm();
        form.AddField("mobile", PlayerPrefs.GetString("mobileno"));
        //form.AddField("username", PlayerPrefs.GetString("loginusername"));
        form.AddField("bal", bid);

        WWW w = new WWW(urlbal, form);
        yield return w;

        if (w.error != null)
        {
            // errorMessages.text = "404 not found!";
            Debug.Log("<color=red>" + w.text + "</color>");//error
        }
        else
        {
            if (w.isDone)
            {
                if (w.text.Contains("error"))
                {
                    // errorMessages.text = "invalid username or password!";
                    Debug.Log("<color=red>" + w.text + "</color>");//error
                }
                else
                {
                    //open welcom panel
                    //welcomePanel.SetActive(true);
                    Debug.Log("<color=green>" + w.text + "</color>");//user exist
                    Debug.Log("data Inserted");
                }
            }
        }

        //loginButton.interactable = true;

        w.Dispose();
    }
    public void CheckBal()
    {
        int bal = Convert.ToInt32(PlayerPrefs.GetString("balance"));
        
       if(bal<=bid)
        {
          noBalPanel.SetActive(true);
        }
    }

    public void OnbuttonclickTwoPlayer()
    {
        int i = 1;
       
        PlayerPrefs.SetInt("twoplayer", i);
        PlayerPrefs.Save();
        Debug.Log("two player clicked"+ PlayerPrefs.GetInt("twoplayer"));

    }
    public void OnbuttonclickFourPlayer()
    {
        int i = 1;
       
        PlayerPrefs.SetInt("fourplayer", i);
        PlayerPrefs.Save();
        Debug.Log("Four player clicked" + PlayerPrefs.GetInt("fourplayer"));

    }
    public void CheckOnbuttonclickTwoPlayer()
    {
        int i = 0;

        PlayerPrefs.SetInt("twoplayer", i);
        PlayerPrefs.Save();
        Debug.Log("two player Cancel" + PlayerPrefs.GetInt("twoplayer"));
    }
    public void CheckOnbuttonclickFourPlayer()
    {
        int i = 0;

        PlayerPrefs.SetInt("fourplayer", i);
        PlayerPrefs.Save();

        Debug.Log("Four player Cancel" + PlayerPrefs.GetInt("fourplayer"));
    }

    IEnumerator PlayCount()
    {

        //mobile.text = PlayerPrefs.GetString("mobileno");
        form = new WWWForm(); 
        form.AddField("mobile", PlayerPrefs.GetString("mobileno"));
        form.AddField("twoplayer", PlayerPrefs.GetInt("twoplayer"));
        form.AddField("fourplayer", PlayerPrefs.GetInt("fourplayer"));

        WWW w = new WWW(urlcountplayer, form);
        yield return w;

        if (w.error != null)
        {
            // errorMessages.text = "404 not found!";
            Debug.Log("<color=red>" + w.text + "</color>");//error
        }
        else
        {
            if (w.isDone)
            {
                if (w.text.Contains("error"))
                {
                    // errorMessages.text = "invalid username or password!";
                    Debug.Log("<color=red>" + w.text + "</color>");//error
                }
                else
                {
                    //open welcom panel
                    //welcomePanel.SetActive(true);
                    Debug.Log("<color=green>" + w.text + "</color>");//user exist
                    Debug.Log("Player count data Inserted");
                }
            }
        }

        //loginButton.interactable = true;

        w.Dispose();
    }

}
