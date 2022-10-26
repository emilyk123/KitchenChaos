using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject bullet;
    public Bullet bulletScript;
    private Player player;
    private Rigidbody2D rb;
    private int enemyEXP = 10;
    private int enemyHealth = 4;
    private int totalDamage = 0;

    public Transform target;
    public Transform weapon;
    public Vector2 direction;
    public float fireRate = 1.0f;
    public float shootingPower = 1.0f;
    public float shootingTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        totalDamage = 0;
        rb = this.GetComponent<Rigidbody2D>();
        player = FindObjectOfType<Player>();

    }

    // Update is called once per frame
    void Update()
    {
        Fire();
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if(collider.tag == "Bullet") {
            totalDamage += bulletScript.damage;
            if(totalDamage == enemyHealth) {
                LevelSystem.instance.AddXP(enemyEXP);
                Destroy(gameObject);
            }
        }
    }

    private void Fire() {
        if(Time.time > shootingTime) {
            shootingTime = Time.time + fireRate;
            Vector2 myPos = new Vector2(weapon.position.x, weapon.position.y);
            GameObject projectile = Instantiate(bullet, myPos, Quaternion.identity);
            projectile.GetComponent<Bullet>().dir = (((Vector2)target.position - myPos).normalized) * shootingPower;
            projectile.layer = gameObject.layer;
        }
    }
}
