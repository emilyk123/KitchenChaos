using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RusherChargeState : EnemyBaseState
{
    private float chargingStopwatch;

    public override void EnterState(EnemyStateManager enemy)
    {
        //Casts the EnemyStateManager script to RusherStateManager, in order to access RusherStateManager specific variables
        RusherStateManager rusher = (RusherStateManager)enemy;

        enemy.anim.SetTrigger("Charge");
        enemy.rb.velocity = enemy.dirToTarget * rusher.chargingSpeed;
    }

    public override void UpdateState(EnemyStateManager enemy)
    {
        RusherStateManager rusher = (RusherStateManager)enemy;

        //Timer to switch back to shooting
        chargingStopwatch += Time.deltaTime;
        if (chargingStopwatch >= rusher.chargingTime)
        {
            chargingStopwatch = 0;
            enemy.rb.velocity = Vector2.zero;
            enemy.SwitchState(rusher.shootState);
        }
    }

    public override void OnTriggerEnter2D(EnemyStateManager enemy)
    {

    }
}
