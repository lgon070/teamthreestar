using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public HealthManager Hman;
    public AudioSource Ding;
    public GameObject gameObject;


    // Start is called before the first frame update
    void Start()
    {
        Hman = FindObjectOfType<HealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Player"))
        {
            Ding.Play();
            Hman.SetSpawnPoint(transform.position);
            DestroyObject(gameObject);
        }
    }
}
