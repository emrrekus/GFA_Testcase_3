using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;

    private float minZPosition = -83;
    private float maxZPosition = 41;
    private float minXPoisition = -25;
    private float maxXPosition = 25;

    private int _level = 1;
    private float spawnCount;

    private void Awake()
    {
        spawnCount = _level * 10;
    }

    private void Start()
    {
        EnemySpawn();
    }

    private void EnemySpawn()
    {
        
        while (spawnCount>0)
        {
            Instantiate(_enemy,
                new Vector3(Random.Range(minXPoisition, maxXPosition), 0f, Random.Range(minZPosition, maxZPosition)),
                quaternion.identity);
            spawnCount--;
        }
        
    }
}