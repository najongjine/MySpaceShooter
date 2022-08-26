using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SpawnPositionEnum
{
    Up,
    Down,
    Left,
    Right
}
public class ShipFxSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject[] ships;

    List<GameObject> spawnedShips = new List<GameObject>();

    public SpawnPositionEnum spawnPosEnum;

    [SerializeField]
    float minSpawnTime = 5f, maxSpawnTime = 10f;
    float spawnTimer;
    bool shipSpawned;
    Vector3 spawnPos;

    [SerializeField]
    float minX=-50f, maxX=50f;
    [SerializeField]
    float minY = -27f, maxY = 27f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnShip()
    {
        shipSpawned = false;
        for (int i=0;i<spawnedShips.Count;i++)
        {
            if (!spawnedShips[i].activeInHierarchy)
            {
                spawnedShips[i].SetActive(true);
            }
        }
    }
    void ActivateShip(GameObject ship)
    {
        ship.SetActive(true);
        if (spawnPosEnum==SpawnPositionEnum.Up)
        {

        }
        else if (spawnPosEnum == SpawnPositionEnum.Down)
        {

        }
        else if (spawnPosEnum == SpawnPositionEnum.Left)
        {

        }
        else if (spawnPosEnum == SpawnPositionEnum.Right)
        {

        }
    }

}
