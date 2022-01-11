using UnityEngine;

public class SettingCtrl : MonoBehaviour
{
    public GameObject panelSetting;
    public int counter = 0;

    public void ChangePanel()
    {
        if (SoundEffect_Ctrl.soundEffect.sfxToggle == true)
        {
            SoundEffect_Ctrl.soundEffect.Audio.PlayOneShot(SoundEffect_Ctrl.soundEffect.Click);
        }

        counter++;
        if (counter % 2 == 1)
        {
            panelSetting.SetActive(true);
        }
        else
        {
            panelSetting.SetActive(false);
        }
    }
}
