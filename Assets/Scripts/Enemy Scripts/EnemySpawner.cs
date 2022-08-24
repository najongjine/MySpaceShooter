using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner instance { get; private set; }

    [SerializeField]
    GameObject[] enemies;

    List<GameObject> spawnedEnemies = new List<GameObject>();

    [SerializeField]
    Transform[] spawnPoints;

    [SerializeField]
    float spawnWaitTime = 2f;

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
        else if (instance )
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(_SpawnWave(spawnWaitTime));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnNewWaveOfEnemies()
    {
        if(spawnedEnemies.Count > 0)
        {
            return;
        }
        for (int i=0;i<spawnPoints.Length;i++)
        {
            var newEnemy = Instantiate(enemies[Random.Range(0, enemies.Length)], spawnPoints[i].position,Quaternion.identity);
            spawnedEnemies.Add(newEnemy);
        }

        // Inform UI about wave number;
    }
    IEnumerator _SpawnWave(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SpawnNewWaveOfEnemies();
    }
    public void CheckToSpawnNewWave(GameObject shipToRemove)
    {
        spawnedEnemies.Remove(shipToRemove);
        if (spawnedEnemies.Count<=0)
        {
            StartCoroutine(_SpawnWave(spawnWaitTime));
        }
    }

}
