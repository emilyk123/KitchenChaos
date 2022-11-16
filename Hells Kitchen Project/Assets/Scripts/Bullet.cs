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

    private float stopwatch;
    private float deathTime = 2f;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        player = FindObjectOfType<Player>();
        rb.velocity = dir;
    }

    void FixedUpdate()
    {
        //Counts down until its death, so bullets don't stay forever
        stopwatch += Time.fixedDeltaTime;

        if (stopwatch >= deathTime)
        {
            Object.Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag != "Bullet" && collider.tag != "Boundary")
        {
            Object.Destroy(this.gameObject);
        }
    }
}
