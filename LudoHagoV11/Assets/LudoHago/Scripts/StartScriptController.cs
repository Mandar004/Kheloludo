
using UnityEngine;


public class StartScriptController : MonoBehaviour
{

    public GameObject splashCanvas;
    public GameObject LoginCanvas;

    public GameObject menuCanvas;
    public GameObject[] go;

    public GameObject fbButton;

    public GameObject fbLoginCoinText;
    public GameObject guestLoginCoinText;
    public GameObject Welcomecanvas;
    // Use this for initialization
    void Start()
    {
        if (PlayerPrefs.HasKey("Logout"))
        {
            Debug.Log(PlayerPrefs.GetString("Logout"));

        }
        Debug.Log(PlayerPrefs.GetString("mobileno"));
        Debug.Log(PlayerPrefs.GetString("Welcome"));
        //fbLoginCoinText.GetComponent<Text>().text = StaticStrings.initCoinsCountFacebook.ToString();
        //guestLoginCoinText.GetComponent<Text>().text = StaticStrings.initCoinsCountGuest.ToString();
        //string mobileno = PlayerPrefs.GetString("mobileno");
        if (PlayerPrefs.HasKey("Logout")){
            LoginCanvas.SetActive(true);
          
        }

         if (PlayerPrefs.HasKey("Login") && PlayerPrefs.HasKey("mobileno") )
        {
            if (PlayerPrefs.HasKey("Welcome"))
            {
                splashCanvas.SetActive(true);
            }
            else
            {
                Welcomecanvas.SetActive(true);
            }
           
        }
        else
        {
            LoginCanvas.SetActive(true);
        }

        Debug.Log("START SCRIPT");

#if UNITY_WEBGL
        fbButton.SetActive(false);
#endif
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void HideAllElements()
    {
        menuCanvas.SetActive(true);
    }
}
