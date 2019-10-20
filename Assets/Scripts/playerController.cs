using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class playerController : MonoBehaviour
{

    private Rigidbody2D characterController;

    private Vector2 direction;
   

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
                Vector2 movePosition = new Vector2(Input.GetAxis("Mouse X"), playerPosition.y);
                position.x += movePosition.x;
                this.transform.position = position;
            }
        }
    }

    void OnCollisionEnter(Collision other)
    {
        Debug.Log(other.gameObject.name);
        
    }
}
