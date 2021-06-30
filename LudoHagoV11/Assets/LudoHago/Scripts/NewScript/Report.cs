using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Report : MonoBehaviour
{
    [SerializeField] InputField reports;
    string mobileno;
    WWWForm form;
    public GameObject Successpanel;

    private void Start()
    {
        Debug.Log(PlayerPrefs.GetString("mobileno"));
    }
    public void Sendtodatabase()
    {
        StartCoroutine(InsertIntoDataBase());
    }


    IEnumerator InsertIntoDataBase()
    {
        // Change url to your own
        string url = "http://localhost/hagotick/report.php";
        WWWForm form = new WWWForm();
        form.AddField("report", reports.text);
        form.AddField("mobileno", PlayerPrefs.GetString("mobileno"));


        using (UnityWebRequest www = UnityWebRequest.Post(url, form))
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
                        
                    }
                    else
                    {

                        //print(www.downloadHandler.text);
                        Debug.Log("Send successfully");
                        Successpanel.SetActive(true);
                    }
                }
            }
        }

    }
}
