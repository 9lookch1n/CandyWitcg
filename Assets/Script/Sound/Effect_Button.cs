using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Effect_Button : MonoBehaviour
{
    public Toggle UI_SFX;

    private void Start()
    {
        //SFX
        if (SoundEffect_Ctrl.soundEffect.sfxToggle == true)
        {
            UI_SFX.GetComponent<Toggle>().isOn = false;
        }
        else
        {
            UI_SFX.GetComponent<Toggle>().isOn = true;
        }
    }
    public void SfxToggle()
    {
        if (SoundEffect_Ctrl.soundEffect.sfxToggle == true)
        {
            //ปิดsfx
            SoundEffect_Ctrl.soundEffect.sfxToggle = false;
            //icon ปิด
            UI_SFX.GetComponent<Toggle>().isOn = true;
        }
        else
        {
            //เปิดsfx
            SoundEffect_Ctrl.soundEffect.sfxToggle = true;
            //icon เปิด
            UI_SFX.GetComponent<Toggle>().isOn = false;
        }
    }
}
