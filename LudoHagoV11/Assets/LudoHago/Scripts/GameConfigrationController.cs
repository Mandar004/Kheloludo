using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using AssemblyCSharp;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class GameConfigrationController : MonoBehaviour
{

    public GameObject TitleText;
    public GameObject bidText;
    public GameObject MinusButton;
    public GameObject PlusButton;
    public GameObject[] Toggles;
    private int currentBidIndex = 0;
    private WWWForm form;
    private MyGameMode[] modes = new MyGameMode[] { MyGameMode.Classic, MyGameMode.Quick, MyGameMode.Master };
    public GameObject privateRoomJoin;
    public string Checkbalance;



    void OnEnable()
    {
        for (int i = 0; i < Toggles.Length; i++)
        {
            int index = i;
            Toggles[i].GetComponent<Toggle>().onValueChanged.AddListener((value) =>
            {
                ChangeGameMode(value, modes[index]);
            }
            );
        }

        currentBidIndex = 0;
        UpdateBid(true);

        Toggles[0].GetComponent<Toggle>().isOn = true;
        GameManager.Instance.mode = MyGameMode.Classic;

        switch (GameManager.Instance.type)
        {
            case MyGameType.TwoPlayer:
                TitleText.GetComponent<Text>().text = "Two Players";
                break;
            case MyGameType.FourPlayer:
                TitleText.GetComponent<Text>().text = "Four Players";
                break;
            case MyGameType.Private:
                TitleText.GetComponent<Text>().text = "Private Room";
                privateRoomJoin.SetActive(true);
                break;
            case MyGameType.Bid:
                TitleText.GetComponent<Text>().text = "Two Player ";
                //privateRoomJoin.SetActive(true);
                break;
            case MyGameType.Computer:
                TitleText.GetComponent<Text>().text = "Two Player with Computer";

                break;
        }
        InvokeRepeating("Checkbalancecomplete", 0.2f, 0.5f);
       

    }

    void OnDisable()
    {
        for (int i = 0; i < Toggles.Length; i++)
        {
            int index = i;
            Toggles[i].GetComponent<Toggle>().onValueChanged.RemoveAllListeners();
        }

        privateRoomJoin.SetActive(false);
        currentBidIndex = 0;
        UpdateBid(false);
        Toggles[0].GetComponent<Toggle>().isOn = true;
        Toggles[1].GetComponent<Toggle>().isOn = false;
        Toggles[2].GetComponent<Toggle>().isOn = false;

        CancelInvoke("Checkbalancecomplete");
    }



    private void Update()
    {
        //Checkbalance =  int.Parse(getbalvalue.GetComponent<Text>().text.ToString());
        //Checkbalancecomplete();
        // Debug.Log("bal"+Checkbalance);
    }

    public void setCreatedProvateRoom()
    {
        GameManager.Instance.JoinedByID = false;
    }

    public void setCreatedPrivateRoomBid()
    {

        //Debug.Log(GameManager.Instance.checkbalforplay);
        //if (GameManager.Instance.myPlayerData.GetCoins() >= GameManager.Instance.payoutCoins)
        if (GameManager.Instance.checkbalforplay >= GameManager.Instance.payoutCoins)
        {
            
            // Debug.Log(GameManager.Instance.checkbalforplay);
            GameManager.Instance.JoinedByID = false;

            GameManager.Instance.matchPlayerObject.GetComponent<SetMyData>().MatchPlayer();
            Debug.Log("setCreatedPrivateRoomBid Joined and created");
        }
    }

    public void startGamevsComputer()
    {

        GameManager.Instance.facebookManager.startRandomGamevscomputer();

    }


    public void startGame()
    {

        if (GameManager.Instance.checkbalforplay >= GameManager.Instance.payoutCoins)
        {
            Debug.Log(GameManager.Instance.checkbalforplay);
            //Debug.Log(Checkbalance);
            if (GameManager.Instance.type != MyGameType.Private)
            {
                GameManager.Instance.facebookManager.startRandomGame();
            }
            else
            {
                if (GameManager.Instance.JoinedByID)
                {
                    Debug.Log("Joined by id!");
                    GameManager.Instance.matchPlayerObject.GetComponent<SetMyData>().MatchPlayer();
                }

                else
                {
                    Debug.Log("Joined and created");
                    GameManager.Instance.playfabManager.CreatePrivateRoom();
                    GameManager.Instance.matchPlayerObject.GetComponent<SetMyData>().MatchPlayer();
                }

            }
        }
        else
        {
            //Debug.Log(Checkbalance);
            GameManager.Instance.dialog.SetActive(true);
        }
    }

    private void ChangeGameMode(bool isActive, MyGameMode mode)
    {
        if (isActive)
        {
            GameManager.Instance.mode = mode;
        }
    }



    public void IncreaseBid()
    {
        if (currentBidIndex < StaticStrings.bidValues.Length - 1)
        {
            currentBidIndex++;
            UpdateBid(true);
        }
    }

    public void DecreaseBid()
    {
        if (currentBidIndex > 0)
        {
            currentBidIndex--;
            UpdateBid(true);
        }
    }

    private void UpdateBid(bool changeBidInGM)
    {

        //if(GameManager.Instance.type== MyGameType.Computer)
        //{
        //    string curint = "0";
        //    StaticStrings.bidValuesStrings[currentBidIndex] = curint;
        //    bidText.GetComponent<Text>().text = StaticStrings.bidValuesStrings[currentBidIndex];
        //}
        //else
        //{
        bidText.GetComponent<Text>().text = StaticStrings.bidValuesStrings[currentBidIndex];
        //}


        if (changeBidInGM)
            GameManager.Instance.payoutCoins = StaticStrings.bidValues[currentBidIndex];
        PlayerPrefs.SetString("bidamount", StaticStrings.bidValues[currentBidIndex].ToString());
        PlayerPrefs.Save();
        //Debug.Log(PlayerPrefs.GetString("bidamount"));

        if (currentBidIndex == 0) MinusButton.GetComponent<Button>().interactable = false;
        else MinusButton.GetComponent<Button>().interactable = true;

        if (currentBidIndex == StaticStrings.bidValues.Length - 1) PlusButton.GetComponent<Button>().interactable = false;
        else PlusButton.GetComponent<Button>().interactable = true;
    }

    public void HideThisScreen()
    {
        gameObject.SetActive(false);
    }

    public void Sendbidamounttodbprivate()
    {

        StartCoroutine(SendPlayerGameCount("private"));

    }


    IEnumerator SendPlayerGameCount(string gametype)
    {

        form = new WWWForm();
        form.AddField("mobile", PlayerPrefs.GetString("mobileno"));
        form.AddField("gametype", gametype);

        // Debug.Log(PlayerPrefs.GetString("bidamount"));
        WWW w = new WWW(StaticStrings.gamecount, form);
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

                        Checkbalance = Regex.Replace(www.downloadHandler.text, @"\s+", "");
                        GameManager.Instance.checkbalforplay = int.Parse(Checkbalance);

                    }
                }
            }
        }



    }

}
