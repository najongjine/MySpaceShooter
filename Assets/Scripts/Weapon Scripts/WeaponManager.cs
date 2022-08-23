using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField]
    GameObject[] projectiles;

    [SerializeField]
    Transform[] projectileSpawnPoints;

    [SerializeField]
    float shootTimerTreshold = 0.2f;
    float shootTimer;

    bool canShoot;
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
    }
    void HandlePlayerShooting()
    {
        if (!canShoot)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            Instantiate(projectiles[0], projectileSpawnPoints[0].position,Quaternion.identity);
            Instantiate(projectiles[0], projectileSpawnPoints[1].position, Quaternion.identity);
            ResetShootingTimer();
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            Instantiate(projectiles[1], projectileSpawnPoints[0].position, Quaternion.identity);
            Instantiate(projectiles[1], projectileSpawnPoints[1].position, Quaternion.identity);
            ResetShootingTimer();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            Instantiate(projectiles[2], projectileSpawnPoints[0].position, Quaternion.identity);
            Instantiate(projectiles[2], projectileSpawnPoints[1].position, Quaternion.identity);
            ResetShootingTimer();
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            Instantiate(projectiles[3], projectileSpawnPoints[2].position, Quaternion.identity);
            ResetShootingTimer();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            Instantiate(projectiles[4], projectileSpawnPoints[2].position, Quaternion.identity);
            ResetShootingTimer();
        }
    }
    void ResetShootingTimer()
    {
        canShoot = false;
        shootTimer = Time.time + shootTimerTreshold;
    }
}
