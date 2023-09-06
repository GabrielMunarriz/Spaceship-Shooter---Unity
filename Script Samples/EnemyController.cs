using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Rigidbody2D EnemyRigidBody;

    public GameObject Bullet;
    public Color BulletColor;

    public GameObject Explosion;
    
    public float enemyHorizontalSpeed;
    public float enemyVerticalSpeed;
    public float enemyFireRate;
    public float enemyHealth;
    public bool enemyCanShoot;

    void Awake()
    {
        EnemyRigidBody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        Destroy(gameObject, 12);
        if (enemyCanShoot)
        {
            InvokeRepeating("EnemyShoot", 2, enemyFireRate);
        }
    }

    void Update()
    {
        EnemyRigidBody.velocity = new Vector2(enemyHorizontalSpeed,enemyVerticalSpeed*-1);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<PlayerController>().PlayerDamage();
            EnemyDie();
        }
    }

    void EnemyDie()
    {
        Instantiate(Explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    public void EnemyDamage()
    {
        enemyHealth--;
        if(enemyHealth == 0)
        {
            EnemyDie();
        }
    }

    void EnemyShoot()
    {
        GameObject temp = (GameObject) Instantiate(Bullet, transform.position, Quaternion.identity);
        temp.GetComponent<Bullet>().ChangeDirection();
        temp.GetComponent<Bullet>().ChangeColor(BulletColor);
    }
}
