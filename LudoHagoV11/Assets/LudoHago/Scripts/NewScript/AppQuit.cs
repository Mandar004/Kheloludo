using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppQuit : MonoBehaviour
{

    public GameObject quitScreen;
    // Start is called before the first frame update
    void Start()
    {
        quitScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            quitScreen.SetActive(true);
    }  

    public void ScreenQuit()
        {
            Application.Quit();
        }
    
}
