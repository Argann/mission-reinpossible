using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// La classe SeekerTurret désigne les tourelles qui ciblent une unité plutôt qu'une case
/// </summary>
public class SeekerTurret : TurretBehaviour
{
    /// <summary>
    /// La victime de cette tourelle
    /// </summary>
    public Squad squad;

    private Turret turret;

    public SeekerTurret(Turret turret)
    {
        this.turret = turret;
    }

    public override void ProcessAttack()
    {
        if (TempoManager.beatNumber % turret.frequency != 0)
            return;

        Squad squad = SquadManager.GetFurthestSquad();

        if (squad != null)
        {
            EventManager.OnTurretAttack.Invoke(new GameEventPayload()
            {
                {"Turret", turret},
                {"Squad", squad}
            });
            if (turret.multipleAttack)
            {
                SquadManager.DamageSplashSquad(squad, turret.damage);
            }
            else
            {
                SquadManager.DamageSquad(squad, turret.damage);
            }
        }
    }
}