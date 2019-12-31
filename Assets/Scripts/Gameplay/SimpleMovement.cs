using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xVelocity = 0, yVelocity = 0;

        if(Input.GetKey(KeyCode.W))
        {
            yVelocity += 0.1f;
        }
        if(Input.GetKey(KeyCode.A))
        {
            xVelocity -= 0.1f;
        }
        if(Input.GetKey(KeyCode.D))
        {
            xVelocity += 0.1f;
        }
        if(Input.GetKey(KeyCode.S))
        {
            yVelocity -= 0.1f;
        }

        this.transform.SetPositionAndRotation(new Vector3(transform.position.x + xVelocity, transform.position.y + yVelocity, 0), Quaternion.identity);
    }
}
