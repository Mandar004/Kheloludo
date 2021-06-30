using AssemblyCSharp;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class WithdrawRequest : MonoBehaviour
{
    
    public InputField amount;
    public InputField accountName;
    public InputField acccountNumber;
    public InputField bankName;
    public InputField ifscCode;
    public InputField paymtmamount;
    public InputField paytmMobile;
    public GameObject SuccessfullyWithdrawRequest;
    public Button button;
    public Button paytmbutton;
    public Text errortext;
    public string bal;
    public GameObject Balbelow;
    int Checkbalance;



    void OnEnable()
   {
        InvokeRepeating("Checkbal", 0.2f, 0.5f);
        InvokeRepeating("Checkbalancecomplete", 0.2f, 0.5f);
       
    }

    private void OnDisable()
    {
        CancelInvoke("Checkbalancecomplete");
    }
    public void Checkbalancecomplete()
    {
        StartCoroutine(CheckBalance());

    }


    public void WithDrawRequest()
    {
        int amountswithdraw = int.Parse(amount.text);

        if (GameManager.Instance.checkbalforplay >= amountswithdraw && amountswithdraw >= 200)
        {
            StartCoroutine(InsertIntoDataBase());
        }
        else
        {
            Balbelow.SetActive(true);
        }


       

    }


 
    IEnumerator InsertIntoDataBase()
    {

        WWWForm form = new WWWForm();
        form.AddField("mobile", PlayerPrefs.GetString("mobileno"));
        form.AddField("amount", amount.text);
        form.AddField("accountName", accountName.text);
        form.AddField("acccountNumber", acccountNumber.text);
        form.AddField("bankName", bankName.text);
        form.AddField("ifscCode", ifscCode.text);
        
        using (UnityWebRequest www = UnityWebRequest.Post(StaticStrings.withdraw, form))
        {
            yield return www.SendWebRequest();
            if (www.isNetworkError || www.isHttpError)
            {
                print(www.error);
                //errortext.text = www.error;
                
            }
            else
            {
                print(www.downloadHandler.text);
                Debug.Log("Registered successfully");
                SuccessfullyWithdrawRequest.SetActive(true); 
            }
        }
    }
        public void Checkbal()
        {
            int bal = GameManager.Instance.checkbalforplay;
            if (bal >=200)
            {
                button.interactable = true;
                paytmbutton.interactable = true;
            }
            else
            {
                button.interactable = false;
                paytmbutton.interactable = false;
            }

        }


    public void WithDrawRequestpaytm()
    {
   
        int amountswithdraw = int.Parse(paymtmamount.text);

        if (GameManager.Instance.checkbalforplay >= amountswithdraw && amountswithdraw >= 200)
        {
            StartCoroutine(InsertIntoDataBasepaytm());
        }
        else
        {
            Balbelow.SetActive(true);
        }
       

    }


    IEnumerator InsertIntoDataBasepaytm()
    {

        
        WWWForm form = new WWWForm();
        form.AddField("mobile", PlayerPrefs.GetString("mobileno"));
        form.AddField("amount", paymtmamount.text);
        form.AddField("acccountNumber", paytmMobile.text);
      

        using (UnityWebRequest www = UnityWebRequest.Post(StaticStrings.withdrawpaytm, form))
        {
            yield return www.SendWebRequest();
            if (www.isNetworkError || www.isHttpError)
            {
                print(www.error);
                //errortext.text = www.error;

            }
            else
            {
                print(www.downloadHandler.text);
                Debug.Log("Registered successfully");
                SuccessfullyWithdrawRequest.SetActive(true);
            }
        }
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


                        Checkbalance = int.Parse(www.downloadHandler.text);
                        GameManager.Instance.checkbalforplay= Checkbalance;
                        Debug.Log(GameManager.Instance.checkbalforplay);
                    }
                }
            }
        }
    }

    }
