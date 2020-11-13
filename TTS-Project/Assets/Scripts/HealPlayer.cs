using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class HealPlayer : MonoBehaviour
{

    public int healingProvided = 25;

    public GameObject pickupEffect;

    public AudioSource Munch;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            FindObjectOfType<HealthManager>().HealPlayer(healingProvided);

            Instantiate(pickupEffect, transform.position, transform.rotation);

            Munch.Play();

            Destroy(gameObject);
        }
    }
}
