using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private NavMeshAgent _agent;

    private bool _isRoll;
    private bool _isJump;
    public bool IsJump => _isJump;
    public bool IsRoll => _isRoll;


    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (_agent.isOnOffMeshLink && !_isJump)
        {
            _agent.CompleteOffMeshLink();
            Jump();
        }
        else
        {
            _isJump = false;
        }
    }


    private void Jump()
    {
        _isJump = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Roll"))
        {
            _isRoll = true;
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Roll"))
        {
            _isRoll = false;
        }
    }
}