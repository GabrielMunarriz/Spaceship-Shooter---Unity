using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D BulletRigidBody;
    int Direction=1;

    public GameObject Explosion;

    void Awake()
    {
        BulletRigidBody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        Destroy(gameObject, 5);
    }

    public void ChangeDirection()
    {
        Direction *= -1;
    }

    public void ChangeColor(Color col)
    {
        GetComponent<SpriteRenderer>().color = col;
    }

    void Update()
    {
        BulletRigidBody.velocity = new Vector2(0,12*Direction);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(Direction == 1)
        {
            if(col.gameObject.tag == "Enemy")
            {
                col.gameObject.GetComponent<EnemyController>().EnemyDamage();
                Instantiate(Explosion, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
        else
        {
            if(col.gameObject.tag == "Player")
            {
                col.gameObject.GetComponent<PlayerController>().PlayerDamage();
                Instantiate(Explosion, transform.position, Quaternion.identity);
                Destroy(gameObject);
            } 
        }
        
    }
}
