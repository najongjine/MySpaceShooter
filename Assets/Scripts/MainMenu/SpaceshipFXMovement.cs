using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipFXMovement : MonoBehaviour
{
    [SerializeField]
    float minSpeed = 5f, maxSpeed = 10f;
    float moveSpeed;
    Vector3 tempPos;

    bool moveVertical, moveHortizontal;

    private void Awake()
    {
        moveSpeed = Random.Range(minSpeed, maxSpeed);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveVertical();
        MoveHorizontal();
    }
    void MoveVertical()
    {
        if (!moveVertical)
        {
            return;
        }
        tempPos = transform.position;
        tempPos.y += moveSpeed * Time.deltaTime;
        transform.position = tempPos;
    }
    void MoveHorizontal()
    {
        if (!moveHortizontal)
        {
            return;
        }
        tempPos = transform.position;
        tempPos.x += moveSpeed * Time.deltaTime;
        transform.position = tempPos;
    }
    public void SetMovement(bool verticalMovement, bool horizontalMovement, bool moveNegative)
    {
        moveVertical = verticalMovement;
        moveHortizontal = horizontalMovement;
        if (moveNegative)
        {
            moveSpeed *= -1f;
        }
    }
}
