using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] meteors;

    [SerializeField]
    float minX, maxX;

    [SerializeField]
    float minSpawnInterval = 4f, maxSpawnInterval = 10f;

    [SerializeField]
    int minSpawnNumber=1,maxSpawnNumber=5;

    int randSpawnNum;
    Vector3 randSpawnPos;
    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(SpawnMeteors),Random.Range(minSpawnInterval,maxSpawnInterval));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnMeteors()
    {
        randSpawnNum = Random.Range(minSpawnNumber, maxSpawnNumber);
        for(int i = 0; i < randSpawnNum; i++)
        {
            randSpawnPos= new Vector3(Random.Range(minX,maxX),transform.position.y,0f);
            Instantiate(meteors[Random.Range(0, meteors.Length)], randSpawnPos, Quaternion.identity);
        }
        Invoke(nameof(SpawnMeteors), Random.Range(minSpawnInterval, maxSpawnInterval));
    }

}
