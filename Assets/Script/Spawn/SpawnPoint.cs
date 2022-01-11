using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] monsters;
    int randomSpawnPoint,randomMonster;
    public bool spawnAllowed;

    public float num_1;
    public float num_2;


    void Start()
    {
        spawnAllowed = true;
        InvokeRepeating("SpawnMonster", num_1, num_2);
    }

    void SpawnMonster()
    {
        if (spawnAllowed)
        {
            randomSpawnPoint = Random.Range(0, spawnPoints.Length);
            randomMonster = Random.Range(0, monsters.Length);
            Instantiate(monsters[randomMonster], spawnPoints[randomSpawnPoint].position, Quaternion.identity);
        }
    }

}
