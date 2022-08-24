using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementRandom : MonoBehaviour
{
    [SerializeField]
    float min_X, max_X;
    [SerializeField]
    float min_Y, max_Y;
    [SerializeField]
    float moveSpeed = 8f;

    Vector3 targetPosition;
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
    void SetTargetPosition()
    {
        targetPosition = new Vector3(Random.Range(min_X, max_X)
            , Random.Range(min_Y, max_Y) , 0f);
    }
    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position,targetPosition, moveSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position,targetPosition)<0.1f)
        {
            SetTargetPosition();
        }
    }

}
