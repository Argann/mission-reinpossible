using System.Collections;
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
    public List<Vector3> relativePositions;

    /// <summary>
    /// Référence vers la tourelle
    /// </summary>
    public Turret turret;

    /// <summary>
    /// Combien de battements sommes nous après le début du jeu ?
    /// </summary>
    public int beatCounter;

    public AimedTurret(List<Vector3> positions, Turret turret)
    {
        this.relativePositions = positions;
        this.turret = turret;
    }

    /// <summary>
    /// Permet d'activer l'attaque de la tourelle
    /// </summary>
    public override void ProcessAttack()
    {
        beatCounter++;

        if (beatCounter % turret.frequency != 0)
            return;
        
        Debug.Log("HEHEHE");

        foreach (Vector3 position in relativePositions)
        {
            Squad squad = MapManager.GetEntityAtPosition(turret.Position + position) as Squad;

            Debug.Log($"Attack squad {squad}");

            if (squad != null)
            {
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
}