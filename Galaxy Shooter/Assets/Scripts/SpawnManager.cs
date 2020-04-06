using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _asteroidPrefab;
    [SerializeField]
    private GameObject _enemy1Prefab;
    [SerializeField]
    private GameObject _enemy2Prefab;
    [SerializeField]
    private GameObject _enemy3Prefab;
    [SerializeField]
    private GameObject _enemy4Prefab;
    [SerializeField]
    private GameObject _enemy5Prefab;
    [SerializeField]
    private GameObject _enemyContainer;
    [SerializeField]
    private GameObject _itemContainer;
    [SerializeField]
    private GameObject _healthPrefab;
    [SerializeField]
    private GameObject _shieldPrefab;
    [SerializeField]
    private GameObject _tsPrefab;
    [SerializeField]
    private GameObject _speedPrefab;
    private bool _deadCheck = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnAsteroid());
        StartCoroutine(SpawnRoutine1());
        StartCoroutine(SpawnRoutine2());
        StartCoroutine(SpawnRoutine3());
        StartCoroutine(SpawnRoutine4());
        StartCoroutine(SpawnRoutine5());
        StartCoroutine(SpawnRoutineHealth());
        StartCoroutine(SpawnRoutineTS());
        StartCoroutine(SpawnRoutineSpeed());
        StartCoroutine(SpawnRoutineShield());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // spawn game objects with xyz position at time t

    IEnumerator SpawnAsteroid()
    {
        while (!_deadCheck)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(-10f, 10f), 7, 0);
            GameObject newEnemy = Instantiate(_asteroidPrefab, posToSpawn, Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(15f);
        }
    }
    IEnumerator SpawnRoutine1()
    {
        while (!_deadCheck)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(-9f, 9f), 7, 0);
            GameObject newEnemy = Instantiate(_enemy1Prefab, posToSpawn, Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(3f);
        }
    }
    IEnumerator SpawnRoutine2()
    {
        int counter = 0;
        while (!_deadCheck)
        {
            if (counter > 5)
            {
                Vector3 posToSpawn = new Vector3(Random.Range(-9f, 9f), 7, 0);
                GameObject newEnemy = Instantiate(_enemy2Prefab, posToSpawn, Quaternion.identity);
                newEnemy.transform.parent = _enemyContainer.transform;
            }
            counter++;
            yield return new WaitForSeconds(4f);
        }
    }

    IEnumerator SpawnRoutine3()
    {
        int counter = 0;
        while (!_deadCheck)
        {
            if (counter > 10)
            {
                Vector3 posToSpawn = new Vector3(Random.Range(-9f, 9f), 7, 0);
                GameObject newEnemy = Instantiate(_enemy3Prefab, posToSpawn, Quaternion.identity);
                newEnemy.transform.parent = _enemyContainer.transform;
            }
            counter++;
            yield return new WaitForSeconds(5f);
        }
    }

    IEnumerator SpawnRoutine4()
    {
        int counter = 0;
        while (!_deadCheck)
        {
            if (counter > 30)
            {
                Vector3 posToSpawn = new Vector3(Random.Range(-7f, 7f), 7, 0);
                GameObject newEnemy = Instantiate(_enemy4Prefab, posToSpawn, Quaternion.identity);
                newEnemy.transform.parent = _enemyContainer.transform;
            }
            counter++;
            yield return new WaitForSeconds(2.5f);
        }
    }

    IEnumerator SpawnRoutine5()
    {
        int counter = 0;
        while (!_deadCheck)
        {
            if (counter > 10)
            {
                Vector3 posToSpawn = new Vector3(Random.Range(-9f, 9f), 7, 0);
                GameObject newEnemy = Instantiate(_enemy5Prefab, posToSpawn, Quaternion.identity);
                newEnemy.transform.parent = _enemyContainer.transform;
            }
            counter++;
            yield return new WaitForSeconds(8f);
        }
    }

    IEnumerator SpawnRoutineHealth()
    {
        int counter = 0;
        while (!_deadCheck)
        {
            if (counter > 0)
            {
                Vector3 posToSpawn = new Vector3(Random.Range(-9f, 9f), 7, 0);
                GameObject healItem = Instantiate(_healthPrefab, posToSpawn, Quaternion.identity);
                healItem.transform.parent = _itemContainer.transform;
            }
            counter++;
            yield return new WaitForSeconds(50.0f+(counter-1)* Random.Range(7f, 15f));
        }
    }

    IEnumerator SpawnRoutineTS()
    {
        int counter = 0;
        while (!_deadCheck)
        {
            if (counter > 0)
            {
                Vector3 posToSpawn = new Vector3(Random.Range(-9f, 9f), 7, 0);
                GameObject tsItem = Instantiate(_tsPrefab, posToSpawn, Quaternion.identity);
                tsItem.transform.parent = _itemContainer.transform;
            }
            counter++;
            yield return new WaitForSeconds(40.0f + (counter - 1) * Random.Range(5f, 12f));
        }
    }

    IEnumerator SpawnRoutineSpeed()
    {
        int counter = 0;
        while (!_deadCheck)
        {
            if (counter > 0)
            {
                Vector3 posToSpawn = new Vector3(Random.Range(-9f, 9f), 7, 0);
                GameObject speedItem = Instantiate(_speedPrefab, posToSpawn, Quaternion.identity);
                speedItem.transform.parent = _itemContainer.transform;
            }
            counter++;
            yield return new WaitForSeconds(45.0f + (counter - 1) * Random.Range(10f, 17f));
        }
    }

    IEnumerator SpawnRoutineShield()
    {
        int counter = 0;
        while (!_deadCheck)
        {
            if (counter > 0)
            {
                Vector3 posToSpawn = new Vector3(Random.Range(-9f, 9f), 7, 0);
                GameObject shieldItem = Instantiate(_shieldPrefab, posToSpawn, Quaternion.identity);
                shieldItem.transform.parent = _itemContainer.transform;
            }
            counter++;
            yield return new WaitForSeconds(60.0f + (counter - 1) * Random.Range(8f, 17f));
        }
    }

    public void PlayerDeath()
    {
        _deadCheck = true;
    }

    public bool getDeath()
    {
        return _deadCheck;
    }
}
