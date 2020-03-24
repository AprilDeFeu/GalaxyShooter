 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private enum Type{ One, Two, Three, Four, Five}
    [SerializeField]
    private Type level;
    [SerializeField]
    private float _speed = 2.0f;
    [SerializeField]
    private GameObject _enemyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //MovementL2();
        switch (level)
        {
            case Type.One:
                MovementL1();
                break;
            case Type.Two:
                MovementL2();
                break;
            case Type.Three:
                MovementL3();
                break;
            case Type.Four:
                MovementL4();
                break;
            case Type.Five:
                MovementL5();
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        string player = "Player";
        string laser = "Laser(Clone)";
        if (other.transform.name.Equals(player)) Destroy(other.gameObject) ;
        if (other.transform.name.Equals(laser))
        {
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }
    }

    void MovementL1()
    {
        // Move down at x m/s
        Vector3 wobble = new Vector3(4 * Mathf.Sin(8 * Time.time), 0, 0);
        transform.Translate((Vector3.down + wobble) * _speed * Time.deltaTime);
        if (transform.position.y <= -6) transform.position = new Vector3(Random.Range(-11.0f, 11.0f), 7f, 0);
    }

    void MovementL2()
    {
        // Move down at x m/s
        Vector3 wobble = new Vector3(4 * Mathf.Sin(4 * Time.time), 0, 0);
        transform.Translate((Vector3.down + wobble) * _speed * Time.deltaTime);
        if (transform.position.y <= -6) transform.position = new Vector3(Random.Range(-9.0f, 9.0f), 7f, 0);
    }


    void MovementL3()
    {
        // Move down at x m/s
        Vector3 wobble = new Vector3(8 * Mathf.Sin(6 * Time.time), 0, 0);
        transform.Translate((Vector3.down + wobble) * _speed * Time.deltaTime);
        if (transform.position.y <= -6) transform.position = new Vector3(Random.Range(-9.0f, 9.0f), 7f, 0);
    }

    void MovementL4()
    {
        // Move down at x m/s
        Vector3 wobble = new Vector3(8 * Mathf.Sin(12 * Time.time), 0, 0);
        transform.Translate((Vector3.down + wobble) * _speed * Time.deltaTime);
        if (transform.position.y <= -6) transform.position = new Vector3(Random.Range(-9.0f, 9.0f), 7f, 0);
    }

    void MovementL5()
    {
        // Move down at x m/s
        Vector3 wobble = new Vector3(4 * Mathf.Sin(3 * Time.time), 0, 0);
        transform.Translate((Vector3.down + wobble) * 0.5f * _speed * Time.deltaTime);
        if (transform.position.y <= -6) transform.position = new Vector3(Random.Range(-9.0f, 9.0f), 7f, 0);
    }
}
