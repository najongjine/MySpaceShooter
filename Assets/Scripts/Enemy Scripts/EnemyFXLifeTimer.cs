using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFXLifeTimer : MonoBehaviour
{
    [SerializeField]
    float timer = 3f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,timer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
