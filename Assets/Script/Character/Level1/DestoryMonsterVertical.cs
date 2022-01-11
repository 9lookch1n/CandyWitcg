using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryMonsterVertical : MonoBehaviour
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
    public void PlayAnimVertical()
    {
        if (GetComponent<MonsterCtrl>() && GetComponent<MonsterCtrl>().canDraw)
        {
            GetComponent<MonsterCtrl>().checktarget = true;
            Instantiate(TextDamage, transform.position, Quaternion.identity);
            anim.SetInteger("Dead_Vertical", 1);
            Line.SetActive(false);
            this.gameManager.Hit();
            Destroy(gameObject, 0.25f);

            if (SoundEffect_Ctrl.soundEffect.sfxToggle == true)
            {
                SoundEffect_Ctrl.soundEffect.Audio.PlayOneShot(SoundEffect_Ctrl.soundEffect.Monster_Dead_2, 8f);
            }
        }
        if (GetComponent<MonsterCtrl_2>() && GetComponent<MonsterCtrl_2>().canDraw)
        {
            GetComponent<MonsterCtrl_2>().checktarget = true;
            Instantiate(TextDamage, transform.position, Quaternion.identity);
            anim.SetInteger("Dead_Vertical", 1);
            Line.SetActive(false);
            this.gameManager.Hit();
            Destroy(gameObject, 0.25f);

            if (SoundEffect_Ctrl.soundEffect.sfxToggle == true)
            {
                SoundEffect_Ctrl.soundEffect.Audio.PlayOneShot(SoundEffect_Ctrl.soundEffect.Monster_Dead_2, 8f);
            }


        }
    }
}
