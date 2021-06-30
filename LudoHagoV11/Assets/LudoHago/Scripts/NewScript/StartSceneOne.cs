using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneOne : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene("LoginSplash");

    }

 
    //IEnumerator wait()
    //{
        //yield return new WaitForSeconds(0.2f);
       // SceneManager.LoadScene("LoginSplash");
       
   // }

}
