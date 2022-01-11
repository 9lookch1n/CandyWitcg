using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start_Ctrl : MonoBehaviour
{
    public GameObject panel_HighScore;

    public void PressStart()
    {
        if (SoundEffect_Ctrl.soundEffect.sfxToggle == true)
        {
            SoundEffect_Ctrl.soundEffect.Audio.PlayOneShot(SoundEffect_Ctrl.soundEffect.Click);
        }

        SceneManager.LoadScene("CutScene");

    }
    public void PressRank()
    {
        if (SoundEffect_Ctrl.soundEffect.sfxToggle == true)
        {
            SoundEffect_Ctrl.soundEffect.Audio.PlayOneShot(SoundEffect_Ctrl.soundEffect.Click);
        }

        panel_HighScore.SetActive(true);

    }
    public void PressBackRank()
    {
        if (SoundEffect_Ctrl.soundEffect.sfxToggle == true)
        {
            SoundEffect_Ctrl.soundEffect.Audio.PlayOneShot(SoundEffect_Ctrl.soundEffect.Click);
        }

        panel_HighScore.SetActive(false);

    }
}
