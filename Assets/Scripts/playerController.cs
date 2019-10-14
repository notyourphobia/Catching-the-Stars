using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float speed;

    public float maxRotation;
    public float maxHoldSeconds;
    public float speedDecrease;

    public float mouseHold;

    private Rigidbody2D playerRigidBody;
    private Vector3 mousePosition;
    private Vector2 direction;
    private float rotation;

    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        mouseHold = 0;
    }

    void Update()
    {
        rotation = transform.rotation.eulerAngles.z;

        if (Input.GetMouseButton(0))
        {
            ///Get Mouse On Screen///
            Vector2 mouseDirection;
            
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            direction = (mousePosition - transform.position).normalized;

            mouseDirection = new Vector2(direction.x * speed, direction.y * speed);
            ///Move Player To Point///
            playerRigidBody.velocity = mouseDirection;

            transform.up = direction;
            ///Rotation Controls///W I P///
            if (transform.rotation.eulerAngles.z > maxRotation)
            {
                transform.localRotation = Quaternion.EulerAngles(0, 0, maxRotation);
            }
            else if (rotation < -maxRotation)
            {
                transform.localRotation = Quaternion.EulerAngles(0, 0, -maxRotation);
            }
            ///Mouse Hold Clock///

            mouseHold += Time.deltaTime;
            if (mouseHold > maxHoldSeconds)
            {
                mouseHold = maxHoldSeconds;
            }
        } else
        {
            ///Stop And Decrease Everything///W I P///
            mouseHold -= speedDecrease * Time.deltaTime;
            if (mouseHold < 0)
            {
                mouseHold = 0;
            }
            playerRigidBody.velocity = Vector2.zero;
            transform.localRotation = Quaternion.EulerAngles(0, 0, 0);
        }
    }
}
