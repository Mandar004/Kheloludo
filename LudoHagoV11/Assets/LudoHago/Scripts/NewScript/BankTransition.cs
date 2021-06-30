using AssemblyCSharp;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class BankTransition : MonoBehaviour
{

    private void Start()
    {
        Checkbalancecomplete();
    }
    public void Checkbalancecomplete()
    {
        StartCoroutine(CheckBalance());

    }

    IEnumerator CheckBalance()
    {
        WWWForm form = new WWWForm();
        //form.AddField("mobile", PlayerPrefs.GetString("mobileno"));
        form.AddField("mobile", "5555555551");
        using (UnityWebRequest www = UnityWebRequest.Post(StaticStrings.banktransition, form))
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

                        string histrory = www.downloadHandler.text;
                        Debug.Log(histrory);
                    }
                }
            }
        }



    }
}
