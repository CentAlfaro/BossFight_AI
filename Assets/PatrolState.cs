using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolState : StateMachineBehaviour
{
    private float timer;
    private List<Transform> waypoints = new List<Transform>();
    private NavMeshAgent agent;
    private Transform player;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        agent = animator.GetComponent<NavMeshAgent>();
        agent.speed = 1;
        timer = 0;
        player = GameObject.FindGameObjectWithTag("player").transform;

        if (agent.isStopped)
        {
            agent.isStopped = false;
            return;
        }

        GameObject go = GameObject.FindGameObjectWithTag("waypoint");
        foreach (Transform t in go.transform) waypoints.Add(t);

        agent.SetDestination(waypoints[Random.Range(0, waypoints.Count)].position);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer += Time.deltaTime;
        //Debug.Log($"PatrolTimer + {timer.ToString("F2")}");
        if (timer > 10)
        {
            animator.SetBool("isPatrolling", false);
            agent.isStopped = true;
            return;
        }

        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            agent.SetDestination(waypoints[Random.Range(0, waypoints.Count)].position);
       
        }

        float distance = Vector3.Distance(player.position, animator.transform.position);
        if (distance < 5)
        {
            animator.SetBool("isChasing", true);
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
