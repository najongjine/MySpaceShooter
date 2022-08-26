using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveVector : MonoBehaviour
{
    public float m_Speed=30f;
    Rigidbody2D theRB;
    public float x, y, minRot,maxRot;

    private void Awake()
    {
        theRB = GetComponent<Rigidbody2D>();    
    }
    // Start is called before the first frame update
    void Start()
    {
        transform.rotation=Quaternion.Euler(0,0,Random.Range(minRot,maxRot));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        theRB.velocity = transform.forward * m_Speed;
    }
}
