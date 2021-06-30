using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Username : MonoBehaviour
{
    private WWWForm form;
    public Text username;
    public InputField setusernameinweb;

    string urlusername = "http://instantservice.in/lightningminds/admin/adminsyf/jobboardfi/getusername.php";
    string setusername = "http://instantservice.in/lightningminds/admin/adminsyf/jobboardfi/setusername.php";
   // string setusername = "http://localhost/hagotick/setusername.php";
   // string urlusername = "http://localhost/hagotick/getusername.php";


    private void Start()
    {
        PlayerPrefs.GetString("username");
        StartCoroutine(CheckUsername());
        if (PlayerPrefs.HasKey("username"))
        {
            Debug.Log(PlayerPrefs.GetString("username"));
        }
        else
        {
            Debug.Log("NO username");
        }
    }

    public void Setusernamedatasend()
    {

        StartCoroutine(Setusername());
    }


    public void CheckUserNameAfterChange(){
        StartCoroutine(CheckUsername());
    }

    IEnumerator CheckUsername()
    {
        form = new WWWForm();

        form.AddField("mobile", PlayerPrefs.GetString("mobileno"));
       

         WWW w = new WWW(urlusername, form);
        yield return w;

        if (w.error != null)
        {
            // errorMessages.text = "404 not found!";
            Debug.Log("<color=red>" + w.text + "</color>");//error
            Debug.Log(PlayerPrefs.GetString("mobileno"));
        }
        else
        {
            if (w.isDone)
            {
                if (w.text.Contains("error"))
                {
                    // errorMessages.text = "invalid username or password!";
                    Debug.Log("<color=red>" + w.text + "</color>");//error
                    Debug.Log(PlayerPrefs.GetString("mobileno"));
                }
                else
                {
                   
                  
                    username.text = w.text;
                    Debug.Log(username.text);
                }
            }
        }

        //loginButton.interactable = true;

        w.Dispose();
    }


    IEnumerator Setusername()
    {
        form = new WWWForm();

        form.AddField("mobile", PlayerPrefs.GetString("mobileno"));
        form.AddField("setusernameinweb", setusernameinweb.text);
        WWW w = new WWW(setusername, form);
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

                   
                    
                }
            }
        }

        //loginButton.interactable = true;

        w.Dispose();
    }
}
