using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    public float lookRadius = 8f;
    public float chaseRadius = 10f;
    public float speed = 1f;
    Transform target;
    NavMeshAgent agent;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance > lookRadius)
        {
            anim.SetBool("isAware", false);
            anim.SetBool("isChasing", false);
        }
        if (distance <= lookRadius)
        {
            anim.SetBool("isAware", true);
            anim.SetBool("isChasing", false);
            transform.LookAt(target);
        }
        if (distance <= chaseRadius) 
        {
            anim.SetBool("isAware", false);
            anim.SetBool("isChasing", true);
            transform.LookAt(target);
            agent.SetDestination(target.position);
            //transform.position += transform.forward * speed * Time.deltaTime;
        }
     
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRadius);
    }
}
