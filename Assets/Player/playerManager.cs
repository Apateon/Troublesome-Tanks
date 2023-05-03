using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerManager : MonoBehaviour
{
    private TankControlsManager input = null;
    private Vector2 moveVector = Vector2.zero;
    private Rigidbody2D playerRB = null;
    private float moveSpeed = 2f;

    public float maxHealth = 100f;
    public float currentHealth;

    public HealthBarScript healthBar;
    public HealthBarScript reloadBar;

    public float reloadTime = 2f;
    public float lastTime = 0f;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        reloadBar.SetMaxHealth(reloadTime);
    }

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
        playerRB.velocity = moveVector * moveSpeed;
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -9.7f, 9.7f), Mathf.Clamp(transform.position.y, -4.27f, 4.27f), transform.position.z);
        reloadBar.SetHealth(Time.time - lastTime);
    }

    private void OnMovementPerformed(InputAction.CallbackContext value)
    {
        moveVector= value.ReadValue<Vector2>();
    }
    private void OnMovementCancelled(InputAction.CallbackContext value)
    {
        moveVector = Vector2.zero;
    }

    public void takeDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
}
