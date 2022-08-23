using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    bool moveOnX, moveOnY;

    float min_X,max_X;
    float min_Y, max_Y;

    [SerializeField]
    float moveSpeed=8f;

    [SerializeField]
    float horizontal_MovementTreshold = 8f;

    [SerializeField]
    float vertical_MovementTreshold = 6f;

    Vector3 tempMovement_Horizontal;
    Vector3 tempMovement_Vertical;

    bool moveLeft;
    bool moveUp=false;
    // Start is called before the first frame update
    void Start()
    {
        min_X = transform.position.x - horizontal_MovementTreshold;
        max_X = transform.position.x + horizontal_MovementTreshold;

        max_Y = transform.position.y;
        min_Y = transform.position.y - vertical_MovementTreshold;

        if (Random.Range(0,2)>0)
        {
            moveLeft = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        HandleEnemyMovement_Horizontal();
        HandleEnemyMovement_Vertical();
    }
    void HandleEnemyMovement_Horizontal()
    {
        if (!moveOnX)
        {
            return;
        }
        if (moveLeft)
        {
            tempMovement_Horizontal = transform.position;
            tempMovement_Horizontal.x -= moveSpeed * Time.deltaTime;
            transform.position = tempMovement_Horizontal;
            if (tempMovement_Horizontal.x<min_X)
            {
                moveLeft=false;
            }
        }
        else
        {
            tempMovement_Horizontal = transform.position;
            tempMovement_Horizontal.x += moveSpeed * Time.deltaTime;
            transform.position = tempMovement_Horizontal;
            if (tempMovement_Horizontal.x > max_X)
            {
                moveLeft = true;
            }
        }
    }
    void HandleEnemyMovement_Vertical()
    {
        if (!moveOnY)
        {
            return;
        }
        if (moveUp)
        {
            tempMovement_Vertical = transform.position;
            tempMovement_Vertical.y += moveSpeed * Time.deltaTime;
            transform.position = tempMovement_Vertical;
            if (tempMovement_Vertical.y > max_Y)
            {
                moveUp = false;
            }
        }
        else
        {
            tempMovement_Vertical = transform.position;
            tempMovement_Vertical.y -= moveSpeed * Time.deltaTime;
            transform.position = tempMovement_Vertical;
            if (tempMovement_Vertical.y < min_Y)
            {
                moveUp = true;
            }
        }
    }

}
