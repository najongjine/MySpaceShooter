using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyMovementInPoints : MonoBehaviour
{
    [SerializeField]
    Transform[] movementPoints;

    int currentMoveIndex;
    Vector3 targetPosition;

    [SerializeField]
    float moveSpeed = 8f;
    [SerializeField]
    bool moveRandomly;
    // Start is called before the first frame update
    void Start()
    {
        SetTargetPosition();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position,targetPosition)<0.1f)
        {
            SetTargetPosition();
        }

    }
    private void SetTargetPosition()
    {
        if (moveRandomly)
        {
            SelectRandomPosition();
        }
        else
        {
            SelectPointToPointPosition();
        }
    }
    void SelectRandomPosition()
    {
        while (movementPoints[currentMoveIndex].position == targetPosition)
        {
            currentMoveIndex=Random.Range(0,movementPoints.Length);
        }
        targetPosition = movementPoints[currentMoveIndex].position;
    }
    void SelectPointToPointPosition()
    {
        if (currentMoveIndex>=movementPoints.Length)
        {
            currentMoveIndex = 0;
        }
        targetPosition = movementPoints[currentMoveIndex].position;
        currentMoveIndex++;
    }

}
