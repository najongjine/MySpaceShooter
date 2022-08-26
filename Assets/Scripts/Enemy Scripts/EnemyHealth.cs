using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    GameObject healthBar;

    Vector3 healthBarScale;

    [SerializeField]
    float health = 100f;
    [SerializeField]
    float maxHealth = 100f;

    [SerializeField]
    GameObject destroyEffect;

    [SerializeField]
    GameObject hitEffect;

    DropCollectable dropCollectable;

    private void Awake()
    {
        dropCollectable=GetComponent<DropCollectable>();
    }
    // Start is called before the first frame update
    void Start()
    {
        var device_uid=SystemInfo.deviceUniqueIdentifier;
        Debug.Log($"## device uid: {device_uid}");
        var d_platform = Application.platform;
        Debug.Log($"## platform: {d_platform.ToString()}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(float damageAmount, float damageResistance)
    {
        damageAmount-=damageResistance;
        health -= damageAmount;
        if (health<=0)
        {
            health = 0f;
            Instantiate(destroyEffect, transform.position, Quaternion.identity);
            if (gameObject.tag==TagManager.ENEMY_TAG)
            {
                GameplayUIController.instance.SetInfo(2);
                EnemySpawner.instance.CheckToSpawnNewWave(gameObject);
            }else if (gameObject.tag == TagManager.METEOR_TAG)
            {
                GameplayUIController.instance.SetInfo(3);
            }
            SoundManager.instance.PlayDestroySound();
            dropCollectable.CheckToSpawnCollectable();
            Destroy(gameObject);
        }
        else
        {
            Instantiate(hitEffect, transform.position, Quaternion.identity);
            SoundManager.instance.PlayDamageSound();
        }
        SetHealthBar();
    }
    void SetHealthBar()
    {
        if (!healthBar)
        {
            return;
        }
        healthBarScale = healthBar.transform.localScale;
        healthBarScale.x = health / maxHealth;
        healthBar.transform.localScale = healthBarScale;
    }

}
