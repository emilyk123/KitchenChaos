using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector2 dir;
    public float speed = 5f;
    private Rigidbody2D rb;
    public GameObject enemy;
    public int damage = 1;
    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        player = FindObjectOfType<Player>();
        rb.velocity = dir * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Enemy") {
            Object.Destroy(this.gameObject);
        }

        if(other.tag == "Player") {
            player.Health -= 5;
        }
    }
}
