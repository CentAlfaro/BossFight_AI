using UnityEngine;
using UnityEngine.AI;

namespace AnimationBehaviors.Monster
{
    public class MonsterChaseState : StateMachineBehaviour
    {

        private NavMeshAgent _agent;
        private Transform _player;
        // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            _agent = animator.GetComponent<NavMeshAgent>();
            _player = GameObject.FindGameObjectWithTag("player").transform;
        }

        // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
        override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            
        
            float distance = Vector3.Distance(_player.position, animator.transform.position);
            Debug.Log($"Player and Monster's Distance: {distance}");
            if (distance >=13.5)
            {
                _agent.destination = _player.position;
            }
            else if (distance <13)
            {
                _agent.destination = animator.transform.position;
                animator.SetBool("IsMeleeAttack", true);
            }
        }

        // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
        
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
}
