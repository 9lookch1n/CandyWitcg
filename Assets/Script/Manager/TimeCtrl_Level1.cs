using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeCtrl_Level1 : MonoBehaviour
{
    public float currentTime = 0f;
    public float startingTime = 10f;

    [SerializeField] Text time;
    public PlayerCtrl playerctrl;
    public GameManager gameManager;
    public Manager manager;
    public GameObject UIWin;
    public SpawnPoint spawnPoint, spawnPoint_2;

    bool playAudio = true;

    void Start()
    {
        currentTime = startingTime;
        StartCoroutine(check(0.0f));

    }

    IEnumerator check(float sec)
    {
        while (currentTime >= -3f)
        {
            yield return new WaitForSeconds(sec);
        }
        StartCoroutine(UIWinShow(0f));
    }

    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        time.text = currentTime.ToString("0");

        //Scene Level 1
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Game"))
        {
            if (currentTime >= 64f)
            {
                spawnPoint.spawnAllowed = false;
                spawnPoint_2.spawnAllowed = false;
            }
            else
            {
                spawnPoint.spawnAllowed = true;
                spawnPoint_2.spawnAllowed = true;
            }
            if (currentTime <= 45 && playerctrl.hps == true)
            {
                playerctrl.heartUI.SetActive(true);
            }
            if (currentTime <= 5f)
            {
                spawnPoint.spawnAllowed = false;
                spawnPoint_2.spawnAllowed = false;
            }
            if (currentTime <= 0)
            {
                if (playAudio && SoundEffect_Ctrl.soundEffect.sfxToggle == true)
                {
                    SoundEffect_Ctrl.soundEffect.Audio.PlayOneShot(SoundEffect_Ctrl.soundEffect.Wing);
                    playAudio = false;
                }
                playerctrl.anim.SetInteger("Win", 1);
            }
            if (currentTime <= -3)
            {
                gameManager.gameFinish = true;

            }
        }

        //Scene Level 2
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Game_Level2"))
        {
            //Set Spawn Monster
            if (currentTime >= 55f)
            {
                //Set Spawn Monster false
                spawnPoint.spawnAllowed = false;
                spawnPoint_2.spawnAllowed = false;
            }
            else
            {
                //Set Spawn Monster true
                spawnPoint.spawnAllowed = true;
                spawnPoint_2.spawnAllowed = true;
            }
            if (playerctrl.hps == true && manager.boltDraw == false)
            {
                manager.boltDraw = true;
                playerctrl.BoltUI.SetActive(false);
            }
            if (currentTime >= 30.0f && currentTime <= 31f)
            {
                manager.boltDraw = false;
            }
            //Set boltDraw Can Draw
            if (currentTime <= 30 && manager.boltDraw == false)
            {
                //Set Animation Cat-Bolt
                playerctrl.bolt = true;
                //Show UI Bolt
                playerctrl.BoltUI.SetActive(true);
            }
            //Time 40-- && Cant Draw
            else if (currentTime <= 30 && manager.boltDraw == true)
            {
                //Set UI off
                playerctrl.BoltUI.SetActive(false);
            }
            else if (currentTime <= 30 && playerctrl.addHpPlayer == true)
            {
                playerctrl.BoltUI.SetActive(false);
                manager.boltDraw = true;
            }
            //Set boltDraw Can Draw 2
            if (currentTime >= 17.0f && currentTime <= 18f)
            {
                manager.boltDraw = false;
                playerctrl.bolt = false;

            }
            else if (currentTime <= 15 && manager.boltDraw == false)
            {
                //Set Animation Cat-Bolt
                playerctrl.bolt = true;
                //Show UI Bolt
                playerctrl.BoltUI.SetActive(true);
            }
            //Time 15-- && Cant Draw
            else if (currentTime <= 15 && manager.boltDraw == true)
            {
                //Set UI off
                playerctrl.BoltUI.SetActive(false);
            }

            //Off Spawn
            if (currentTime <= 5f)
            {
                spawnPoint.spawnAllowed = false;
                spawnPoint_2.spawnAllowed = false;
            }
            if (currentTime <= -1.5f)
            {
                if (playAudio && SoundEffect_Ctrl.soundEffect.sfxToggle == true)
                {
                    SoundEffect_Ctrl.soundEffect.Audio.PlayOneShot(SoundEffect_Ctrl.soundEffect.Wing);
                    playAudio = false;
                }
                playerctrl.anim.SetInteger("Win", 1);
            }
            if (currentTime <= -3)
            {
                gameManager.gameFinish = true;
            }
        }

        //Scene Level 3
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Game_Level3"))
        {
            if (playerctrl.hps == true && manager.boltDraw == false)
            {
                manager.boltDraw = true;
                playerctrl.BoltUI.SetActive(false);
            }

            if (currentTime >= 65.0f && currentTime <= 66f)
            {
                manager.boltDraw = false;
                manager.loopDraw = false;

            }
            //Set boltDraw Can Draw 50s
            if (currentTime <= 60 && manager.boltDraw == false)
            {
                //Set Animation Cat-Bolt
                playerctrl.bolt = true;
                //Show UI Bolt
                playerctrl.BoltUI.SetActive(true);
            }
            //Time 50s-- && Cant Draw
            else if (currentTime <= 60 && manager.boltDraw == true)
            {
                //Set UI off
                playerctrl.BoltUI.SetActive(false);
            }
            else if (currentTime <= 60 && playerctrl.hps == true)
            {
                playerctrl.BoltUI.SetActive(false);
                manager.boltDraw = true;
            }

            //Line Loop - 1
            if (currentTime >= 50.0f && currentTime <= 51.0f)
            {
                playerctrl.BoltUI.SetActive(false);
                manager.boltDraw = true;

                playerctrl.loop = true;
                playerctrl.loopUI.SetActive(true);
            }
            else if (currentTime <= 50.0f && manager.loopDraw == true)
            {
                playerctrl.loopUI.SetActive(false);
            }
            else if (currentTime <= 50.0f && playerctrl.hps == true)
            {
                playerctrl.loopUI.SetActive(false);
                manager.loopDraw = true;
            }

            //Set boltDraw Can Draw 2
            if (currentTime >= 40.0f && currentTime <= 41f)
            {
                playerctrl.loopUI.SetActive(false);
                manager.loopDraw = true;

                manager.boltDraw = false;
                playerctrl.bolt = false;

            }
            else if (currentTime <= 40 && manager.boltDraw == false)
            {
                //Set Animation Cat-Bolt
                playerctrl.bolt = true;
                //Show UI Bolt
                playerctrl.BoltUI.SetActive(true);
            }
            //Time 30-- && Cant Draw
            else if (currentTime <= 40 && manager.boltDraw == true)
            {
                //Set UI off
                playerctrl.BoltUI.SetActive(false);
            }

            //Line Loop - 1
            if (currentTime >= 30.0f && currentTime <= 31.0f)
            {
                playerctrl.BoltUI.SetActive(false);
                manager.boltDraw = true;
                manager.loopDraw = false;

                playerctrl.loop = true;
                playerctrl.loopUI.SetActive(true);
            }
            else if (currentTime <= 30.0f && manager.loopDraw == true)
            {
                playerctrl.loopUI.SetActive(false);
            }
            else if (currentTime <= 30.0f && playerctrl.hps == true)
            {
                playerctrl.loopUI.SetActive(false);
                manager.loopDraw = true;
            }

            if (currentTime <= 19.0f)
            {
                playerctrl.BoltUI.SetActive(false);
                manager.boltDraw = true;

                playerctrl.loopUI.SetActive(false);
                manager.loopDraw = true;
            }

        }
    }

    private IEnumerator UIWinShow(float duration)
    {
        //Scene Level 1
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Game"))
        {
            if (gameManager.gameFinish)
            {
                playerctrl.CanNextLevel = true;

                Destroy(GameObject.FindGameObjectWithTag("Monster_Horizontal"));
                Destroy(GameObject.FindGameObjectWithTag("Monster_Vertical"));

                spawnPoint.spawnAllowed = false;
                spawnPoint_2.spawnAllowed = false;

                yield return new WaitForSeconds(duration);

                if (SoundEffect_Ctrl.soundEffect.sfxToggle == true)
                {
                    SoundEffect_Ctrl.soundEffect.Audio.PlayOneShot(SoundEffect_Ctrl.soundEffect.Win);
                }
                UIWin.SetActive(true);


            }
        }

        //Scene Level 2
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Game_Level2"))
        {
            if (gameManager.gameFinish)
            {
                playerctrl.CanNextLevel = true;

                Destroy(GameObject.FindGameObjectWithTag("Monster_Right"));
                Destroy(GameObject.FindGameObjectWithTag("Monster_Left"));

                spawnPoint.spawnAllowed = false;
                spawnPoint_2.spawnAllowed = false;

                if (SoundEffect_Ctrl.soundEffect.sfxToggle == true)
                {
                    SoundEffect_Ctrl.soundEffect.Audio.PlayOneShot(SoundEffect_Ctrl.soundEffect.Win);
                }

                yield return new WaitForSeconds(duration);
                UIWin.SetActive(true);
            }
        }




    }
}

