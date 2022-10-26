using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;

    private Animator anim;

    public float moveSpeed = 5f;

    private Vector2 movement;

    public GameObject bullet;

    public Enemy enemy;

    public float Health = 100f;

    private void Awake()
    {
        rb = this.GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        anim.SetFloat("MoveX", movement.x);
        anim.SetFloat("MoveY", movement.y);

        if (Input.GetButtonDown("Fire1"))
        {
            GameObject projectile = GameObject.Instantiate(bullet, rb.position, Quaternion.identity);
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            projectile.GetComponent<Bullet>().dir = ((mousePos - rb.position).normalized) * moveSpeed;
            projectile.layer = gameObject.layer;
<<<<<<< Updated upstream

            anim.SetBool("Shooting", true);
            anim.SetFloat("ShootX", (mousePos - rb.position).x);
            anim.SetFloat("ShootY", (mousePos - rb.position).y);
        }
        else
        {
            anim.SetBool("Shooting", false);
=======
>>>>>>> Stashed changes
        }
    }

    private void FixedUpdate()
    {
        movement = movement.normalized;
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

<<<<<<< Updated upstream
    private void OnTriggerEnter2D(Collider2D other)
    {
        Health -= 5;
    }
}
=======
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Health -= 5;
    }
}
>>>>>>> Stashed changes
