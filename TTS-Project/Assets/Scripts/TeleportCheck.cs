using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportCheck : MonoBehaviour
{
    public HealthManager Hman;
    public AudioSource Ding;
    public GameObject gameObject;
    public Vector3 location;

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
        if (other.tag.Equals("Player"))
        {
            Ding.Play();
            Hman.SetSpawnPoint(location);
            DestroyObject(gameObject);

        }
    }
}
