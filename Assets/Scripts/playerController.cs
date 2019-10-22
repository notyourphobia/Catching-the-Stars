using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class playerController : MonoBehaviour
{

    [SerializeField] private float xMin = -1.5f, 
                                   xMax = 1.5f;

    private Rigidbody2D characterController;

    private Vector2 direction;


    void Start()
    {
        characterController = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector3 playerPosition = transform.position;

        if (Input.GetButton("Fire1"))
        {     
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (Math.Abs(playerPosition.x - mousePosition.x) < 1)
            {
                Vector3 position = new Vector3(Mathf.Clamp(playerPosition.x, xMin, xMax),
                                   this.transform.position.y, 
                                   this.transform.position.z);
            
                if (Input.GetAxis("Mouse X") < 0)
                {
                    movePlayer(playerPosition, position);
                }
                if (Input.GetAxis("Mouse X") > 0)
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
}
