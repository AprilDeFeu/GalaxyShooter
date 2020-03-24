using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    // Start is called before the first frame update

    // Speed variable of 10
    [SerializeField]
    private float _speed = 20;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        DestroyLaser();
    }

    void Movement()
    {
        transform.Translate(Vector3.up * _speed * Time.deltaTime);
    }

    void DestroyLaser()
    {
        if (transform.position.y >= 8) Destroy(gameObject);
    }
}
