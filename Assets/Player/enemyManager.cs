using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyManager : MonoBehaviour
{
    public float health = 100f;

    public float enemyspeed;
    public float stoppingDistance;
    public float retreatingDistance;
    public Transform player;

    float timeBtwShots;
    float startTimeBtwShots = 3f;
    public GameObject bulletprefab;
    float bulletForce = 6f;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, enemyspeed * Time.deltaTime);
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -9.7f, 9.7f), Mathf.Clamp(transform.position.y, -4.27f, 4.27f), transform.position.z);
        }
        else if(Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatingDistance)
        {
            transform.position = this.transform.position;
        }
        else if (Vector2.Distance(transform.position,player.position) < retreatingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -enemyspeed * Time.deltaTime);
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -9.7f, 9.7f), Mathf.Clamp(transform.position.y, -4.27f, 4.27f), transform.position.z);
        }

        if (timeBtwShots <= 0)
        {
            Vector3 bulletpos = transform.position;
            bulletpos.z = 0.5f;
            GameObject bullet = Instantiate(bulletprefab, bulletpos, Quaternion.Euler((this.transform.position - player.position).normalized));
            bullet.GetComponent<bulletManager>().creator = "Enemy";
            bullet.GetComponent<Rigidbody2D>().AddForce((player.position - this.transform.position).normalized * bulletForce, ForceMode2D.Impulse);
            timeBtwShots = startTimeBtwShots;
        }
        else
            timeBtwShots -= Time.deltaTime;
    }

    public void takeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
            Die();
    }

    void Die()
    {
        Destroy(transform.parent.gameObject);
        Destroy(gameObject);
    }
}
