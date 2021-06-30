using AssemblyCSharp;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class OTPRegister : MonoBehaviour
{

    public Text errtextotp;
    public InputField otp;
    public GameObject Loginpanel;
    public GameObject OTPPanel;

    public void Checkotppass()
    {

        StartCoroutine(Checkotp());

    }


    IEnumerator Checkotp()
    {

        WWWForm form = new WWWForm();
        form.AddField("mobileno", PlayerPrefs.GetString("mobileno"));
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
                        Loginpanel.SetActive(true);
                        OTPPanel.SetActive(false);
                    }
                }
            }
        }
    }

}
