using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float speed;



    private Rigidbody2D playerRigidBody;
    private Vector3 mousePosition;
    private Vector2 direction;

    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 mouseDirection;

            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            direction = (mousePosition - transform.position).normalized;

            mouseDirection = new Vector2(direction.x * speed, direction.y * speed);
            playerRigidBody.velocity = mouseDirection;

            transform.up = direction;

        } else
        {
            playerRigidBody.velocity = Vector2.zero;
        }
    }
}
