using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCtrl_Level_3 : MonoBehaviour
{
    public GameObject LineLast;

    public GameObject mLine;
    public GameObject Line;

    public Manager manager;
    public GameManager gameManager;
    public SpawnMonster_Level3 spawn;


    public Animator anim;
    public Animator boss;
    public Hand_Left_Ctrl handleft;
    public Hand_Right_Ctrl handright;

    private void Start()
    {
        boss = GameObject.Find("Head").GetComponent<Animator>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        spawn = GameObject.Find("Spawn").GetComponent<SpawnMonster_Level3>();
        handleft = GameObject.Find("Hand_Left").GetComponent<Hand_Left_Ctrl>();
        handright = GameObject.Find("Hand_Right").GetComponent<Hand_Right_Ctrl>();
    }
    public void PlayAnimMon01()
    {
        if (Line.tag == "Monster_Horizontal")
        {
            gameManager.Multiplier_leLevel3();
            //Animation Line
            anim.SetInteger("Line", 1);

            if (SoundEffect_Ctrl.soundEffect.sfxToggle == true)
            {
                SoundEffect_Ctrl.soundEffect.Audio.PlayOneShot(SoundEffect_Ctrl.soundEffect.Monster_Dead_1, 8f);
            }

            Destroy(Line, 0.3f);

        }
        else if (Line.tag == "Monster_Horizontal_Last")
        {
            //score ++
            gameManager.HitLevel3();
            //Animation Line
            anim.SetInteger("Line", 1);

            if (SoundEffect_Ctrl.soundEffect.sfxToggle == true)
            {
                SoundEffect_Ctrl.soundEffect.Audio.PlayOneShot(SoundEffect_Ctrl.soundEffect.Monster_Dead_1, 8f);
                SoundEffect_Ctrl.soundEffect.Audio.PlayOneShot(SoundEffect_Ctrl.soundEffect.Boss_Attack);
            }

            Destroy(Line,0.3f);
            Destroy(mLine, 0.3f);

            //Boss hurt
            handleft.MoveRight = true;
            handright.MoveRight = true;

            boss.Play("Boss_Attack", 0);
            spawn.Invoke("SpawnMonster", 1);

        }
        else
        {
            gameManager.Miss();
        }

    }
    public void PlayAnimMon02()
    {
        if (Line.tag == "Monster_Vertical")
        {
            gameManager.Multiplier_leLevel3();

            anim.SetInteger("Line", 1);

            if (SoundEffect_Ctrl.soundEffect.sfxToggle == true)
            {
                SoundEffect_Ctrl.soundEffect.Audio.PlayOneShot(SoundEffect_Ctrl.soundEffect.Monster_Dead_2, 8f);
            }

            Destroy(Line,0.3f);
        }
        else if (Line.tag == "Monster_Vertical_Last")
        {

            gameManager.HitLevel3();

            anim.SetInteger("Line", 1);

            if (SoundEffect_Ctrl.soundEffect.sfxToggle == true)
            {
                SoundEffect_Ctrl.soundEffect.Audio.PlayOneShot(SoundEffect_Ctrl.soundEffect.Monster_Dead_2, 8f);
                SoundEffect_Ctrl.soundEffect.Audio.PlayOneShot(SoundEffect_Ctrl.soundEffect.Boss_Attack);
            }

            Destroy(Line, 0.3f);
            Destroy(mLine, 0.3f);

            handleft.MoveRight = true;
            handright.MoveRight = true;


            boss.Play("Boss_Attack", 0);

            spawn.Invoke("SpawnMonster", 1);
        }
        else
        {
            gameManager.Miss();
        }
    }
    public void PlayAnimMon03()
    {
        if (Line.tag == "Monster_Right")
        {

            gameManager.Multiplier_leLevel3();

            anim.SetInteger("Line", 1);

            if (SoundEffect_Ctrl.soundEffect.sfxToggle == true)
            {
                SoundEffect_Ctrl.soundEffect.Audio.PlayOneShot(SoundEffect_Ctrl.soundEffect.Monster_Dead_4, 8f);
            }

            Destroy(Line);
        }
        else if (Line.tag == "Monster_Right_Last")
        {
            gameManager.HitLevel3();

            anim.SetInteger("Line", 1);
            spawn.spawnAllowed = true;
            Destroy(Line);
            Destroy(mLine, 0.1f);
            handleft.MoveRight = true;
            handright.MoveRight = true;

            boss.Play("Boss_Attack", 0);

            if (SoundEffect_Ctrl.soundEffect.sfxToggle == true)
            {
                SoundEffect_Ctrl.soundEffect.Audio.PlayOneShot(SoundEffect_Ctrl.soundEffect.Monster_Dead_4, 8f);
                SoundEffect_Ctrl.soundEffect.Audio.PlayOneShot(SoundEffect_Ctrl.soundEffect.Boss_Attack);
            }

            spawn.Invoke("SpawnMonster", 1);
        }
        else
        {
            gameManager.Miss();
        }
    }
    public void PlayAnimMon04()
    {
        if (Line.tag == "Monster_Left")
        {
            gameManager.Multiplier_leLevel3();

            anim.SetInteger("Line", 1);

            if (SoundEffect_Ctrl.soundEffect.sfxToggle == true)
            {
                SoundEffect_Ctrl.soundEffect.Audio.PlayOneShot(SoundEffect_Ctrl.soundEffect.Monster_Dead_3, 8f);
            }
            Destroy(Line);
        }
        else if (Line.tag == "Monster_Left_Last")
        {
            gameManager.HitLevel3();

            anim.SetInteger("Line", 1);
            spawn.spawnAllowed = true;
            Destroy(Line);
            Destroy(mLine, 0.1f);
            handleft.MoveRight = true;
            handright.MoveRight = true;


            if (SoundEffect_Ctrl.soundEffect.sfxToggle == true)
            {
                SoundEffect_Ctrl.soundEffect.Audio.PlayOneShot(SoundEffect_Ctrl.soundEffect.Monster_Dead_3, 8f);
                SoundEffect_Ctrl.soundEffect.Audio.PlayOneShot(SoundEffect_Ctrl.soundEffect.Boss_Attack);
            }

            boss.Play("Boss_Attack", 0);

            spawn.Invoke("SpawnMonster", 1);
        }
        else
        {
            gameManager.Miss();
        }
    }
    public void PlayAnimLoop()
    {
        handleft.MoveRight = true;
        handright.MoveRight = true;

    }
    public void PlayAnimMonBolt()
    {
        gameManager.HitLevel3();

        Destroy(GameObject.FindWithTag("Monster_3_1"));
        handleft.MoveRight = true;
        handright.MoveRight = true;
        spawn.Invoke("SpawnMonster", 1);
        boss.Play("Boss_Attack", 0);
    }
}

