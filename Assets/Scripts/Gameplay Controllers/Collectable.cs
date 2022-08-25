using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CollectableType
{
    Health
   ,Blaster1
    ,Blaster2
    ,Rocket
    ,Missle
}

public class Collectable : MonoBehaviour
{
    public CollectableType type;

    [SerializeField]
    float moveSpeed = 5f;

    Vector3 tempPos;

    [HideInInspector]
    public float healthValue;

    float minHealth = 10f, maxHealth = 30f;
    // Start is called before the first frame update
    void Start()
    {
        healthValue=Random.Range(minHealth,maxHealth);
    }
    private void OnDisable()
    {
        SoundManager.instance.PlayPickUpSound();
    }

    // Update is called once per frame
    void Update()
    {
        tempPos= transform.position;
        tempPos.y -= moveSpeed * Time.deltaTime;
        transform.position = tempPos;
    }

}
