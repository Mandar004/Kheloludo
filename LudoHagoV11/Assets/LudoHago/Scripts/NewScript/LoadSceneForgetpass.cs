using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneForgetpass : MonoBehaviour
{
    // Start is called before the first frame update
    public void loadforgetpassword()
    {
        SceneManager.LoadScene("Forgetpassword");
    }


    public void Loadlogin()
    {
        SceneManager.LoadScene("LoginSplash");
    }
    public void Loadpaymentgateway()
    {
        SceneManager.LoadScene("paymentgateway");
    }
    public void LoadMenuScene()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
