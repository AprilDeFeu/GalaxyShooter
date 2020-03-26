 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private enum Type{ Zero, One, Two, Three, Four, Five}
    [SerializeField]
    private enum Repeat { Yes, No}
    [SerializeField]
    private Repeat _repeat;
    [SerializeField]
    private Type _level;
    [SerializeField]
    private float _speed = 2.0f;
    [SerializeField]
    private GameObject _enemyPrefab;
    private int lives;
    private int score;
    private int dmg;
    private Score _score; 

    // Start is called before the first frame update
    void Start()
    {
        _score = GameObject.FindGameObjectWithTag("Score").GetComponent<Score>();
        switch (_level)
        {
            case Type.Zero:
                lives = 50;
                dmg = 5;
                score = 5000;
                break;
            case Type.One:
                lives = 2;
                dmg = 1;
                score = 100;
                break;
            case Type.Two:
                lives = 2;
                dmg = 1;
                score = 200;
                break;
            case Type.Three:
                lives = 3;
                dmg = 1;
                score = 300;
                break;
            case Type.Four:
                lives = 2;
                dmg = 1;
                score = 400;
                break;
            case Type.Five:
                lives = 8;
                dmg = 2;
                score = 500;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch (_level)
        {
            case Type.Zero:
                int rand = Random.Range(0, 1);
                if (rand == 1) MovementL0A();
                else MovementL0B();
                break;
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
        if (other.tag == "ShieldDeployed")
        {
            Destroy(this.gameObject);
            Shield temp = other.transform.GetComponent<Shield>();
            if (temp != null) temp.Damage(dmg);
        }
        else if (other.tag == player)
        {
            Destroy(this.gameObject);
            Player temp = other.transform.GetComponent<Player>();
            if (temp != null) temp.Damage(dmg);
        }
        else if (other.tag == laser)
        {
            Destroy(other.gameObject);
            EnemyDamage();
        }
    }

    void MovementL0A()
    {
        transform.Rotate(0, 0, 2*(Time.deltaTime));
        Vector3 mag = new Vector3(0, -1, 0);
        transform.Translate(mag * _speed * Time.deltaTime);
        Ending(10f);
    }
    void MovementL0B()
    {
        transform.Rotate(0, 0, -2 * (Time.deltaTime));
        Vector3 mag = new Vector3(0, -1, 0);
        transform.Translate(mag * _speed * Time.deltaTime);
        Ending(10f);
    }

    void MovementL1()
    {
        Vector3 wobble = new Vector3(4 * Mathf.Sin(8 * Time.time), 0, 0);
        transform.Translate((Vector3.down + wobble) * _speed * Time.deltaTime);
        Ending(10f);
    }

    void MovementL2()
    {
        Vector3 wobble = new Vector3(5 * Mathf.Cos(10 * Time.time), 0, 0);
        transform.Translate((Vector3.down + wobble) * _speed * Time.deltaTime);
        Ending(9f);
    }


    void MovementL3()
    {
        Vector3 wobble = new Vector3(2 * Mathf.Cos(6 * Time.time) * Mathf.Sin(4* Time.time), 0, 0);
        transform.Translate((Vector3.down + wobble) * _speed * Time.deltaTime);
        Ending(9f);
    }

    void MovementL4()
    {
        Vector3 wobble = new Vector3(8 * Mathf.Sin(12 * Time.time) * Mathf.Cos(8 * Time.time), 0, 0);
        transform.Translate((Vector3.down + wobble) * _speed * Time.deltaTime);
        Ending(7f);
    }

    void MovementL5()
    {
        Vector3 wobble = new Vector3(3 * Mathf.Sin(3 * Time.time), 0, 0);
        transform.Translate((Vector3.down + wobble) * 0.5f * _speed * Time.deltaTime);
        Ending(9f);
    }

    void EnemyDamage()
    {
        lives--;
        if (lives < 1) 
        {
            Destroy(this.gameObject);
            _score.addScore(score);
        }
    }

    void Ending(float range)
    {
        switch (_repeat)
        {
            case Repeat.No:
                if (transform.position.y <= -6) Destroy(this.gameObject);
                break;
            case Repeat.Yes:
                if (transform.position.y <= -6) transform.position = new Vector3(Random.Range(-range, range), 7f, 0);
                break;
        }
    }
}
