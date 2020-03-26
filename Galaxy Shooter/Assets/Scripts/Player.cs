using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private enum Type1 { limit, wrap} 
    [SerializeField]
    private enum Type2 { easy, normal, hard }
    [SerializeField]
    private Type1 _movement;
    [SerializeField]
    private Type2 _difficulty;
    [SerializeField]
    private float _speed = 10f;
    [SerializeField]
    private float _speedTime = 10f;
    [SerializeField]
    private GameObject _tsPrefab;
    [SerializeField]
    private float _tsTime = 10f;
    [SerializeField]
    private float _shieldTime = 20f;
    [SerializeField]
    private GameObject _shieldPrefab;
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private float _fireRate = 0.2f;
    private float _canFire = -1f;
    public int _lives;
    [SerializeField]
    private bool _activeTS = false;
    [SerializeField]
    private SpawnManager _spawnManager;
     
    // Start is called before the first frame update
    void Start()
    {
        // Current position = new position (0,0,0)
        transform.position = new Vector3(0, 0, 0);
        switch (_difficulty)
        {
            case Type2.easy:
                _lives = 5;
                break;

            case Type2.normal:
                _lives = 3;
                break;

            case Type2.hard:
                _lives = 1;
                break;
        }
        _spawnManager = GameObject.FindGameObjectWithTag("Spawn Manager").GetComponent<SpawnManager>();
        if (_spawnManager == null) Debug.LogError("Spawn Manager is NULL. This occurs when the \"Spawn Manager\" GameObject is not attached to the script.");

    }

    // Update is called once per frame
    void Update()
    {
        switch (_movement)
        {
            case Type1.limit:
                CalculateMovement_Limit();
                break;

            case Type1.wrap:
                CalculateMovement_Wrap();
                break;
        }
        
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
            if (_activeTS == false)
            {
                Vector3 offset = new Vector3(0, 0.65f, 0);
                Instantiate(_laserPrefab, transform.position + offset, Quaternion.identity);
            }
            else
            {
                Debug.Log("Triple Shot tested.");
                Instantiate(_tsPrefab, transform.position, Quaternion.identity);
            }

        }

    }

    public void Damage(int dmg)
    {
        
        if (_lives - dmg < 0) _lives = 0;
        else _lives -= dmg;
        if (_lives < 1) 
        {
            _spawnManager.PlayerDeath();
            Destroy(this.gameObject);
        }
    }

    public void Heal()
    {
        _lives++;
    }

    public int getLives()
    {
        return _lives;
    }

    public void tsON()
    {
        _activeTS = true;
        StartCoroutine(CounterTS());
        
    }

    public void speedON()
    {
        _speed = 17.5f;
        StartCoroutine(CounterSpeed());
    }

    public void shieldON()
    {
        Instantiate(_shieldPrefab, transform.position, Quaternion.identity);
    }

    IEnumerator CounterTS()
    {
        int timer = 0;
        while (timer < _tsTime)
        {
            timer++;
            yield return new WaitForSeconds(1.0f);
        }
        _activeTS = false;

    }

    IEnumerator CounterSpeed()
    {
        int timer = 0;
        while (timer < _speedTime)
        {
            timer++;
            yield return new WaitForSeconds(1.0f);
        }
        _speed = 10f;

    }


}
