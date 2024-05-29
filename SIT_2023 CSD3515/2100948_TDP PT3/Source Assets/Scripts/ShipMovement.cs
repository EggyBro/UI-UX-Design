using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float Acceleration;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = new Vector3(0,0,0);
        if (Input.GetKey(KeyCode.W))
        {
            dir.y = 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            dir.y = -1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            dir.x = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            dir.x = 1;
        }
        dir.Normalize();
        Vector3 pos;
        pos.x = gameObject.transform.position.x;
        pos.y = gameObject.transform.position.y;
        pos.z = 0;
        pos += dir * Acceleration * Time.deltaTime;
        gameObject.transform.position = pos;
    }
}
