using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   

    Rigidbody2D PlayerRigidBody;
    public int PlayerHealth = 3;
    public float playerSpeed;

    public GameObject Explosion;

    GameObject Cannon;
    public GameObject Bullet;
    int BulletDelay = 0;
    
    void Awake()
    {
        PlayerRigidBody = GetComponent<Rigidbody2D>();
        Cannon = transform.Find("Cannon").gameObject;
    }

    void Start()
    {
        
    }

    void Update()
    {
        PlayerRigidBody.AddForce(new Vector2(Input.GetAxis("Horizontal")*playerSpeed,0));
        PlayerRigidBody.AddForce(new Vector2(0, Input.GetAxis("Vertical")*playerSpeed));

        if(Input.GetKey(KeyCode.Space)&&BulletDelay>30)
        {
            PlayerShoot();
        }

        BulletDelay++;
    }

    void PlayerDie()
    {
        Instantiate(Explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    public void PlayerDamage()
    {
        PlayerHealth--;
        if (PlayerHealth == 0)
        {
            PlayerDie();
        }
    }

    void PlayerShoot()
    {
        BulletDelay = 0;
        Instantiate(Bullet,Cannon.transform.position,Quaternion.identity);
    }
}
