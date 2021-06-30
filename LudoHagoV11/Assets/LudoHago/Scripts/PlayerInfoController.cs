using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using AssemblyCSharp;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PlayerInfoController : MonoBehaviour
{

    public GameObject window;

    public GameObject avatar;
    public GameObject playername;

    public Sprite avatarSprite;

    public GameObject TotalEarningsValue;
    public GameObject CurrentMoneyValue;
    public GameObject GamesWonValue;
    public GameObject WinRateValue;
    public GameObject TwoPlayerWinsValue;
    public GameObject FourPlayerWinsValue;
    public GameObject FourPlayerWinsText;
    public GameObject GamesPlayedValue;
    private int index;
    public Sprite defaultAvatar;
    private WWWForm form;
    public GameObject addFriendButton;
    public GameObject editProfileButton;
    public GameObject EditButton;
    public UpdateCoinsFrameValue updatecoin;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        if (!StaticStrings.isFourPlayerModeEnabled)
        {
            FourPlayerWinsValue.SetActive(false);
            FourPlayerWinsText.SetActive(false);
        }

        defaultAvatar = avatar.GetComponent<Image>().sprite;
        InvokeRepeating("Checkbalancecomplete", 1f, 1f);
        InvokeRepeating("CheckTotalWinningAmountuser", 1f, 1f);
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
                        CurrentMoneyValue.GetComponent<Text>().text = Regex.Replace(balString, @"\s+", "");
                    }
                }
            }
        }



    }




    public void CheckTotalWinningAmountuser()
    {
        StartCoroutine(CheckTotalWinningAmount());

    }
    IEnumerator CheckTotalWinningAmount()
    {

        form = new WWWForm();
        form.AddField("mobile", PlayerPrefs.GetString("mobileno"));

        WWW w = new WWW(StaticStrings.totalwinningamount, form);
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
                    string balString = w.text;
                    TotalEarningsValue.GetComponent<Text>().text = Regex.Replace(balString, @"\s+", "");

                }
            }
        }

        w.Dispose();
    }

    public void ShowPlayerInfo(int index)
    {
        this.index = index;
        window.SetActive(true);

        if (index == 0)
        {
            FillData(GameManager.Instance.avatarMy, GameManager.Instance.nameMy, GameManager.Instance.myPlayerData);
            addFriendButton.SetActive(false);
            editProfileButton.SetActive(true);
        }
        else
        {
            addFriendButton.SetActive(true);
            editProfileButton.SetActive(false);
            Debug.Log("Player info " + index);

            FillData(GameManager.Instance.playerObjects[index].avatar, GameManager.Instance.playerObjects[index].name, GameManager.Instance.playerObjects[index].data);
        }
    }

    public void ShowPlayerInfo(Sprite avatarSprite, string name, MyPlayerData data)
    {
        editProfileButton.SetActive(false);
        addFriendButton.SetActive(true);

        window.SetActive(true);

        FillData(avatarSprite, name, data);
    }



    public void FillData(Sprite avatarSprite, string name, MyPlayerData data)
    {

        if (avatarSprite == null)
        {
            avatar.GetComponent<Image>().sprite = defaultAvatar;
        }
        else
        {
            avatar.GetComponent<Image>().sprite = avatarSprite;
        }

        playername.GetComponent<Text>().text = name;
        //TotalEarningsValue.GetComponent<Text>().text = data.GetTotalEarnings().ToString();
        GamesPlayedValue.GetComponent<Text>().text = data.GetPlayedGamesCount().ToString();
        //CurrentMoneyValue.GetComponent<Text>().text = data.GetCoins().ToString();
        
        GamesWonValue.GetComponent<Text>().text = (data.GetTwoPlayerWins() + data.GetFourPlayerWins()).ToString();
        float gamesWon = (data.GetTwoPlayerWins() + data.GetFourPlayerWins());
        Debug.Log("WON: " + gamesWon);
        Debug.Log("played: " + data.GetPlayedGamesCount());
        //PlayerPrefs.SetString("totalgameplayed", data.GetPlayedGamesCount().ToString());
        if (data.GetPlayedGamesCount() != 0 && gamesWon != 0)
        {
            WinRateValue.GetComponent<Text>().text = Mathf.RoundToInt((gamesWon / data.GetPlayedGamesCount() * 100)).ToString() + "%";
        }
        else
        {
            WinRateValue.GetComponent<Text>().text = "0%";
        }
        TwoPlayerWinsValue.GetComponent<Text>().text = data.GetTwoPlayerWins().ToString();
        FourPlayerWinsValue.GetComponent<Text>().text = data.GetFourPlayerWins().ToString();

    }
}
