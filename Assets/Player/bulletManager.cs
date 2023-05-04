using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class bulletManager : MonoBehaviour
{
    public Rigidbody2D bulletRB;
    Camera _mainCam;
    UnityEngine.Vector2 _screenBounds;
    public string creator;

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

    private void OnTriggerEnter2D(Collider2D hitinfo)
    {
        if(hitinfo.tag!=creator)
        {
            switch(hitinfo.tag)
            {
                case "Enemy":
                    enemyManager enemy = hitinfo.GetComponent<enemyManager>();
                    if (enemy != null)
                    {
                        enemy.takeDamage(25);
                        Destroy(gameObject);
                    }
                    break;
                case "Player":
                    playerManager player = hitinfo.GetComponent<playerManager>();
                    if (player != null)
                    {
                        player.takeDamage(5);
                        Destroy(gameObject);
                    }
                    break;
                default:
                    Destroy(gameObject); break;
            }

        }
    }
}
