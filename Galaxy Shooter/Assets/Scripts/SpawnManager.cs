using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
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
    private GameObject _healthPrefab;
    [SerializeField]
    private GameObject _powerPrefab;
    private bool _deadCheck = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine1());
        StartCoroutine(SpawnRoutine2());
        StartCoroutine(SpawnRoutine3());
        StartCoroutine(SpawnRoutine4());
        StartCoroutine(SpawnRoutine5());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // spawn game objects with xyz position at time t

    IEnumerator SpawnRoutine1()
    {
        while (!_deadCheck)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(-9f, 9f), 7, 0);
            GameObject newEnemy = Instantiate(_enemy1Prefab, posToSpawn, Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(3.0f);
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
            yield return new WaitForSeconds(3.0f);
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
            yield return new WaitForSeconds(4.0f);
        }
    }

    IEnumerator SpawnRoutine4()
    {
        int counter = 0;
        while (!_deadCheck)
        {
            if (counter > 35)
            {
                Vector3 posToSpawn = new Vector3(Random.Range(-7f, 7f), 7, 0);
                GameObject newEnemy = Instantiate(_enemy3Prefab, posToSpawn, Quaternion.identity);
                newEnemy.transform.parent = _enemyContainer.transform;
            }
            counter++;
            yield return new WaitForSeconds(2.0f);
        }
    }

    IEnumerator SpawnRoutine5()
    {
        int counter = 0;
        while (!_deadCheck)
        {
            if (counter > 12)
            {
                Vector3 posToSpawn = new Vector3(Random.Range(-9f, 9f), 7, 0);
                GameObject newEnemy = Instantiate(_enemy3Prefab, posToSpawn, Quaternion.identity);
                newEnemy.transform.parent = _enemyContainer.transform;
            }
            counter++;
            yield return new WaitForSeconds(8.0f);
        }
    }

    public void PlayerDeath()
    {
        _deadCheck = true;
    }
}
