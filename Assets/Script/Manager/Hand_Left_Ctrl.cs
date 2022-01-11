using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand_Left_Ctrl : MonoBehaviour
{
    public float speedTo;
    public float speedBack;
    public bool MoveRight = false;

    public GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        if (gameManager.gameFinish == true || gameManager.gameOver == true)
        {
            MoveRight = true;
        }
        else if (MoveRight == false)
        {
            transform.Translate(2 * Time.deltaTime * speedTo, 0, 0);
            transform.localScale = new Vector2(1, 1);
        }
        else
        {
            transform.Translate(-2 * Time.deltaTime * speedBack, 0, 0);
            transform.localScale = new Vector2(1, 1);
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (SoundEffect_Ctrl.soundEffect.sfxToggle == true)
            {
                SoundEffect_Ctrl.soundEffect.Audio.PlayOneShot(SoundEffect_Ctrl.soundEffect.Attack, 2f);
            }

            if (MoveRight)
            {
                //ไปชนตัว
                MoveRight = false;
            }
            else
            {
                //ไปชน Box
                MoveRight = true;
            }
        }
        if (col.gameObject.tag == "HandL")
        {
            if (MoveRight)
            {
                //ไปชนตัว
                MoveRight = false;
            }
            else
            {
                //ไปชน Box
                MoveRight = true;
            }
        }

    }

}
