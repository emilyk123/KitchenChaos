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

    private GameObject[] enemies;
    public float enemySpeed = 2.0f;
    public float minDist = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        totalDamage = 0;
        rb = this.GetComponent<Rigidbody2D>();
        player = FindObjectOfType<Player>();
        target = GameObject.FindWithTag("Player").transform;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
    }

    private void FixedUpdate() {
        Vector3 closestEnemy = Vector3.zero;
        float closestDist = minDist;
        foreach (var enemy in enemies) {
            if (enemy != null) {
                float curDist = Vector3.Distance(transform.position, enemy.transform.position);
                if (curDist < minDist) {
                    closestEnemy = enemy.transform.position;
                    closestDist = curDist;
                }
            }
        }

        if (Vector3.Distance(target.position, transform.position) > 0) {
            Vector3 dir = target.position - transform.position;
            if (closestDist < minDist) {
                Vector3 avoidDir = transform.position - closestEnemy;
                avoidDir = avoidDir.normalized * (1 - closestDist / minDist);
                dir += avoidDir;
            }
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
            dir.Normalize();
            rb.velocity = dir * enemySpeed;
        }
    }
    void OnTriggerEnter2D(Collider2D collider) {
        if(collider.tag == "Bullet") {
            totalDamage += bulletScript.damage;
            if(totalDamage == enemyHealth) {
                LevelSystem.instance.AddXP(enemyEXP);
                Destroy(gameObject);
            }
        }
    }

    void Fire() {
        if(Time.time > shootingTime) {
            shootingTime = Time.time + fireRate;
            Vector2 myPos = new Vector2(weapon.position.x, weapon.position.y);
            GameObject projectile = Instantiate(bullet, myPos, Quaternion.identity);
            projectile.GetComponent<Bullet>().dir = (((Vector2)target.position - myPos).normalized) * shootingPower;
            projectile.layer = gameObject.layer;
        }
    }
}
