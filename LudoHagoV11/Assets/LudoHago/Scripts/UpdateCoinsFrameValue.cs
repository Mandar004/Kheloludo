using AssemblyCSharp;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class UpdateCoinsFrameValue : MonoBehaviour
{
    private WWWForm form;
    private int currentValue = 0;
    private Text text;
    void Start()
    {
        Checkbalancecomplete();
        text = GetComponent<Text>();
        InvokeRepeating("Checkbalancecomplete", 1f, 1f);
        StartCoroutine(CheckRef());
      

    }

    private void CheckAndUpdateValue()
    {
        if (currentValue != GameManager.Instance.myPlayerData.GetCoins())
        {
            currentValue = GameManager.Instance.myPlayerData.GetCoins();
            if (currentValue != 0)
            {
                text.text = GameManager.Instance.myPlayerData.GetCoins().ToString("0,0", CultureInfo.InvariantCulture).Replace(',', ' ');
            }
            else
            {
                text.text = "0";
            }
        }
    }


    public void Checkbalancecomplete()
    {
        StartCoroutine(CheckBalance());

    }

    IEnumerator CheckBalance()
    {
        WWWForm form = new WWWForm();
        form.AddField("mobile", PlayerPrefs.GetString("mobileno"));

        using (UnityWebRequest www = UnityWebRequest.Post(StaticStrings.urlbal, form))
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
                    if (www.downloadHandler.text.Contains("error"))
                    {
                        Debug.Log("<color=red>" + www.downloadHandler.text + "</color>");//error
                    }
                    else
                    {

                        string balString = www.downloadHandler.text;
                        text.text = Regex.Replace(balString, @"\s+", "");
                    }
                }
            }
        }



    }
    IEnumerator CheckRef()
    {
        WWWForm form = new WWWForm();

        form.AddField("mobile", PlayerPrefs.GetString("mobileno"));
        using (UnityWebRequest www = UnityWebRequest.Post(StaticStrings.getrefcode, form))
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
                    if (www.downloadHandler.text.Contains("error"))
                    {
                        Debug.Log("<color=red>" + www.downloadHandler.text + "</color>");//error
                    }
                    else
                    {

                        string refcode = www.downloadHandler.text;
                        GameManager.Instance.refcode = Regex.Replace(refcode, @"\s+", "");
                        Debug.Log(GameManager.Instance.refcode);
                    }
                }
            }
        }



    }


}
