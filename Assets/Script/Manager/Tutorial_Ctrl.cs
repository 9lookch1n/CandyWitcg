using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_Ctrl : MonoBehaviour
{
    public GameObject page_1;
    public GameObject page_2;
    public GameObject page_3;
    public GameObject BttPlay;

    public void Btt_toPageTwo()
    {
        if (SoundEffect_Ctrl.soundEffect.sfxToggle == true)
        {
            SoundEffect_Ctrl.soundEffect.Audio.PlayOneShot(SoundEffect_Ctrl.soundEffect.Click);
        }
        page_1.SetActive(false);
        page_2.SetActive(true);
        page_3.SetActive(false);
    }
    public void Btt_backToPageOne()
    {
        if (SoundEffect_Ctrl.soundEffect.sfxToggle == true)
        {
            SoundEffect_Ctrl.soundEffect.Audio.PlayOneShot(SoundEffect_Ctrl.soundEffect.Click);
        }
        page_1.SetActive(true);
        page_2.SetActive(false);
        page_3.SetActive(false);
    }    
    public void Btt_toPageThree()
    {
        if (SoundEffect_Ctrl.soundEffect.sfxToggle == true)
        {
            SoundEffect_Ctrl.soundEffect.Audio.PlayOneShot(SoundEffect_Ctrl.soundEffect.Click);
        }
        page_1.SetActive(false);
        page_2.SetActive(false);
        page_3.SetActive(true);
        BttPlay.SetActive(true);
    }
    public void Btt_backToPageTwo()
    {
        if (SoundEffect_Ctrl.soundEffect.sfxToggle == true)
        {
            SoundEffect_Ctrl.soundEffect.Audio.PlayOneShot(SoundEffect_Ctrl.soundEffect.Click);
        }
        page_1.SetActive(false);
        page_2.SetActive(true);
        page_3.SetActive(false);
    }
}
