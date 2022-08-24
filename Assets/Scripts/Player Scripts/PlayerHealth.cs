using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    float playerMaxHealth = 100f;
    float playerHealth;

    [SerializeField]
    GameObject playerExplosionFX;

    [SerializeField]
    GameObject playerDamageFX;

    private void Awake()
    {
        playerHealth = playerMaxHealth;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(float damageAount)
    {
        playerHealth-=damageAount;
        if(playerHealth <= 0)
        {
            playerHealth = 0;
            Instantiate(playerExplosionFX,transform.position,Quaternion.identity);
            SoundManager.instance.PlayDestroySound();
            Destroy(gameObject);
        }
        else
        {
            Instantiate(playerDamageFX, transform.position, Quaternion.identity);
            SoundManager.instance.PlayDamageSound();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag==TagManager.METEOR_TAG)
        {
            TakeDamage(Random.Range(20f, 40f));
            Destroy(collision.gameObject);
        }
    }

}
