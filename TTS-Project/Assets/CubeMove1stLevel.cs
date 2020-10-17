using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMove1stLevel : MonoBehaviour
{

    private bool move = false;
    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        if(move && transform.position.y <= 9.0) {
            transform.position += new Vector3(0, 3 * Time.deltaTime, 0);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        move = true;
    }
}
