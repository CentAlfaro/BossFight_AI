using UnityEngine;

namespace AnimationBehaviors.Monster
{
    public class MonsterRangedState : StateMachineBehaviour
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
            Debug.Log($"Player and Monster's Distance: {distance}");
            if (distance >= 25)
            {
                animator.SetBool("IsRangedAttack" ,false);
                animator.SetBool("IsChasing", true);
            
            }
            else if (distance < 13.5f)
            {
                animator.SetBool("IsRangedAttack" ,false);
                animator.SetBool("IsMeleeAttack", true);
            
            }
            else if (_enemyScript._rangedCounter == 5)
            {
                animator.SetBool("IsRangedAttack" ,false);
                animator.SetBool("IsSpellAttack", true);
            }
        }

        // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            _enemyScript._rangedCounter = 0;
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
