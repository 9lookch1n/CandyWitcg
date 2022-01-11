﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryMonsterRight : MonoBehaviour
{
    public Animator anim;
    public GameObject TextDamage;
    public GameObject Line;

    public GameManager gameManager;

    public bool canDead = false;


    private void Start()
    {
        anim.GetComponents<Animator>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    private void Update()
    {
        if (GetComponent<MonsterCtrl>() != null)
        {
            if (GetComponent<MonsterCtrl>().CheckDead == true)
            {
                canDead = true;
            }
        }
        else
        {
            return;
        }
        if (GetComponent<MonsterCtrl_2>() != null)
        {
            if (GetComponent<MonsterCtrl_2>().CheckDead == true)
            {
                canDead = true;
            }
        }
        else
        {
            return;
        }

    }
    public void PlayAnimRight()
    {
        if(GetComponent<MonsterCtrl_Level2>() && GetComponent<MonsterCtrl_Level2>().canDraw)
        {
            Instantiate(TextDamage, transform.position, Quaternion.identity);
            anim.SetInteger("Dead_Right", 1);
            Line.SetActive(false);
            GetComponent<MonsterCtrl_Level2>().checktarget = true;
            this.gameManager.Hit();
            Destroy(gameObject, 0.35f);

            if (SoundEffect_Ctrl.soundEffect.sfxToggle == true)
            {
                SoundEffect_Ctrl.soundEffect.Audio.PlayOneShot(SoundEffect_Ctrl.soundEffect.Monster_Dead_4, 8f);
            }
        }
        else if (GetComponent<MonsterCtrl_Level2_2>() && GetComponent<MonsterCtrl_Level2_2>().canDraw)
        {
            Instantiate(TextDamage, transform.position, Quaternion.identity);
            anim.SetInteger("Dead_Right", 1);
            Line.SetActive(false);
            GetComponent<MonsterCtrl_Level2_2>().checktarget = true;
            this.gameManager.Hit();
            Destroy(gameObject, 0.35f);

            if (SoundEffect_Ctrl.soundEffect.sfxToggle == true)
            {
                SoundEffect_Ctrl.soundEffect.Audio.PlayOneShot(SoundEffect_Ctrl.soundEffect.Monster_Dead_4, 8f);
            }
        }
    }
    public void PlayAnimDeadBolt()
    {
        if (GetComponent<MonsterCtrl_Level2>() && GetComponent<MonsterCtrl_Level2>().canDraw)
        {
            GetComponent<MonsterCtrl_Level2>().checktarget = true;
        }
        else if (GetComponent<MonsterCtrl_Level2_2>() && GetComponent<MonsterCtrl_Level2_2>().canDraw)
        {
            GetComponent<MonsterCtrl_Level2_2>().checktarget = true;
        }
        else
        {
            return;
        }

        Instantiate(TextDamage, transform.position, Quaternion.identity);
        anim.SetInteger("Dead_Right", 1);
        Line.SetActive(false);
        Destroy(gameObject, 0.35f);

        if (SoundEffect_Ctrl.soundEffect.sfxToggle == true)
        {
            SoundEffect_Ctrl.soundEffect.Audio.PlayOneShot(SoundEffect_Ctrl.soundEffect.Monster_Dead_4, 8f);
        }
    }


}
