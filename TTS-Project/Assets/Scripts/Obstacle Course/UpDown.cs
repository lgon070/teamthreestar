using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDown : MonoBehaviour
{
    public bool Up;
    public bool Down;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y >= 5.8)
        {
            Up = false;
            Down = true;
            
        }
        else if (transform.position.y <= 1.5)
        {
            Up = true;
            Down = false;
            
        }

        if (Down)
        {
            transform.position -= new Vector3(0, 2 * Time.deltaTime,0 );
        }
        if (Up)
        {
            transform.position += new Vector3(0, 2 * Time.deltaTime,0 );
        }
    }
}
