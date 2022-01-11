using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GestureRecognizer
{
    public class PauseCtrl : MonoBehaviour
    {
        public GameObject UI_Pause;
        public GameObject UI_Totorial_Level2;
        public GameObject UI_Totorial_Level3;

        public void PauseGame()
        {
            if (SoundEffect_Ctrl.soundEffect.sfxToggle == true)
            {
                SoundEffect_Ctrl.soundEffect.Audio.PlayOneShot(SoundEffect_Ctrl.soundEffect.Click);
            }
            
            Time.timeScale = 0;
            UI_Pause.SetActive(true);
        }

        public void RestartLevel_1()
        {
            if (SoundEffect_Ctrl.soundEffect.sfxToggle == true)
            {
                SoundEffect_Ctrl.soundEffect.Audio.PlayOneShot(SoundEffect_Ctrl.soundEffect.Click);
            }

            SceneManager.LoadScene("Game");
            Time.timeScale = 1;
            
        }
        public void RestartLevel_2()
        {
            if (SoundEffect_Ctrl.soundEffect.sfxToggle == true)
            {
                SoundEffect_Ctrl.soundEffect.Audio.PlayOneShot(SoundEffect_Ctrl.soundEffect.Click);
            }

            SceneManager.LoadScene("Game_Level2");
            Time.timeScale = 1;
        }
        public void RestartLevel_3()
        {
            if (SoundEffect_Ctrl.soundEffect.sfxToggle == true)
            {
                SoundEffect_Ctrl.soundEffect.Audio.PlayOneShot(SoundEffect_Ctrl.soundEffect.Click);
            }

            SceneManager.LoadScene("Game_Level3");
            Time.timeScale = 1;
        }
        public void Resume()
        {
            if (SoundEffect_Ctrl.soundEffect.sfxToggle == true)
            {
                SoundEffect_Ctrl.soundEffect.Audio.PlayOneShot(SoundEffect_Ctrl.soundEffect.Click);
            }
            Time.timeScale = 1;
            UI_Pause.SetActive(false);
        }
        public void BackHome()
        {
            if (SoundEffect_Ctrl.soundEffect.sfxToggle == true)
            {
                SoundEffect_Ctrl.soundEffect.Audio.PlayOneShot(SoundEffect_Ctrl.soundEffect.Click);
            }

            Time.timeScale = 1;
            SceneManager.LoadScene("StartScene");
        }
        public void NexttoLevel_2()
        {
            if (SoundEffect_Ctrl.soundEffect.sfxToggle == true)
            {
                SoundEffect_Ctrl.soundEffect.Audio.PlayOneShot(SoundEffect_Ctrl.soundEffect.Click);
            }

            UI_Totorial_Level2.SetActive(true);

            //SceneManager.LoadScene("Game_Level2");
        }
        public void NexttoLevel_3()
        {
            if (SoundEffect_Ctrl.soundEffect.sfxToggle == true)
            {
                SoundEffect_Ctrl.soundEffect.Audio.PlayOneShot(SoundEffect_Ctrl.soundEffect.Click);
            }

            UI_Totorial_Level3.SetActive(true);

            //SceneManager.LoadScene("Game_Level3");
        }
    }
}


