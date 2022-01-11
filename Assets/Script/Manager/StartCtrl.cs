using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Skip_Ctrl : MonoBehaviour
{

    public GameObject ui_Tutorial;
    public GameObject BttSkip;

    public void PressSkipBtt()
    {
        ui_Tutorial.SetActive(true);
        BttSkip.SetActive(false);
    }
}
