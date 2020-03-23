 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float _r = Random.Range(-9f, 9f);
    [SerializeField]
    private float _speed = 4.0f;
    [SerializeField]
    private GameObject _enemyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(_enemyPrefab, new Vector3(_r, 7f, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        // Move down at x m/s
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        if (transform.position.y <= -6)  transform.position = new Vector3(_r, 7f, 0); 
    }
}
