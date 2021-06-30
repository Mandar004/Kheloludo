using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class ShowPlayerDetails : MonoBehaviour
{

    //[SerializeField] InputField loginusername;
    [SerializeField] Text user;
     Text bal;
    [Space]
    // [SerializeField] Text errorMessages;
    //Text mobile;

    //[SerializeField] Button loginButton;
    //string text = "45454";

    WWWForm form;
    string urllogin = "http://instantservice.in/lightningminds/admin/adminsyf/jobboardfi/getuserdetails.php";
    string urlbal = "http://instantservice.in/lightningminds/admin/adminsyf/jobboardfi/checkbal.php"; 


    public void Start()
    {
        StartCoroutine(CheckBal());
        //StartCoroutine(Loginuser());


    }
    public void Update()
    {
      //  StartCoroutine(CheckBal());
      

    }


   IEnumerator Loginuser()
    {
       // Debug.Log(PlayerPrefs.GetString("loginusername"));
        string username = PlayerPrefs.GetString("username");
        //mobile.text = PlayerPrefs.GetString("mobileno");
        form = new WWWForm();

        form.AddField("username", PlayerPrefs.GetString("loginusername"));
        //form.AddField("mobile", text);

        WWW w = new WWW(urllogin, form);
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
                        user.text = w.text;
                    Debug.Log("<color=green>" + w.text + "</color>");//user exist

                }
            }
        }

        //loginButton.interactable = true;

        w.Dispose();
    }

    IEnumerator CheckBal()
    {
        //mobile.text = PlayerPrefs.GetString("mobileno");
        form = new WWWForm();

        form.AddField("mobile", PlayerPrefs.GetString("mobileno"));
        Debug.Log(PlayerPrefs.GetString("mobileno"));
        //form.AddField("loginusername", PlayerPrefs.GetString("loginusername"));

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
                    //bal.text = w.text;
                    string balance = w.text;
                    PlayerPrefs.SetString("balance", balance);
                    PlayerPrefs.Save();
                   // Debug.Log(PlayerPrefs.GetInt("balance"));
                   // Debug.Log("<color=green>" + w.text + "</color>");//user exist
                }
            }
        }

        //loginButton.interactable = true;

        w.Dispose();
    }

    
}
