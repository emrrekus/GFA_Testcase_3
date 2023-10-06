using System.Collections;
using System.Collections.Generic;
using GFA;
using UnityEngine;

public class IdleState : StateMachineBehaviour
{
    private float timer;
    private EnemyController _enemyController;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0;
        _enemyController = animator.GetComponentInParent<EnemyController>();
    }
    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer += Time.deltaTime;
        if (timer> 5)
        {
            animator.SetBool("isPatrolling",true);
        }
        
        if(_enemyController.IsJump)
            animator.SetTrigger("isJump");
        
        if(_enemyController.IsRoll)
            animator.SetTrigger("isRoll");
      
    }

   
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

  
    override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

   
    override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}
