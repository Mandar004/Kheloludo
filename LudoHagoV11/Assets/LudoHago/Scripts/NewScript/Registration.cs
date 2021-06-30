using AssemblyCSharp;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class Registration : MonoBehaviour
{
    [SerializeField] InputField username, password, age, mobileno, referralcode;
    [SerializeField] InputField loginusername, loginpassword;
    //[SerializeField] GameObject welcomePanel;
    //[SerializeField] Text user;
    [Space]
    [SerializeField] Text errorMessages;
    [SerializeField] Text errorMessagesmobilenumber;
    [SerializeField] Button loginButton;
    [SerializeField] GameObject LoginCanvas;
    [SerializeField] GameObject LoginCanvass;
    [SerializeField] GameObject RegistrationCanvas;
    [SerializeField] GameObject WelcomeScreen;
    [SerializeField] GameObject splashCanvas;
    public GameObject otppanel;
    public GameObject otpnotverifiedpanel;



    //[SerializeField] Button registrationButton;
    // string registerkey;
    private PlayFabManager playFabManager;
    WWWForm form;
    private bool isOTPTrue=false;

    public void Registrations()
    {
        int usernamelength = username.text.Length;
        int len = mobileno.text.Length;
        if (len != 10)
        {
            errorMessagesmobilenumber.text = "Check You mobile number";
        }
        else if (usernamelength < 4)
        {
            errorMessagesmobilenumber.text = "Username must be morethan four character";
        }
        else
        {
            StartCoroutine(InsertIntoDataBase());
            
        }
        

    }

    public void OnLoginButtonClicked()
    {

        //playFabManager.Login();

        //loginButton.interactable = false;
        StartCoroutine(Loginuser());

    }
    public void SendtoMenuscene()
    {
        //PlayerPrefs.SetString("logType", "Guest");
        // SceneManager.LoadScene("Menuscene");
    }

    IEnumerator Loginuser()
    {
        form = new WWWForm();

        form.AddField("loginmobile", loginusername.text);
        form.AddField("loginpassword", loginpassword.text);

        WWW w = new WWW(StaticStrings.urllogin, form);
        yield return w;

        if (w.error != null)
        {
            errorMessages.text = "404 not found!";
            Debug.Log("<color=red>" + w.text + "</color>");//error
        }
        else
        {
            if (w.isDone)
            {

              

                  if (w.text.Contains("invalid username and password"))
                  {
                      errorMessages.text = "Invalid username or password!";
                      Debug.Log("<color=red>" + w.text + "</color>");//error
                      LoginCanvas.SetActive(true);
                  }
                  else if (w.text.Contains("otpnot verified"))
                  {
                    Debug.Log("<color=red>" + w.text + "</color>");//error
                    otpnotverifiedpanel.SetActive(true);
                  }
                  else
                  {
                          Debug.Log("<color=green>" + w.text + "</color>");//user exist

                          PlayerPrefs.SetString("mobileno", loginusername.text);
                          PlayerPrefs.Save();
                          PlayerPrefs.SetString("Login", "Login");
                          PlayerPrefs.Save();

                          if (PlayerPrefs.HasKey("Logout"))
                          {
                              PlayerPrefs.DeleteKey("Logout");
                          }
                          WelcomeScreen.SetActive(true);
                          LoginCanvass.SetActive(false);

                  }
            }
        }


        w.Dispose();
    }

    public string ReferralCode()
    {
        string name = username.text;
        string getfirst = name.Substring(0, 3);
        string getfirsty = getfirst.ToUpper();
        System.Random r = new System.Random();
        int genRand = r.Next(100, 999);
        string id = getfirsty + genRand;
        return id;
    }
    IEnumerator InsertIntoDataBase()
    {
        WWWForm form = new WWWForm();
        form.AddField("username", username.text);
        form.AddField("password", password.text);
        form.AddField("age", age.text);
        form.AddField("mobileno", mobileno.text);
        form.AddField("referralcode", referralcode.text);
        form.AddField("myrefrralcode", ReferralCode());

        
        using (UnityWebRequest www = UnityWebRequest.Post(StaticStrings.urlregister, form))
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
                    if (www.downloadHandler.text.Contains("Mobile Number Already Exist"))
                    {
                        errorMessagesmobilenumber.text = "Mobile Number Already Exist";
                        RegistrationCanvas.SetActive(true);
                        isOTPTrue = false;
                    }
                    else
                    {
                        //print(www.downloadHandler.text);
                        Debug.Log("Registered successfully");
                        PlayerPrefs.SetString("mobileno", mobileno.text);
                        PlayerPrefs.Save();
                        Debug.Log(PlayerPrefs.GetString("mobileno"));
                        PlayerPrefs.SetString("Registered", "Registered");
                        PlayerPrefs.Save();
                        Debug.Log(PlayerPrefs.GetString("Registered"));
                        StartCoroutine(Regsendotp());
                        //LoginCanvas.SetActive(true);
                        RegistrationCanvas.SetActive(false);
                        //isOTPTrue = true;
                        //user.text = loginusername.text;
                    }
                }
            }
        }

    }


    IEnumerator Regsendotp()
    {
        // Change url to your own

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
                       
                    }

                    else if (www.downloadHandler.text.Contains("Success"))
                    {
                        print(www.downloadHandler.text);
                        otppanel.SetActive(true);

                    }
                }
            }
        }

    }


}
