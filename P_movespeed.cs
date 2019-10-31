using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_movespeed : Powerup
{
    public float moveSpeedMultiplier = 2f;
    public float turnSpeedMultiplier;
    public override void StartPowerup()
    {
        base.StartPowerup();
        c.moveSpeed *= moveSpeedMultiplier;
        c.turnSpeed *= turnSpeedMultiplier;
    }

    public override void StopPowerup()
    {
        c.moveSpeed /= moveSpeedMultiplier;
        c.turnSpeed /= turnSpeedMultiplier;
        base.StopPowerup();
    }
}
