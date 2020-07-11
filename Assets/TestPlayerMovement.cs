using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerMovement : MonoBehaviour
{
    public bool hasKey;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;

        if (Input.GetKey("w"))
        {
            pos.y += 2 * Time.deltaTime;
        }
        if (Input.GetKey("s"))
        {
            pos.y -= 2 * Time.deltaTime;
        }
        if (Input.GetKey("d"))
        {
            pos.x += 2 * Time.deltaTime;
        }
        if (Input.GetKey("a"))
        {
            pos.x -= 2 * Time.deltaTime;
        }

        transform.position = pos;
    }
}
