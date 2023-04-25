using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerManager : MonoBehaviour
{
    private TankControlsManager input = null;
    private Vector2 moveVector = Vector2.zero;
    private Rigidbody2D playerRB = null;
    private float moveSpeed = 5f;

    private void Awake()
    {
        input = new TankControlsManager();
        playerRB = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        input.Enable();
        input.Player.TankMovement.performed += OnMovementPerformed;
        input.Player.TankMovement.canceled += OnMovementCancelled;
    }

    private void OnDisable()
    {
        input.Disable();
        input.Player.TankMovement.performed -= OnMovementPerformed;
        input.Player.TankMovement.canceled -= OnMovementCancelled;
    }

    void FixedUpdate()
    {
        playerRB.velocity= moveVector * moveSpeed;
    }

    private void OnMovementPerformed(InputAction.CallbackContext value)
    {
        moveVector= value.ReadValue<Vector2>();
    }
    private void OnMovementCancelled(InputAction.CallbackContext value)
    {
        moveVector = Vector2.zero;
    }
}
