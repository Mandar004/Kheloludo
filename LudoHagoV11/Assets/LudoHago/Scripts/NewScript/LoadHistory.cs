using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadHistory : MonoBehaviour
{

    public void LoadHistoryuser()
    {
        SceneManager.LoadScene("scenehistory");
    }

    
   public void Loadmenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
