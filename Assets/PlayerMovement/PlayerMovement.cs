using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;

    public float _playerSpeed = 5f;
    Vector2 movement;

    //Physics Update
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + (movement * _playerSpeed * Time.fixedDeltaTime));
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }
}
