using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    public Animator animator;
    public float lookRadius = 10f;

    // Start is called before the first frame update
    Transform target;
    public float speed = 1f;
    void Start()
    {
        animator = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            animator.SetBool("isWalking", true);
            transform.LookAt(target.transform);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
        
        
    }

    void OnDrawGizmosSelected ()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

}
