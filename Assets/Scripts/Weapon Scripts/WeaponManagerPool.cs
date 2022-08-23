using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManagerPool : MonoBehaviour
{
    [SerializeField]
    GameObject projectile;

    List<GameObject> projectilePool = new List<GameObject>();

    GameObject projectileHolder;

    [SerializeField]
    KeyCode keyToPressToShoot;

    bool projectileSpawned;

    [SerializeField]
    Transform projectileSpawnPoint;

    [SerializeField]
    float shootWaitTime = 0.2f;

    float shootTimer;
    bool canShoot;

    [SerializeField]
    bool isEnemy;

    private void Awake()
    {
        if (isEnemy)
        {
            projectileHolder = GameObject.FindWithTag(TagManager.ENEMY_PROJECTILE_HOLDER_TAG);
        }
        else
        {
            projectileHolder = GameObject.FindWithTag(TagManager.PLAYER_PROJECTILE_HOLDER_TAG);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > shootTimer)
        {
            canShoot = true;
        }
        HandlePlayerShooting();
        HandleEnemyShooting();
    }

    private void HandlePlayerShooting()
    {
        if (!canShoot || isEnemy)
        {
            return;
        }
        if (Input.GetKeyDown(keyToPressToShoot))
        {
            GetObjectFromPoolOrSpawnANewOne();
            ResetShootingTimer();
        }
    }
    void GetObjectFromPoolOrSpawnANewOne()
    {
        for (int i=0;i<projectilePool.Count;i++)
        {
            if (!projectilePool[i].activeInHierarchy)
            {
                projectilePool[i].transform.position = projectileSpawnPoint.position;
                projectilePool[i].SetActive(true);

                projectileSpawned = true;
                break;
            }
            else
            {
                projectileSpawned = false;
            }
            
        }
        if (!projectileSpawned)
        {
            GameObject newProjectile = Instantiate(projectile, projectileSpawnPoint.position, Quaternion.identity);
            projectilePool.Add(newProjectile);
            newProjectile.transform.SetParent(projectileHolder.transform);
            projectileSpawned = true;
        }
    }
    void ResetShootingTimer()
    {
        canShoot = true;
        if (isEnemy)
        {
            shootTimer = Time.time + UnityEngine.Random.Range(shootWaitTime,(shootWaitTime+1f));
        }
        else
        {
            shootTimer = Time.time + shootWaitTime;
        }
        
    }
    void HandleEnemyShooting()
    {

    }

}
