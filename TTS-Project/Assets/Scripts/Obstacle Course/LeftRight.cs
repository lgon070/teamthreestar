using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftRight : MonoBehaviour
{
    public bool left;
    public bool right;
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(left);
        if (transform.position.z <= -25.0 ) {
            left = true;
            right = false;
            
        }
        else if (transform.position.z >= -20.0 )
        {
            left = false;
            right = true;
            
        }

        if (left)
        {
            transform.position += new Vector3(0, 0, 2 * Time.deltaTime);
        }
        if(right)
        {
            transform.position -= new Vector3(0, 0, 2 * Time.deltaTime);
        }

        

    }
}
