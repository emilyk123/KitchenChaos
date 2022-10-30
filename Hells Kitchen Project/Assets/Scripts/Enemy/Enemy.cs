using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject bullet;
    public Transform target;

    public int enemyHealth = 4;
    public int enemyEXP = 10;
    public float fireRate = 1.0f;
    public float shootingPower = 1.0f;
    public float shootingTime = 0.0f;

    private Rigidbody2D rb;
    public Animator anim;
    private float stopwatch;
    
    private Vector2 dirToTarget;
    private int totalDamage = 0;

    // Start is called before the first frame update
    void Start()
    {
        totalDamage = 0;
        rb = this.GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        dirToTarget = ((Vector2)target.position - (Vector2)rb.position).normalized;

        if (anim != null)
        {
            anim.SetFloat("X", dirToTarget.x);
            anim.SetFloat("Y", dirToTarget.y);
        }
    }
    

    private void Fire() {
        if(Time.time > shootingTime) {
            anim.SetTrigger("Shoot");
            shootingTime = Time.time + fireRate;
            GameObject projectile = Instantiate(bullet, (Vector2)rb.position + dirToTarget, Quaternion.identity);
            projectile.GetComponent<Bullet>().dir = dirToTarget * shootingPower;
            projectile.layer = gameObject.layer;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Bullet")
        {
            totalDamage += collider.GetComponent<Bullet>().damage; ;
            if (totalDamage == enemyHealth)
            {
                LevelSystem.instance.AddXP(enemyEXP);
                Destroy(gameObject);
            }
        }
    }
}
