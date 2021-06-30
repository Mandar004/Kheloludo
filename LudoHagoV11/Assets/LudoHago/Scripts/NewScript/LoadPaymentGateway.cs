using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadPaymentGateway : MonoBehaviour
{
 
    public void LoadBackMenumenu()
    {
       
         SceneManager.LoadScene("Menuscene");
    }
    public void LoadPaymentGatewayLevel()
    {

        SceneManager.LoadScene("PaymentGateway");
    }
}
