
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Logout : MonoBehaviour
{
   
    public void LogoutGame()
    {
        PlayerPrefs.SetString("Logout", "Logout");
        PlayerPrefs.Save();
        if (PlayerPrefs.HasKey("Login"))
        {
            PlayerPrefs.DeleteKey("Login");
        }
        if (PlayerPrefs.HasKey("mobileno"))
        {
            PlayerPrefs.DeleteKey("mobileno");
        }

        if (PlayerPrefs.HasKey("Welcome"))
        {
            PlayerPrefs.DeleteKey("Welcome");
        }
        GameManager.Instance.playfabManager.destroy();
        GameManager.Instance.facebookManager.destroy();
        GameManager.Instance.connectionLost.destroy();
        GameManager.Instance.avatarMy = null;
        GameManager.Instance.logged = false;
        GameManager.Instance.resetAllData();
        PhotonNetwork.Disconnect();
       

    }
    public void LoginloadloginScene()
    {
       

        SceneManager.LoadScene("Sceneone");
    }
   


}
