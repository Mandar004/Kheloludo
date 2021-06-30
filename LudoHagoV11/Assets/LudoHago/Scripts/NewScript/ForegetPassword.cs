using AssemblyCSharp;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ForegetPassword : MonoBehaviour
{

    public InputField mobileno;
    public InputField password;
    public InputField otp;
    public Text errtext;
    public Text errtextotp;
    public GameObject forgetpanel;
    public GameObject login;
    public GameObject otppanel;
    public GameObject setpassword;
    public GameObject forgetpasssuccess;
    public GameObject setpasspanel;



    public void InsertIntoDatabsenewpasswrodto()
    {

        StartCoroutine(InsertIntoDatabsenewpasswrodtodb());

    }


    IEnumerator InsertIntoDatabsenewpasswrodtodb()
    {

        WWWForm form = new WWWForm();
        form.AddField("mobileno", PlayerPrefs.GetString("forgetpasswordmobile"));
        form.AddField("password", password.text);
        using (UnityWebRequest www = UnityWebRequest.Post(StaticStrings.forgetpassword, form))
        {
            yield return www.SendWebRequest();
            if (www.isNetworkError || www.isHttpError)
            {
                print(www.error);
            }
            else
            {
                if (www.isDone)
                {
                    if (www.downloadHandler.text.Contains("Check Your Mobile Number"))
                    {
                        print(www.downloadHandler.text);
                        errtext.text = "Check Your Mobile Number";
                    }

                    else if (www.downloadHandler.text.Contains("Forget Password insert successfully"))
                    {
                        print(www.downloadHandler.text);
                        forgetpasssuccess.SetActive(true);
                        setpasspanel.SetActive(false);
                        PlayerPrefs.DeleteKey("forgetpasswordmobile");

                    }
                }
            }
        }
    }


    public void Checkotppass()
    {

        StartCoroutine(Checkotp());

    }


    IEnumerator Checkotp()
    {

        WWWForm form = new WWWForm();
        form.AddField("mobileno", PlayerPrefs.GetString("forgetpasswordmobile"));
        form.AddField("otp", otp.text);

        using (UnityWebRequest www = UnityWebRequest.Post(StaticStrings.checkotp, form))
        {
            yield return www.SendWebRequest();
            if (www.isNetworkError || www.isHttpError)
            {
                print(www.error);
            }
            else
            {
                if (www.isDone)
                {
                    if (www.downloadHandler.text.Contains("Wrong OTP"))
                    {
                        print(www.downloadHandler.text);
                        errtextotp.text = "Wrong OTP";
                    }

                    else if (www.downloadHandler.text.Contains("Success"))
                    {
                        print(www.downloadHandler.text);
                        setpassword.SetActive(true);
                        otppanel.SetActive(false);

                    }
                }
            }
        }
    }

    public void SendagainOTP()
    {

        StartCoroutine(SendagainOTPtoDB());

    }


    IEnumerator SendagainOTPtoDB()
    {

        WWWForm form = new WWWForm();
        form.AddField("mobileno", PlayerPrefs.GetString("forgetpasswordmobile"));

        using (UnityWebRequest www = UnityWebRequest.Post(StaticStrings.otpsms, form))
        {
            yield return www.SendWebRequest();
            if (www.isNetworkError || www.isHttpError)
            {
                print(www.error);
            }
            else
            {
                if (www.isDone)
                {
                    if (www.downloadHandler.text.Contains("Check Your Mobile Number"))
                    {
                        print(www.downloadHandler.text);
                        errtext.text = "Check Your Mobile Number";
                    }

                    else if (www.downloadHandler.text.Contains("Success"))
                    {
                        print(www.downloadHandler.text);
                        otppanel.SetActive(true);
                        forgetpanel.SetActive(false);
                        PlayerPrefs.SetString("forgetpasswordmobile", mobileno.text);
                        PlayerPrefs.Save();
                        //login.SetActive(true);
                        //forgetpanel.SetActive(false);


                    }
                }
            }
        }
    }




    public void InsertIntoDaforgetpasswrodtodb()
    {

        StartCoroutine(InsertIntoDaforgetpasswrod());

    }


    IEnumerator InsertIntoDaforgetpasswrod()
    {

        WWWForm form = new WWWForm();
        form.AddField("mobileno", mobileno.text);

        using (UnityWebRequest www = UnityWebRequest.Post(StaticStrings.otpsms, form))
        {
            yield return www.SendWebRequest();
            if (www.isNetworkError || www.isHttpError)
            {
                print(www.error);
            }
            else
            {
                if (www.isDone)
                {
                    if (www.downloadHandler.text.Contains("Check Your Mobile Number"))
                    {
                        print(www.downloadHandler.text);
                        errtext.text = "Check Your Mobile Number";
                    }

                    else if(www.downloadHandler.text.Contains("Success"))
                    {
                        print(www.downloadHandler.text);
                        otppanel.SetActive(true);
                        forgetpanel.SetActive(false);
                        PlayerPrefs.SetString("forgetpasswordmobile", mobileno.text);
                        PlayerPrefs.Save();
                        //login.SetActive(true);
                        //forgetpanel.SetActive(false);


                    }
                }
            }
        }
    }
}





