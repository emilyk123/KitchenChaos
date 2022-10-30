using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateManager : MonoBehaviour
{
    /*
    The base for other enemy state machines. Create a new script inherit this one to start a new enemy type. Use the RusherStateManager as an example.
    As well, create new enemy state scripts that inherits EnemyBaseState. See RusherShootState as an example.
    */
    public EnemyBaseState currentState;

    public GameObject bullet;
    public Transform target;

    public int enemyHealth = 4;
    public int enemyEXP = 10;
    public float fireRate = 1.0f;
    public float shootingPower = 1.0f;

    [HideInInspector] public Rigidbody2D rb;
    [HideInInspector] public Animator anim;

    [HideInInspector] public Vector2 dirToTarget;
    private int totalDamage = 0;

    protected virtual void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();
        currentState.EnterState(this);
    }

    protected virtual void Update()
    {
        //Will call the code from the UpdateState of the current state every frame
        currentState.UpdateState(this);

        //Always gets vector to target so it won't be called in each state
        dirToTarget = ((Vector2)target.position - (Vector2)rb.position).normalized;
    }

    public void SwitchState(EnemyBaseState state)
    {
        currentState = state;
        //goes to the EnterState function of the new state
        state.EnterState(this);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Bullet")
        {
            totalDamage += collider.GetComponent<Bullet>().damage;
            if (totalDamage == enemyHealth)
            {
                LevelSystem.instance.AddXP(enemyEXP);
                Destroy(gameObject);
            }
        }
    }

    //Use this function to create bullets since Instantiate needs the script to inherit Monobehaviour
    public void FireBullet(Vector2 dir)
    {
        GameObject projectile = Instantiate(bullet, (Vector2)rb.position + dirToTarget, Quaternion.identity);
        projectile.GetComponent<Bullet>().dir = dir * shootingPower;
        projectile.layer = gameObject.layer;
    }
}
