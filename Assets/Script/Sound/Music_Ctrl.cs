using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Music_Ctrl : MonoBehaviour
{
    public static Music_Ctrl BG_music;
    public AudioSource Audio;

    private void Awake()
    {
        if (BG_music != null && BG_music != this)
        {
            Destroy(this.gameObject);
            return;
        }
        BG_music = this;
        DontDestroyOnLoad(this);
    }
    private void Start()
    {
        Audio = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("StartScene"))
        {
            if (BG_music != null && BG_music != this)
            {
                BG_music = null;
                return;
            }

        }

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("CutScene"))
        {
            if (BG_music != null && BG_music != this)
            {
                BG_music = null;
                return;
            }
        }

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Game"))
        {
            if (BG_music != null && BG_music != this)
            {
                BG_music = null;
                return;
            }
        }

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Game_Level2"))
        {
            if (BG_music != null && BG_music != this)
            {
                BG_music = null;
                return;
            }
        }

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Game_Level3"))
        {
            if (BG_music != null && BG_music != this)
            {
                BG_music = null;
                return;
            }
        }


    }
    public void ChangeBGM(AudioClip music)
    {
        Audio.clip = music;
        Audio.Play();

    }
}
