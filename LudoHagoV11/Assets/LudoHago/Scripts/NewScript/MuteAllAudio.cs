using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteAllAudio : MonoBehaviour
{
    private bool muted;
    public GameObject MuteBtn;
    public GameObject SoundBtn;



    private void Start()
    {
        PlayerPrefs.SetInt("MuteAudio", 1);
    }

    void Update()
    {
        
        if (PlayerPrefs.GetInt("MuteAudio") == 0)
        {
           
            MuteBtn.SetActive(true);
            SoundBtn.SetActive(false);
            EnableAudio();

        }
        
        else if(PlayerPrefs.GetInt("MuteAudio") == 1)
        {
         
            SoundBtn.SetActive(true);
            MuteBtn.SetActive(false);
            DisableAudio();

        }
        else
        {
           
            SoundBtn.SetActive(true);
            MuteBtn.SetActive(false);
            DisableAudio();

        }


    }

    public void GetAudioButtonDown()
    {
            ToggleAudio();
    }

    public void DisableAudio()
    {
        SetAudioMute(false);
    }

    public void EnableAudio()
    {
        SetAudioMute(true);
    }

    public void ToggleAudio()
    {
        if (muted)
            DisableAudio();
        else
            EnableAudio();
    }

    private void SetAudioMute(bool mute)
    {
        AudioSource[] sources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        for (int index = 0; index < sources.Length; ++index)
        {
            sources[index].mute = mute;
        }
        muted = mute;
    }


    public void SetAudioListnerFalse()
    {
        PlayerPrefs.SetInt("MuteAudio", 0);
    }
    public void SetAudioListnerTrue()
    {

        PlayerPrefs.SetInt("MuteAudio", 1);
    }
   

}
