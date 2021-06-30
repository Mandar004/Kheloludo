using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Setwinnerprice : MonoBehaviour
{
    private WWWForm form;
    public string Mobileno;
    public string WinningAmount;

   // string winnerurl = "http://instantservice.in/lightningminds/admin/adminsyf/jobboardfi/setwinnerprice.php";
   // string winnerurl = "http://localhost/hagotick/setwinnerprice.php";
    //string winnerprizeurl = "http://localhost/hagotick/sendwinningamount.php";


    public void Start()
    {
        GameManager.Instance.setwinnerprice = this;
    }


    public void SendWinnerData()
    {
        StartCoroutine(Checkwinners());
    }


   
    IEnumerator Checkwinners()
    {
        string winnerprizeurl = "http://localhost/hagotick/sendwinningamount.php";
        form = new WWWForm();
        form.AddField("mobile", PlayerPrefs.GetString("mobileno"));
        form.AddField("winningamount", PlayerPrefs.GetString("winningamount"));
        //  form.AddField("winningamount", PlayerPrefs.GetString("mobileno"));

        WWW w = new WWW(winnerprizeurl, form);
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
                    //var balance = w.text;


                    Debug.Log("<color=green>" + w.text + "</color>");//user exist

                }
            }
        }

        //loginButton.interactable = true;

        w.Dispose();
    }




}
