using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCtrl_Level2_2 : MonoBehaviour
{
    Rigidbody2D rb;
    GameObject target;
    GameObject target2;
    float moveSpeed;
    Vector3 directionToTarget;

    public bool checktarget = false;
    public bool canDraw = false;


    //public PlayerCtrl playerCtrl;
    public GameManager gameManager;
    public Manager manager;

    void Start()
    {
        target = GameObject.Find("Waypoint");
        target2 = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();
        moveSpeed = Random.Range(5f, 5f);
    }
    void Update()
    {
        MoveMonster();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        switch (col.gameObject.tag)
        {
            case "Box":
                canDraw = true;
                manager.canDraws = true;
                break;

            case "Waypoint":
                target = target2;
                break;

            case "Player":
                gameManager.Miss();
                Destroy(gameObject);

                if (SoundEffect_Ctrl.soundEffect.sfxToggle == true)
                {
                    SoundEffect_Ctrl.soundEffect.Audio.PlayOneShot(SoundEffect_Ctrl.soundEffect.Attack, 2f);
                }

                target = null;
                break;
        }
    }
    void MoveMonster()
    {
        if (target != null && !checktarget)
        {
            directionToTarget = (target.transform.position - transform.position).normalized;
            rb.velocity = new Vector2(directionToTarget.x * moveSpeed, directionToTarget.y * moveSpeed);
        }
        if (target == null && !checktarget)
        {
            directionToTarget = (target2.transform.position - transform.position).normalized;
            rb.velocity = new Vector2(directionToTarget.x * moveSpeed, directionToTarget.y * moveSpeed);
            gameManager.Miss();
        }
        if (checktarget)
        {
            rb.velocity = Vector3.zero;
        }
    }
}
