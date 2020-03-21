using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // public or private reference
    // data type (int, float, double, long, bool, string, char, arrays, etc)
    // variables have names
    // (opt) assigned value
    [SerializeField]
    private float _speed = 3.5f;
    
    // Start is called before the first frame update
    void Start()
    {
        // Current position = new position (0,0,0)
        transform.position = new Vector3(0, 0, 0); 
    }

    // Update is called once per frame
    void Update()
    {
        float hInput = Input.GetAxis("Horizontal");     // Horizontal Input
        float vInput = Input.GetAxis("Vertical");       // Vertical Input

        // Simple way
        // new Vector3(1, 0, 0) * speed * real time
        // new Vector3(0, 1, 0) * speed * real time
        //transform.Translate(Vector3.right  * hInput * _speed * Time.deltaTime);
        //transform.Translate(Vector3.up * vInput * _speed * Time.deltaTime);

        // Optimized way (by vector addition)
        // new Vector3(1, 1, 0) * speed * real time
        Vector3 direction = new Vector3(hInput, vInput, 0);
        transform.Translate(direction * _speed * Time.deltaTime);

        // if player.position.y > 0 then direction = new Vector (1, 0, 0);
        if (transform.position.y >= 0.5) 
        {
            transform.position = new Vector3(transform.position.x, 0.5f, 0);
        }
        else if (transform.position.y <= -3.5)
        {
            transform.position = new Vector3(transform.position.x, -3.5f, 0);
        }

        // X-axis limits
        //if (transform.position.x >= 9)
        //{
        //    transform.position = new Vector3(9f, transform.position.y, 0);
        //}
        //else if (transform.position.x <= -9)
        //{
        //    transform.position = new Vector3(-9f, transform.position.y, 0);
        //}

        //X-axis wrap
        if (transform.position.x >= 11)
        {
            transform.position = new Vector3(transform.position.x - 22, transform.position.y, 0);
        }
        else if (transform.position.x <= -11)
        {
            transform.position = new Vector3(transform.position.x + 22, transform.position.y, 0);
        }

    }
}
