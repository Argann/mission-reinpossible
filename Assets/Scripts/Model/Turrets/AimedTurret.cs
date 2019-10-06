﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// La classe AimedTurret désigne les tourelles qui ciblent 1..n cases définies
/// </summary>
public class AimedTurret : TurretBehaviour
{
    /// <summary>
    /// La liste des cases ciblées par la tourelle
    /// </summary>
    public List<Vector3> positions;

    /// <summary>
    /// Référence vers la tourelle
    /// </summary>
    public Turret turret;

    public AimedTurret(List<Vector3> positions, Turret turret)
    {
        this.positions = positions;
        this.turret = turret;
    }

    /// <summary>
    /// Permet d'activer l'attaque de la tourelle
    /// </summary>
    public override void ProcessAttack()
    {
        if (TempoManager.beatNumber % turret.frequency != 0)
            return;

        foreach (Vector3 position in positions)
        {
            List<Squad> squad = SquadManager.GetSquadsAtPosition(position);

            if (squad != null && squad.Count > 0)
            {
                EventManager.OnTurretAttack.Invoke(new GameEventPayload()
                {
                    {"Turret", turret},
                    {"Squad", squad}
                });
                if (turret.multipleAttack)
                {
                    foreach (Squad sq in squad)
                    {
                        SquadManager.DamageSplashSquad(sq, turret.damage);
                    }
                }
                else
                {
                    foreach (Squad sq in squad)
                    {
                        SquadManager.DamageSquad(sq, turret.damage);
                    }
                }
            }
        }
    }
}