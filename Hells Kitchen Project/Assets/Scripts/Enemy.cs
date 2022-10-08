using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject bullet;
    public LevelSystem level;
    private Rigidbody2D rb;
    private int enemyEXP = 5;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D bullet) {
        Object.Destroy(this.gameObject);
        level.experience += enemyEXP;
        Debug.Log(enemyEXP);
    }
}
