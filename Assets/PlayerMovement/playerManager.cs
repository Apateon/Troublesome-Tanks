using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerManager : MonoBehaviour
{
    public Rigidbody2D playerRB;

    public float _playermoveSpeed = 5f;
    Vector2 movement;

    //Physics Update
    void FixedUpdate()
    {
        playerRB.MovePosition(playerRB.position + (movement * _playermoveSpeed * Time.fixedDeltaTime));
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Tank Horizontal");
        movement.y = Input.GetAxisRaw("Tank Vertical");
    }
}
