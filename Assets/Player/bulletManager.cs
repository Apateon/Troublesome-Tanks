using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class bulletManager : MonoBehaviour
{
    public float _bulletSpeed = 5f;
    public UnityEngine.Vector2 _travelDirection;
    public Rigidbody2D bulletRB;
    Camera _mainCam;
    UnityEngine.Vector2 _screenBounds;

    private void Start()
    {
        _mainCam = Camera.main;
        _screenBounds = _mainCam.ScreenToWorldPoint(new UnityEngine.Vector3(Screen.width, Screen.height, _mainCam.transform.position.z));
    }
    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > _screenBounds.x || transform.position.x < -_screenBounds.x || transform.position.y > _screenBounds.y || transform.position.y < -_screenBounds.y)
            Destroy(gameObject);
    }
    private void FixedUpdate()
    {
        bulletRB.MovePosition(bulletRB.position + (_travelDirection * _bulletSpeed * Time.fixedDeltaTime));
    }
}
