using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// La classe Turret est la classe mère utilisée par les entités de types "tourelles"
/// </summary>
public class Turret : GameEntity
{
    public enum TurretType
    {
        Gunringue,
        Attendrisseur,
        Suppobusier
    }

    public TurretType turretType;

    /// <summary>
    /// Le nombre de points de vie de la tourelle. -- Nécessaire pour les tourelles de type "barrière"
    /// </summary>
    public int hp;
    
    /// <summary>
    /// Les dégâts infligés par la tourelle aux unités du joueur
    /// </summary>
    public int damage;

    /// <summary>
    /// Définit les zones attaquées par les tourelles
    /// </summary>
    public TurretBehaviour behaviour;

    /// <summary>
    /// Définit si la tourelle attaque toutes les unités (true), ou les unités une à une (false)
    /// </summary>
    public bool multipleAttack;

    /// <summary>
    /// La frequence d'attaque de la tourelle. 0 : tous les tours, 1 : un tour de délai, etc
    /// </summary>
    public int frequency;

    public Turret(TurretAsset asset, Vector3 position, List<Vector3> aimPositions = null)
    {
        this.turretType = asset.turretType;
        this.hp = asset.hp;
        this.damage = asset.damage;
        this.multipleAttack = asset.multipleAttack;
        this.frequency = asset.frequency;
        this.position = position;

        switch (asset.behaviour)
        {
            case TurretAsset.Behaviour.Aimed:
                this.behaviour = new AimedTurret(aimPositions, this);
                break;
            case TurretAsset.Behaviour.Seeker:
                this.behaviour = new SeekerTurret(this);
                break;
            default:
                break;
        }
    }

    public void ProcessAttack()
    {
        this.behaviour.ProcessAttack();
    }

}
