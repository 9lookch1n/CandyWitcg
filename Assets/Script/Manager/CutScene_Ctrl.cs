using System.Collections;
using UnityEngine;

public class CutScene_Ctrl : MonoBehaviour
{
    public GameObject ui_Tutorial;
    public GameObject BttSkip;
    public GameObject CutScene;

    void Start()
    {
        //StartCoroutine(ShowTutorial(10.0f));
        StartCoroutine(ShowBttSkip(5.0f));
    }
    public void PressSkipBtt()
    {
        if (SoundEffect_Ctrl.soundEffect.sfxToggle == true)
        {
            SoundEffect_Ctrl.soundEffect.Audio.PlayOneShot(SoundEffect_Ctrl.soundEffect.Click);
        }
        ui_Tutorial.SetActive(true);
        BttSkip.SetActive(false);
    }
    IEnumerator ShowTutorial(float duration)
    {
        yield return new WaitForSeconds(duration);
        ui_Tutorial.SetActive(true);
        BttSkip.SetActive(false);
    }
    IEnumerator ShowBttSkip(float duration)
    {
        yield return new WaitForSeconds(duration);
        BttSkip.SetActive(true);
    }
}
