using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Music_Button : MonoBehaviour
{
    public static Music_Button BG_music;
    public Toggle UI_Music;

    public bool musicPlay = true;
    private void Start()
    {
        if (Music_Ctrl.BG_music.Audio.mute == true)
        {
            UI_Music.GetComponent<Toggle>().isOn = true;
        }
        else
        {
            UI_Music.GetComponent<Toggle>().isOn = false;
        }


    }
    public void MusicToggle()
    {

        if (Music_Ctrl.BG_music.Audio.isPlaying)
        {
            musicPlay = false;
            //ปิดเพลง
            Music_Ctrl.BG_music.Audio.Pause();
            Music_Ctrl.BG_music.Audio.mute = true;
            //icon ปิด
            UI_Music.GetComponent<Toggle>().isOn = true;

            if (SoundEffect_Ctrl.soundEffect.sfxToggle == true)
            {
                SoundEffect_Ctrl.soundEffect.Audio.PlayOneShot(SoundEffect_Ctrl.soundEffect.Click);
            }

        }
        else
        {
            musicPlay = true;
            //เปิดเพลง
            Music_Ctrl.BG_music.Audio.Play();
            Music_Ctrl.BG_music.Audio.mute = false;
            //icon เปิด
            UI_Music.GetComponent<Toggle>().isOn = false;

            if (SoundEffect_Ctrl.soundEffect.sfxToggle == true)
            {
                SoundEffect_Ctrl.soundEffect.Audio.PlayOneShot(SoundEffect_Ctrl.soundEffect.Click);
            }
        }
    }
}
