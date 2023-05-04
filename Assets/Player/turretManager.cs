using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class turretManager : MonoBehaviour
{
    private TankControlsManager input = null;
    private float turner = 0f;
    float _turnSpeed = 40f;
    public GameObject bulletprefab;
    public Transform firePoint;
    float bulletForce = 6f;

    public playerManager player;

    public static bool isPaused = false;

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
        if (!isPaused && Time.time - player.lastTime >= player.reloadTime)
        {
            Vector3 bulletPos = firePoint.position;
            bulletPos.z = 0.5f;
            GameObject bullet = Instantiate(bulletprefab, bulletPos, firePoint.rotation);
            bullet.GetComponent<bulletManager>().creator = "Player";
            bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
            player.lastTime = Time.time;

            // Add particle system
            ParticleSystem ps = GetComponentInChildren<ParticleSystem>();
            if (ps != null)
            {
                ps.Play();
            }
        }
    }

    private void FixedUpdate()
    {
        transform.Rotate(Vector3.forward, -turner * _turnSpeed * Time.deltaTime);
    }
}
