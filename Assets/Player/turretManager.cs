using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class turretManager : MonoBehaviour
{
    private TankControlsManager input = null;
    private float turner = 0f;
    float _turnSpeed = 100f;
    public GameObject bullet;

    private void Awake()
    {
        input = new TankControlsManager();
    }

    private void OnEnable()
    {
        input.Enable();
        input.Player.TurretRotation.performed += OnRotatePerformed;
        input.Player.TurretRotation.canceled += OnRotateCancelled;
        input.Player.TurretShoot.performed += onShootPerformed;
    }

    private void OnDisable()
    {
        input.Disable();
        input.Player.TurretRotation.performed -= OnRotatePerformed;
        input.Player.TurretRotation.canceled -= OnRotateCancelled;
    }
    private void OnRotatePerformed(InputAction.CallbackContext value)
    {
        turner = value.ReadValue<float>();
    }
    private void OnRotateCancelled(InputAction.CallbackContext value)
    {
        turner = 0f;
    }

    private void onShootPerformed(InputAction.CallbackContext value)
    {
        GameObject newobject = Instantiate(bullet, transform.position, transform.rotation);
        newobject.GetComponent<bulletManager>()._travelDirection = new Vector2(-transform.right.y, transform.right.x);
    }

    private void FixedUpdate()
    {
        transform.Rotate(Vector3.forward, -turner * _turnSpeed * Time.deltaTime);
    }
}
