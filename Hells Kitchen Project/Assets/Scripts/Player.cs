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

    public BoxCollider2D boundBox;
    private SpriteRenderer playerSprite;
    private float playerWidth;
    private float playerHeight;

    private Vector3 minBounds;
    private Vector3 maxBounds;

    private void Awake()
    {
        playerSprite = this.GetComponent<SpriteRenderer>();
        rb = this.GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();

        minBounds = boundBox.bounds.min;
        maxBounds = boundBox.bounds.max;

        playerWidth = playerSprite.bounds.size.x / 2;
        playerHeight = playerSprite.bounds.size.y / 2;
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

            anim.SetBool("Shooting", true);
            anim.SetFloat("ShootX", (mousePos - rb.position).x);
            anim.SetFloat("ShootY", (mousePos - rb.position).y);
        }
        else
        {
            anim.SetBool("Shooting", false);
        }
    }

    private void FixedUpdate()
    {
        movement = movement.normalized;
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        float clampedX = Mathf.Clamp(transform.position.x, minBounds.x + playerWidth, maxBounds.x - playerWidth);
        float clampedY = Mathf.Clamp(transform.position.y, minBounds.y + playerHeight, maxBounds.y - playerHeight);
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Health -= 5;
    }
}