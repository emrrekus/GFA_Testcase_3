using System;
using System.Collections;
using System.Collections.Generic;
using GFA;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameInstance _gameInstance;

    [SerializeField] private GameObject _player;

    private void Awake()
    {
        _gameInstance.Reset();
        _gameInstance.Player = _player;
    }

    private void Update()
    {
        _gameInstance.AddTime(Time.deltaTime);
    }
}
