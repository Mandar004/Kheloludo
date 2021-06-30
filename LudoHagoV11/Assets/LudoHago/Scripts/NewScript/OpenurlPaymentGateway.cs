using AssemblyCSharp;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenurlPaymentGateway : MonoBehaviour
{
    public void Openpaymentgateway()
    {
      
        Application.OpenURL(StaticStrings.paymentgateway); 
       // Application.OpenURL("https://hogotickmadeinindialudo.online/LudoHago/game/");
    }
}
