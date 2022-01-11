using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect_Ctrl : MonoBehaviour
{
    public AudioSource Audio;
    public AudioSource Audio_MonsterDead_1;
    public AudioSource Audio_MonsterDead_2;
    public AudioSource Audio_MonsterDead_3;
    public AudioSource Audio_MonsterDead_4;
    public AudioSource Audio_Bolt;
    public AudioSource Audio_Loop;
    public AudioSource Audio_Win;
    public AudioSource Audio_Lose;
    public AudioSource Audio_Attack;
    public AudioSource Audio_Heal;
    public AudioSource Audio_Wing;
    public AudioSource Audio_WingLose;
    public AudioSource Audio_Boss_Attack;
    public AudioSource Audio__Boss_Dead;

    public AudioClip Click;
    public AudioClip Monster_Dead_1;
    public AudioClip Monster_Dead_2;
    public AudioClip Monster_Dead_3;
    public AudioClip Monster_Dead_4;
    public AudioClip Bolt;
    public AudioClip Loop;
    public AudioClip Win;
    public AudioClip Lose;
    public AudioClip Attack;
    public AudioClip Heal;
    public AudioClip Wing;
    public AudioClip WingLose;
    public AudioClip Boss_Attack;
    public AudioClip Boss_Dead;

    public bool sfxToggle = true;

    public static SoundEffect_Ctrl soundEffect;

    private void Awake()
    {
        if (soundEffect != null && soundEffect != this)
        {
            Destroy(this.gameObject);
            return;
        }
        soundEffect = this;
        DontDestroyOnLoad(this);
    }

}
