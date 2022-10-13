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

    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Bullet") {
            totalDamage += bulletScript.damage;
            if(totalDamage == enemyHealth) {
                LevelSystem.instance.AddXP(enemyEXP);
                Destroy(gameObject);
            }
        }
        if(other.tag == "Player") {
            player.Health -= 5;
        }
    }
}
