using AssemblyCSharp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class EnterPrivateCodeDialogController : MonoBehaviour
{

    public GameObject inputField;
    public GameObject confirmationText;
    public GameObject joinButton;
    private Button join;
    private InputField field;
    public GameObject GameConfiguration;
    public GameObject failedDialog;
    public string currentBidIndex;
    private WWWForm form;
    public string Checkbalance;


    void OnEnable()
    {
        if (field != null)
            field.text = "";
        if (confirmationText != null)
            confirmationText.SetActive(false);
        if (join != null)
            join.interactable = false;

        InvokeRepeating("Checkbalancecomplete", 0.2f, 0.5f);
    }


    private void OnDisable()
    {
        CancelInvoke("Checkbalancecomplete");
    }
    // Use this for initialization
    void Start()
    {
        field = inputField.GetComponent<InputField>();
        join = joinButton.GetComponent<Button>();
        join.interactable = false;
    }

    // Update is called once per frame
    private void Update()
    {
        Checkbalancecomplete();

    }

    public void onValueChanged()
    {

        if (field.text.Length < 8)
        {
            confirmationText.SetActive(true);
            join.interactable = false;
        }
        else
        {
            confirmationText.SetActive(false);
            join.interactable = true;
        }
    }





    public void JoinByRoomID()
    {
        GameManager.Instance.JoinedByID = true;
        GameManager.Instance.payoutCoins = 0;
        string roomID = field.text;

        RoomInfo[] rooms = PhotonNetwork.GetRoomList();

        Debug.Log("Rooms count: " + rooms.Length);

        if (rooms.Length == 0)
        {
            Debug.Log("no rooms!");
            failedDialog.SetActive(true);
        }
        else
        {
            bool foundRoom = false;
            for (int i = 0; i < rooms.Length; i++)
            {
                if (rooms[i].Name.Equals(roomID))
                {
                    foundRoom = true;
                    if (rooms[i].CustomProperties.ContainsKey("pc"))
                    {
                        GameManager.Instance.payoutCoins = int.Parse(rooms[i].CustomProperties["pc"].ToString());
                        //Debug.Log(int.Parse(Checkbalance));
                        //Debug.Log(int.Parse(rooms[i].CustomProperties["pc"].ToString()));
                        PlayerPrefs.SetInt("privatejoinbid", int.Parse(rooms[i].CustomProperties["pc"].ToString()));
                        PlayerPrefs.Save();

                        //Debug.Log(int.Parse(rooms[i].CustomProperties["pc"].ToString()));
                        //if (GameManager.Instance.myPlayerData.GetCoins() >= GameManager.Instance.payoutCoins)
                        if (GameManager.Instance.checkbalforplay >= GameManager.Instance.payoutCoins)
                        {
                            //  Debug.Log(GameManager.Instance.payoutCoins);
                            PhotonNetwork.JoinRoom(roomID);
                            StartCoroutine(SendbidAmount(int.Parse(rooms[i].CustomProperties["pc"].ToString())));
                            StartCoroutine(joinbyidtype(1));
                        }
                        else
                        {
                            GameManager.Instance.dialog.SetActive(true);
                        }
                        GameConfiguration.GetComponent<GameConfigrationController>().startGame();
                    }
                    else
                    {
                        GameManager.Instance.payoutCoins = int.MaxValue;
                        GameConfiguration.GetComponent<GameConfigrationController>().startGame();
                    }
                }
            }
            if (!foundRoom)
            {
                failedDialog.SetActive(true);
            }
        }


    }






    IEnumerator SendbidAmount(int bal)
    {

        form = new WWWForm();
        form.AddField("mobile", PlayerPrefs.GetString("mobileno"));
        form.AddField("bidamount", bal);

        WWW w = new WWW(StaticStrings.urlbid, form);
        yield return w;

        if (w.error != null)
        {
            Debug.Log("<color=red>" + w.text + "</color>");//error
        }
        else
        {
            if (w.isDone)
            {
                if (w.text.Contains("error"))
                {
                    Debug.Log("<color=red>" + w.text + "</color>");//error
                }
                else
                {
                    Debug.Log("<color=red>" + w.text + "</color>");//error
                }
            }
        }

        w.Dispose();
    }


    IEnumerator joinbyidtype(int gametype)
    {

        form = new WWWForm();
        form.AddField("mobile", PlayerPrefs.GetString("mobileno"));
        form.AddField("gametype", gametype);


        WWW w = new WWW(StaticStrings.gamejoinbyidtypcount, form);
        yield return w;

        if (w.error != null)
        {
            Debug.Log("<color=red>" + w.text + "</color>");//error
        }
        else
        {
            if (w.isDone)
            {
                if (w.text.Contains("error"))
                {
                    Debug.Log("<color=red>" + w.text + "</color>");//error
                }
                else
                {
                    Debug.Log("<color=red>" + w.text + "</color>");//error

                }
            }
        }

        w.Dispose();
    }


    public void Checkbalancecomplete()
    {
        StartCoroutine(CheckBalance());

    }


    IEnumerator CheckBalance()
    {

        form = new WWWForm();
        form.AddField("mobile", PlayerPrefs.GetString("mobileno"));
        //Debug.Log(PlayerPrefs.GetInt("mobileno"));
        WWW w = new WWW(StaticStrings.urlbal, form);
        yield return w;

        if (w.error != null)
        {
            Debug.Log("<color=red>" + w.text + "</color>");//error
        }
        else
        {
            if (w.isDone)
            {
                if (w.text.Contains("error"))
                {
                    Debug.Log("<color=red>" + w.text + "</color>");//error
                }
                else
                {
                    Checkbalance = Regex.Replace(w.text, @"\s+", "");
                    GameManager.Instance.checkbalforplay = int.Parse(Checkbalance);
                }
            }
        }

        w.Dispose();
    }
}
