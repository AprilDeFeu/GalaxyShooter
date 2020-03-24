 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private enum Type{ One, Two, Three, Four, Five}
    [SerializeField]
    private Type _level;
    [SerializeField]
    private float _speed = 2.0f;
    [SerializeField]
    private GameObject _enemyPrefab;
    private int lives;

    // Start is called before the first frame update
    void Start()
    {
        switch (_level)
        {
            case Type.One:
                lives = 2;
                break;
            case Type.Two:
                lives = 2;
                break;
            case Type.Three:
                lives = 3;
                break;
            case Type.Four:
                lives = 2;
                break;
            case Type.Five:
                lives = 8;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch (_level)
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
        string laser = "Laser";
        if (other.tag == player) 
        {
            EnemyDamage();
            Player temp = other.transform.GetComponent<Player>();
            if (temp != null) temp.Damage();
        }
        if (other.tag == laser)
        {
            Destroy(other.gameObject);
            EnemyDamage();
        }
    }

    void MovementL1()
    {
        Vector3 wobble = new Vector3(4 * Mathf.Sin(8 * Time.time), 0, 0);
        transform.Translate((Vector3.down + wobble) * _speed * Time.deltaTime);
        if (transform.position.y <= -6) transform.position = new Vector3(Random.Range(-10.0f, 10.0f), 7f, 0);
    }

    void MovementL2()
    {
        Vector3 wobble = new Vector3(5 * Mathf.Cos(10 * Time.time), 0, 0);
        transform.Translate((Vector3.down + wobble) * _speed * Time.deltaTime);
        if (transform.position.y <= -6) transform.position = new Vector3(Random.Range(-9.0f, 9.0f), 7f, 0);
    }


    void MovementL3()
    {
        Vector3 wobble = new Vector3(2 * Mathf.Cos(6 * Time.time) * Mathf.Sin(4* Time.time), 0, 0);
        transform.Translate((Vector3.down + wobble) * _speed * Time.deltaTime);
        if (transform.position.y <= -6) transform.position = new Vector3(Random.Range(-9.0f, 9.0f), 7f, 0);
    }

    void MovementL4()
    {
        Vector3 wobble = new Vector3(8 * Mathf.Sin(12 * Time.time) * Mathf.Cos(8 * Time.time), 0, 0);
        transform.Translate((Vector3.down + wobble) * _speed * Time.deltaTime);
        if (transform.position.y <= -6) transform.position = new Vector3(Random.Range(-7.0f, 7.0f), 7f, 0);
    }

    void MovementL5()
    {
        Vector3 wobble = new Vector3(3 * Mathf.Sin(3 * Time.time), 0, 0);
        transform.Translate((Vector3.down + wobble) * 0.5f * _speed * Time.deltaTime);
        if (transform.position.y <= -6) transform.position = new Vector3(Random.Range(-9.0f, 9.0f), 7f, 0);
    }

    void EnemyDamage()
    {
        lives--;
        Debug.Log("Testing method success.");
        if (lives < 1) Destroy(this.gameObject);
    }
}
