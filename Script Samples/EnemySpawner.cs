using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float SpawnRate;
    public GameObject[] Enemies;
    public int waves = 1;

    void Start()
    {
        InvokeRepeating("SpawnEnemy",SpawnRate,SpawnRate);
    }
    
    void SpawnEnemy()
    {
        for(int i = 0; i < waves; i++)
        {
            Instantiate(Enemies[(int)Random.Range(0,Enemies.Length)],new Vector3(Random.Range(-11,11),7,0),Quaternion.identity);
        }   
    }
}
