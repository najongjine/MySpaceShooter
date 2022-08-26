using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorFXMovement : MonoBehaviour
{
    [SerializeField]
    float minSpeed = 5f, maxSpeed = 10f;
    [SerializeField]
    float minRotateSpeed = 10f, maxRotateSpeed = 20f;

    float speedY,speedX;

    float rotationSpeed = 5f;

    float zRotation;

    bool moveOnX;

    Vector3 tempPos;

    [HideInInspector]
    public bool moveUp;

    private void Awake()
    {
        speedY=Random.Range(minSpeed,maxSpeed);
        speedX=Random.Range(minSpeed,maxSpeed); 
        if (Random.Range(0,2)>0)
        {
            moveOnX=true;
        }
        if (Random.Range(0, 2) > 0)
        {
            speedX *= -1f;
        }
        rotationSpeed = Random.Range(minRotateSpeed, maxRotateSpeed);
    }
    // Start is called before the first frame update
    void Start()
    {
        if (moveUp)
        {
            speedY *= -1f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
        HandleRotation();
    }
    void HandleMovement()
    {
        tempPos=transform.position; 
        tempPos.y-=speedY*Time.deltaTime;
        transform.position = tempPos;

        if (!moveOnX)
        {
            return;
        }
        tempPos = transform.position;
        tempPos.x += speedX * Time.deltaTime;
        transform.position = tempPos;
    }
    void HandleRotation()
    {
        zRotation += rotationSpeed * Time.deltaTime;
        transform.rotation = Quaternion.AngleAxis(zRotation, Vector3.forward);
    }

}
