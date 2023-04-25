using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHeavyAttackState : StateMachineBehaviour
{
    private EnemyManager _enemyScript;
    private Transform _player;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _enemyScript = animator.GetComponent<EnemyManager>();
        _player = GameObject.FindGameObjectWithTag("player").transform;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector3 direction = (_player.position - animator.transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        animator.transform.rotation = Quaternion.Slerp(animator.transform.rotation, lookRotation, Time.deltaTime * 5f);
        
        float distance = Vector3.Distance(_player.position, animator.transform.position);
        if (distance >= 6)
        {
            animator.SetBool("IsMeleeAttack" ,false);
            animator.SetBool("IsHeavyAttack", false);
            
        }
        else if (_enemyScript._heavyCounter == 1)
        {
            animator.SetBool("IsMeleeAttack" ,true);
            animator.SetBool("IsHeavyAttack", false);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _enemyScript._heavyCounter = 0;
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
