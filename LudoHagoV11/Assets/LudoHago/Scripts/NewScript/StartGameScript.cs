using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameScript : MonoBehaviour
{
    public GameObject LoginCanvas;
    public GameObject RegisterCanvas;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("MY START SCRIPT");
        if (PlayerPrefs.HasKey("register"))
        {
            //Debug.Log(PlayerPrefs.HasKey("register"));
            LoginCanvas.SetActive(true);
        }
        else
        {
            RegisterCanvas.SetActive(true);

        }
       
        
    }


}
