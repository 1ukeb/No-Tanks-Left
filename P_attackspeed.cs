using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_attackspeed : Powerup
{
    public float attackSpeedMultiplier;
    public override void StartPowerup()
    {
        base.StartPowerup();
        c.shootCooldown /= attackSpeedMultiplier;
    }

    public override void StopPowerup()
    {
        c.shootCooldown *= attackSpeedMultiplier;
        base.StopPowerup();
    }
}
