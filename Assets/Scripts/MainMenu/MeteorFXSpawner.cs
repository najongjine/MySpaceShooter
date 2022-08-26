using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorFXSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject[] meteors;

    [SerializeField]
    float minSpawnTime = 2f, maxSpawnTime = 5f;

    float spawnTimer;
    int spawnNum;

    [SerializeField]
    float minX, maxX;
    Vector3 spawnPos;

    [SerializeField]
    bool spawnUp;

    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = Time.time + Random.Range(minSpawnTime, maxSpawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > spawnTimer)
        {
            SpawnMeteor();
        }
    }
    void SpawnMeteor()
    {
        spawnNum = Random.Range(1,6);
        
        for(int i=0; i < spawnNum; i++)
        {
            spawnPos = new Vector3(Random.Range(minX, maxX), transform.position.y, 0f);
            var obj=Instantiate(meteors[Random.Range(0, meteors.Length)], spawnPos, Quaternion.identity);
            if (spawnUp)
            {
                obj.GetComponent<MeteorFXMovement>().moveUp = true;
            }
            
        }
        spawnTimer= Time.time+Random.Range(minSpawnTime,maxSpawnTime);
    }
}
