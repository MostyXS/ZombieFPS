using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] float chaseRange = 5f;
    [SerializeField] float turnSpeed = 10f;
    Animator animator;
    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity;
    bool isProvoked;
    Transform target;


    private void Start()
    {
        target = FindObjectOfType<Health>().transform;
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (GetComponent<EnemyHealth>().GetDead())
        {
            navMeshAgent.enabled = false;
        }
        else
        {
            ProcessControl();
        }
    }

    private void ProcessControl()
    {
        distanceToTarget = Vector3.Distance(transform.position, target.position);
        if (isProvoked )
            EngageTarget();
        else if (distanceToTarget <= chaseRange)
        {
            isProvoked = true;

        }
    }

    public void OnDamageTaken()
    {
        isProvoked = true;
    }
    private void EngageTarget()
    {
        FaceTarget();
        if (distanceToTarget > navMeshAgent.stoppingDistance)
        {
            ChaseTarget(); 
        }
        else
        { 
            Attack();
        }

    }

    private void Attack()
    {
        
        if(animator.GetBool("attack")==false)
        animator.SetBool("attack", true);
        
    }

    private void ChaseTarget()
    {
        if (animator.GetBool("attack") != false)
            animator.SetBool("attack", false);
        animator.SetTrigger("move");
        navMeshAgent.SetDestination(target.position);
    }
    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }   
    private void OnDrawGizmosSelected()
    {


        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }

}
