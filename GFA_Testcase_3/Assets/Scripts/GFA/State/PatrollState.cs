using System.Collections;
using System.Collections.Generic;
using GFA;
using UnityEngine;
using UnityEngine.AI;

public class PatrollState : StateMachineBehaviour
{
    private NavMeshAgent _agent;

    [SerializeField] private GameInstance _gameInstance;
    private EnemyController _enemyController;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _agent = animator.GetComponentInParent<NavMeshAgent>();
        _enemyController = animator.GetComponentInParent<EnemyController>();
        
       
    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Vector3.Distance(_gameInstance.Player.transform.position, _agent.transform.position) < 25f)
        {
            
            _agent.SetDestination(_gameInstance.Player.transform.position);
            animator.SetBool("isPatrolling", true);
            if (_agent.remainingDistance <= _agent.stoppingDistance)
            {
                animator.SetBool("isPatrolling", false);
                
            }
            
            if(_enemyController.IsJump)
                animator.SetTrigger("isJump");
            if(_enemyController.IsRoll)
                animator.SetTrigger("isRoll");
           
        }
    }


    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _agent.SetDestination(_agent.transform.position);
    }


    override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }


    override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }
}