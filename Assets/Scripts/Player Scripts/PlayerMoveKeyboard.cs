using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveKeyboard : MonoBehaviour
{
    [SerializeField]
    float speed = 600f;

    Rigidbody2D myBody;

    // Start is called before the first frame update
    void Start()
    {
        myBody=GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        HandleMovement();
    }
    void HandleMovement()
    {
        if (Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.UpArrow))
        {
            myBody.AddForce(transform.up * speed);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            myBody.AddForce(-transform.up * speed);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            myBody.AddForce(transform.right * speed);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            myBody.AddForce(-transform.right * speed);
        }
    }

}
