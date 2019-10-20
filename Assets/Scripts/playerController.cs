using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class playerController : MonoBehaviour
{

    private Rigidbody2D characterController;

    private Vector2 direction;
    private bool moveLeft = true,moveRight = true;
   

    void Start()
    {
        characterController = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 playerPosition = transform.position;
            if (Math.Abs(playerPosition.x - mousePosition.x) < 1)
            {
                Vector3 position = this.transform.position;
                if (Input.GetAxis("Mouse X") < 0 && moveLeft)
                {
                    movePlayer(playerPosition, position);
                }
                if (Input.GetAxis("Mouse X") > 0 && moveRight)
                {
                    movePlayer(playerPosition, position);
                }
            }
        }
    }

    private void movePlayer(Vector3 playerPosition, Vector3 position)
    {
        Vector2 movePosition = new Vector2(Input.GetAxis("Mouse X"), playerPosition.y);
        position.x += movePosition.x;
        this.transform.position = position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger 2d detected" + collision.gameObject.name);
        if (collision.gameObject.name.Equals("WallsLeft"))
        {
            moveLeft = false;
        }
        if (collision.gameObject.name.Equals("WallsRight"))
        {
            moveRight = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Exit trigger 2d" + collision.gameObject.name);
        moveLeft = true;
        moveRight = true;
    }
}
