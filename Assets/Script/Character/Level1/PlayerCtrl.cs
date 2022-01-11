using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerCtrl : MonoBehaviour
{
    [Header("HP Settings")]
    public int hp = 3;
    public GameObject[] heart;
    public GameObject heartUI;
    public GameObject BoltUI;
    public GameObject loopUI;
    public GameObject BoltBoarder;
    public GameObject LoopBoarder;
    public bool hps = false;
    public bool addHpPlayer = false;

    [Header("Animator")]
    public Animator anim;
    public Animator HeartAnim;
    public Animator Heart_2Anim;
    public Animator Heart_3Anim;

    [Header("UI")]
    public GameObject UIWin;
    public GameObject UILose;
    public GameObject UIHeal;
    public GameObject AnimHearrt;
    public GameObject UIAttack;
    public GameObject UIAttack_2;
    public GameObject UIAttack_3;


    [Header("Script")]
    public GameManager gameManager;
    public Manager manager;
    public SpawnPoint spawnPoint,spawnPoint_2;
    public TimeCtrl_Level1 timeCtrl;

    [Header("ETC")]
    public bool CanNextLevel = false;
    public int id;
    public bool bolt = false;
    public bool loop = false;

    bool playAudio = true;
    bool playAudio_2 = true;

    public Animator catAnim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        //Animation_Player
        if (id == 1)
        {
            anim.Play("Player_Draw_Vertical", 0);
            id = 0;
        }
        if (id == 2)
        {
            anim.Play("Player_Draw_Horizontal", 0);
            id = 0;
        }
        if (id == 3)
        {
            anim.Play("Player_Draw_Left", 0);
            id = 0;
        }
        if (id == 4)
        {
            anim.Play("Player_Draw_Right", 0);
            id = 0;
        }
        if (id == 5)
        {
            anim.Play("Player_Draw_Heart", 0);
            id = 0;
        }
        if (id == 6)
        {
            anim.Play("Player_Draw_Bolt", 0);
            BoltBoarder.SetActive(true);
            BoltUI.SetActive(false);
            StartCoroutine(UI_BoltBoarder(1f));
            id = 0;
        }
        if (id == 7)
        {
            anim.Play("Player_Draw_Payu", 0);
            LoopBoarder.SetActive(true);
            loopUI.SetActive(false);
            StartCoroutine(UI_Loop(1f));
            id = 0;
        }
        if (hps == true)
        {
            heartUI.SetActive(true);
            catAnim.Play("Cat_Heart", 0);
        }
        if (manager.boltDraw == false && bolt == true)
        {
            catAnim.Play("Cat_Bolt", 0);
        }
        if (manager.loopDraw == false && loop == true)
        {
            catAnim.Play("Cat_Payu_2", 0);
        }


        //-- HP ------
        if (manager.addHp)//true
        {
            Heart_2Anim.SetTrigger("ChangeBack");
            heartUI.SetActive(false);

            UIHeal.SetActive(true);
            AnimHearrt.SetActive(true);

            hps = false;
        }
        if (hp == 0)
        {
            Heart_3Anim.SetTrigger("Change_3");           
            hps = false;
            gameManager.gameOver = true;
            UIAttack_3.SetActive(true);

            if (playAudio_2 && SoundEffect_Ctrl.soundEffect.sfxToggle == true)
            {
                SoundEffect_Ctrl.soundEffect.Audio.PlayOneShot(SoundEffect_Ctrl.soundEffect.WingLose, 1f);
                playAudio_2 = false;
            }

            StartCoroutine(UIAttackShow_3(2f));
            StartCoroutine(UILoseShow(2f));

        }
        if (hp == 1 && addHpPlayer == false)
        {
            hps = true;
          
            Heart_2Anim.SetTrigger("Change_2");
            manager.addHp = false;

            UIAttack_2.SetActive(true);
            StartCoroutine(UIAttackShow_2(2f));
        }
        if (hp == 1 && addHpPlayer == true)
        {
            hps = false;
            Heart_2Anim.SetTrigger("Chack_Add");

        }
        if (hp == 2)
        {
            HeartAnim.SetTrigger("ChangeHeartUI");
            hps = false;

            UIAttack.SetActive(true);
            StopCoroutine(UIAttackShow(2f));
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Monster_Horizontal" || collision.tag == "Monster_Vertical")
        {
            anim.Play("Player_Attack", 0);
            hp -= 1;
        }
        if (collision.tag == "Monster_Right" || collision.tag == "Monster_Left")
        {
            anim.Play("Player_Attack", 0);
            hp -= 1;
        }
        if (collision.tag == "HandL")
        {
            anim.Play("Player_Attack", 0);
            hp -= 1;
        }
    }
    private IEnumerator UILoseShow(float duration)
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Game"))
        {
            if (!CanNextLevel)
            {
                if (gameManager.gameOver)
                {

                    Destroy(GameObject.FindGameObjectWithTag("Monster_Horizontal"));
                    Destroy(GameObject.FindGameObjectWithTag("Monster_Vertical"));

                    spawnPoint.spawnAllowed = false;
                    spawnPoint_2.spawnAllowed = false;
                    timeCtrl.currentTime += 0.1f;

                    anim.SetInteger("Lose", 1);

                    yield return new WaitForSeconds(duration);

                    if (playAudio && SoundEffect_Ctrl.soundEffect.sfxToggle == true)
                    {
                        Music_Ctrl.BG_music.Audio.volume = 0.01f;
                        SoundEffect_Ctrl.soundEffect.Audio.PlayOneShot(SoundEffect_Ctrl.soundEffect.Lose, 1f);
                        playAudio = false;
                    }

                    UILose.SetActive(true);
                    gameManager.gameOver = true;
                    gameManager.GameOver();
                    Music_Ctrl.BG_music.Audio.volume = 0.03f;

                }
            }
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Game_Level2"))
        {
            if (!CanNextLevel)
            {
                if (gameManager.gameOver)
                {
                    Destroy(GameObject.FindGameObjectWithTag("Monster_Left"));
                    Destroy(GameObject.FindGameObjectWithTag("Monster_Right"));

                    spawnPoint.spawnAllowed = false;
                    spawnPoint_2.spawnAllowed = false;
                    timeCtrl.currentTime += 0.1f;

                    anim.SetInteger("Lose", 1);

                    yield return new WaitForSeconds(duration);

                    if (playAudio && SoundEffect_Ctrl.soundEffect.sfxToggle == true)
                    {
                        Music_Ctrl.BG_music.Audio.volume = 0.01f;
                        SoundEffect_Ctrl.soundEffect.Audio.PlayOneShot(SoundEffect_Ctrl.soundEffect.Lose, 1f);
                        playAudio = false;
                    }

                    UILose.SetActive(true);

                    gameManager.gameOver = true;
                    gameManager.GameOver();
                    Music_Ctrl.BG_music.Audio.volume = 0.1f;
                }
            }
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Game_Level3"))
        {
            if (!CanNextLevel)
            {
                if (gameManager.gameOver)
                {
                    timeCtrl.currentTime += 0.1f;

                    anim.SetInteger("Lose", 1);

                    yield return new WaitForSeconds(duration);

                    if (playAudio && SoundEffect_Ctrl.soundEffect.sfxToggle == true)
                    {
                        Music_Ctrl.BG_music.Audio.volume = 0.01f;
                        SoundEffect_Ctrl.soundEffect.Audio.PlayOneShot(SoundEffect_Ctrl.soundEffect.Lose, 1f);
                        playAudio = false;
                    }

                    UILose.SetActive(true);

                    gameManager.gameOver = true;
                    gameManager.GameOver();

                    Music_Ctrl.BG_music.Audio.volume = 0.1f;
                }
            }
        }

    }
    IEnumerator UIAttackShow(float duration)
    {
        yield return new WaitForSeconds(duration);
        UIAttack.SetActive(false);
    }
    IEnumerator UIAttackShow_2(float duration)
    {
        yield return new WaitForSeconds(duration);
        UIAttack_2.SetActive(false);
    }
    IEnumerator UIAttackShow_3(float duration)
    {
        yield return new WaitForSeconds(duration);
        UIAttack_3.SetActive(false);
    }
    IEnumerator UI_BoltBoarder(float duration)
    {
        yield return new WaitForSeconds(duration);
        BoltBoarder.SetActive(false);
    }
    IEnumerator UI_Loop(float duration)
    {
        yield return new WaitForSeconds(duration);
        LoopBoarder.SetActive(false);
    }

}
