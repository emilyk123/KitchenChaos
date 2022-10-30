using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RusherStateManager : EnemyStateManager
{
    /*
    The state manager for the rusher type enemies. 
    New states shoot and charge are created and set here, as well as variables specific to this enemy.
    */

    public EnemyBaseState shootState = new RusherShootState();
    public EnemyBaseState chargeState = new RusherChargeState();

    public float timeToCharge = 5f;

    public float chargingTime = 1f;
    public float chargingSpeed = 5f;

    //Overrides the Start() function in EnemyStateManager
    protected override void Start()
    {
        //Sets the starting state to shoot
        currentState = shootState;
        //Calls Start() in EnemyStateManager
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }
}
