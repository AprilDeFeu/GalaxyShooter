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
    private float _speed = 15f;
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private float _fireRate = 0.2f;
    private float _canFire = -1f;
     
    // Start is called before the first frame update
    void Start()
    {
        // Current position = new position (0,0,0)
        transform.position = new Vector3(0, 0, 0); 
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement_Limit();
        FireLaser();
    }

    void CalculateMovement_Limit()
    {
        float hInput = Input.GetAxis("Horizontal");     // Horizontal Input
        float vInput = Input.GetAxis("Vertical");       // Vertical Input

        Vector3 direction = new Vector3(hInput, vInput, 0);
        transform.Translate(direction * _speed * Time.deltaTime);

        // Y-axis limits
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -3.5f, 0.5f), 0);

        // X-axis limits
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -9.0f, 9.0f), transform.position.y, 0);
    }

    void CalculateMovement_Wrap()
    {
        float hInput = Input.GetAxis("Horizontal");     // Horizontal Input
        float vInput = Input.GetAxis("Vertical");       // Vertical Input

        Vector3 direction = new Vector3(hInput, vInput, 0);
        transform.Translate(direction * _speed * Time.deltaTime);

        // Y-axis limits
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -3.5f, 0.5f), 0);

        // X-axis wrap
        if (transform.position.x >= 11.3)
        {
            transform.position = new Vector3(-11.3f, transform.position.y, 0);
        }
        else if (transform.position.x <= -11.3)
        {
           transform.position = new Vector3(11.3f, transform.position.y, 0);
        }
    }

    void FireLaser()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
        {
            _canFire = Time.time + _fireRate;
            Vector3 offset = new Vector3(0, 0.65f, 0);
            Instantiate(_laserPrefab, transform.position + offset, Quaternion.identity);
        }
    }
}
