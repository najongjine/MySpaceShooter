using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    float playerMaxHealth = 100f;
    float playerHealth;

    [SerializeField]
    GameObject playerExplosionFX;

    [SerializeField]
    GameObject playerDamageFX;

    Collectable collectable;

    Slider playerHealthSlider;
    private void Awake()
    {
        playerHealthSlider=GameObject.FindGameObjectWithTag(TagManager.PLAYER_HEALTH_SLIDER_TAG).GetComponent<Slider>();
        playerHealth = playerMaxHealth;
        playerHealthSlider.minValue = 0;
        playerHealthSlider.maxValue = playerMaxHealth;
        playerHealthSlider.value = playerHealth;
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
            GameOverUIController.instance.OpenGameOverPanel();
            Destroy(gameObject);
        }
        else
        {
            Instantiate(playerDamageFX, transform.position, Quaternion.identity);
            SoundManager.instance.PlayDamageSound();
        }
        playerHealthSlider.value = playerHealth;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == TagManager.COLLECTABLE_TAG)
        {
            collectable= collision?.GetComponent<Collectable>();
            if (collectable?.type==CollectableType.Health)
            {
                playerHealth += collectable.healthValue;
                if (playerHealth>playerMaxHealth)
                {
                    playerHealth=playerMaxHealth;
                }
                playerHealthSlider.value = playerHealth;
                Destroy(collectable.gameObject);
            }
        }
        if (collision.gameObject.tag==TagManager.METEOR_TAG)
        {
            TakeDamage(Random.Range(20f, 40f));
            Destroy(collision.gameObject);
        }
    }

}
