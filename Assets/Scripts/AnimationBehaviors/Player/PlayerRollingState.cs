using UnityEngine;

namespace AnimationBehaviors.Player
{
    public class PlayerRollingState : StateMachineBehaviour
    {
        private PlayerScript _player;
        // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            _player = animator.GetComponent<PlayerScript>();
            _player.canRoll = false;
        }

        // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
        override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (!_player.isRolling && _player.preparingToMove)
            {
                animator.SetBool("IsRolling", false);
                animator.SetBool("IsMoving", true);
            }
            else if (!_player.isRolling && !_player.preparingToMove)
            {
                animator.SetBool("IsRolling", false);
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
