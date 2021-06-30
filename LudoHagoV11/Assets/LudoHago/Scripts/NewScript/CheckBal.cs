using AssemblyCSharp;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;


public class CheckBal : MonoBehaviour
{
    private WWWForm form;
    public Text bal;
    public int CheckBalanceforgameplay;

    


    private void Start()
    {
        //PlayerPrefs.GetString("mobileno");
        StartCoroutine(CheckBalance());


        //if (PlayerPrefs.HasKey("mobileno")) { 
        //Debug.Log(PlayerPrefs.GetString("balance"));
        //}
        //else
        //{
        //    Debug.Log("Nobal");
        //}
    }




    public void Checkbalancecomplete()
    {
        StartCoroutine(CheckBalance());
      
    }

    IEnumerator CheckBalance()
    {
        //mobile.text = PlayerPrefs.GetString("mobileno");
        form = new WWWForm();

        //form.AddField("mobile", PlayerPrefs.GetString("mobileno"));
        form.AddField("mobile", PlayerPrefs.GetString("mobileno"));

        WWW w = new WWW(StaticStrings.urlbal, form);
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
                   // bal.text = w.text;
                    var balance = w.text;
                    PlayerPrefs.SetString("balance", balance);
                    PlayerPrefs.Save();
                    Debug.Log(PlayerPrefs.GetString("balance"));
                    bal.text = PlayerPrefs.GetString("balance");
                    Debug.Log("<color=green>" + w.text + "</color>");//user exist
                    CheckBalanceforgameplay = int.Parse(w.text);
                }
            }
        }

        //loginButton.interactable = true;

        w.Dispose();
    }




}


