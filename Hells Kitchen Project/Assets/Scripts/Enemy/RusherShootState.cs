using UnityEngine;

public class RusherShootState : EnemyBaseState
{
    private float shootStopwatch;
    private float chargeStopwatch;

    public override void EnterState(EnemyStateManager enemy)
    {
        
    }

    public override void UpdateState(EnemyStateManager enemy)
    {
        //Casts the EnemyStateManager script to RusherStateManager, in order to access RusherStateManager specific variables
        RusherStateManager rusher = (RusherStateManager)enemy;

        //Checks if there is an animator, then sets the animators variables
        if (enemy.anim != null)
        {
            enemy.anim.SetFloat("X", enemy.dirToTarget.x);
            enemy.anim.SetFloat("Y", enemy.dirToTarget.y);
        }

        //Timer for shooting, resets when it reaches fireRate
        shootStopwatch += Time.deltaTime;
        if (shootStopwatch >= enemy.fireRate)
        {
            shootStopwatch = 0;
            enemy.anim.SetTrigger("Shoot");
            
            //Creates 5 new vectors set at different angles then Fired
            for (int i = 0; i < 5; i++)
            {
                Vector2 dir = Quaternion.Euler(0, 0, 15 * (i - 2)) * enemy.dirToTarget;
                enemy.FireBullet(dir);
            }
        }

        //Timer to switch to chargeState, resets for when the charge switches back to here
        chargeStopwatch += Time.deltaTime;
        if (chargeStopwatch >= rusher.timeToCharge)
        {
            chargeStopwatch = 0;
            rusher.SwitchState(rusher.chargeState);
        }
    }

    public override void OnTriggerEnter2D(EnemyStateManager enemy)
    {

    }
}
