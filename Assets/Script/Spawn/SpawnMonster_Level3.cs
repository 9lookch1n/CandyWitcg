using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpawnMonster_Level3 : MonoBehaviour
{
    public Transform[] spawnPoints;

    [Header("==============================================")]
    public List<GameObject> monsters = new List<GameObject>();
    public List<GameObject> monsters_ = new List<GameObject>();


    GameObject current;
    [Header("==============================================")]
    public GameObject HandLeft;
    public GameObject HandRight;
    int randomSpawnPoint, randomMonster;

    public bool spawnAllowed = false;

    public Animator animBoss;
    public PlayerCtrl player;
    public GameManager gameManager;

    public GameObject CutScene_3;
    public GameObject UIWin;

    void Start()
    {

        Invoke("SpawnMonster", 2);
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }


    public void SpawnMonster()
    {
        animBoss.SetInteger("Idle", 0);
        if (spawnAllowed)
        {
            randomSpawnPoint = Random.Range(0, spawnPoints.Length);
            randomMonster = Random.Range(0, monsters.Count);

            if (monsters_.Count == 0)
            {
                HandLeft.SetActive(false);
                HandRight.SetActive(false);
                gameManager.gameFinish = true;

                if (SoundEffect_Ctrl.soundEffect.sfxToggle == true)
                {
                    SoundEffect_Ctrl.soundEffect.Audio.PlayOneShot(SoundEffect_Ctrl.soundEffect.Wing);
                }

                player.anim.SetInteger("Win", 1);
                animBoss.SetInteger("Dead", 1);

                StartCoroutine(check_3(10.0f));
            }
            else if (monsters.Count > 0)
            {
                Instantiate(monsters[randomMonster], spawnPoints[randomSpawnPoint].position, Quaternion.identity);
                current = monsters[randomMonster];
                monsters.Remove(current);
                animBoss.SetInteger("Attack", 1);
            }
            else if (monsters.Count <= 0)
            {
                Instantiate(monsters_[randomMonster], spawnPoints[randomSpawnPoint].position, Quaternion.identity);
                current = monsters_[randomMonster];
                monsters_.Remove(current);
                animBoss.SetInteger("Attack", 1);
            }

        }
    }
    IEnumerator check_3(float sec)
    {
        StartCoroutine(UiWinLevel3(3f));
        yield return new WaitForSeconds(sec);

        if (SoundEffect_Ctrl.soundEffect.sfxToggle == true)
        {
            SoundEffect_Ctrl.soundEffect.Audio.PlayOneShot(SoundEffect_Ctrl.soundEffect.Win);
        }

        CutScene_3.SetActive(false);
        UIWin.SetActive(true);


    }
    private IEnumerator UiWinLevel3(float duration)
    {
        //Scene Level 3
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Game_Level3"))
        {
            if (gameManager.gameFinish)
            {
                if (SoundEffect_Ctrl.soundEffect.sfxToggle == true)
                {
                    SoundEffect_Ctrl.soundEffect.Audio.PlayOneShot(SoundEffect_Ctrl.soundEffect.Boss_Dead);
                }
                yield return new WaitForSeconds(duration);
                CutScene_3.SetActive(true);
            }
        }
    }

}
