using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class turretManager : MonoBehaviour
{
    float _turnSpeed = 100f;
    float _degrees;
    public GameObject bullet;

    // Update is called once per frame
    void Update()
    {
        _degrees = Input.GetAxis("Turret Rotation");
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject newobject = Instantiate(bullet, transform.position + new Vector3(0f, 1f, 0f), transform.rotation);
            newobject.GetComponent<bulletManager>()._travelDirection = new Vector2(-transform.right.y, transform.right.x);
        }
    }
    private void FixedUpdate()
    {
        transform.Rotate(Vector3.forward, -_degrees * _turnSpeed * Time.deltaTime);
    }
}
