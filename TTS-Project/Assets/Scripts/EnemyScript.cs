using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyScript : MonoBehaviour
{
    public float lookRadius = 10f;
    public float chaseRadius = 8f;
    public float rotationSpeed = 8f;
    private Transform target;
    private Animator animator;
    private NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance > lookRadius)
        {
            animator.SetBool("isChasing", false);
            animator.SetBool("isAware", false);
        }
        if(distance <= lookRadius)
        {
            animator.SetBool("isChasing", false);
            animator.SetBool("isAware", true);
            FaceTarget();
        }
        if (distance <= chaseRadius)
        {
            animator.SetBool("isChasing", true);
            animator.SetBool("isAware", false);
            FaceTarget();
            agent.SetDestination(target.position);
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.y));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRadius);
    }
}


