using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    float speed = 3f;

    public float minDamage = 5f;
    public float manDamage = 5f;

    float projectileDamage;

    [SerializeField]
    AudioClip spawnSound;
    [SerializeField]
    GameObject boomEffect;
    [SerializeField]
    AudioClip destroySound;

    // Start is called before the first frame update
    void Start()
    {
        projectileDamage=(int)Random.Range(minDamage, manDamage);
       
    }
    private void OnEnable()
    {
        if (spawnSound)
        {
            AudioSource.PlayClipAtPoint(spawnSound, new Vector3(0, 6f, 0));
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0,speed*Time.deltaTime,0);    
    }
}
