using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// La classe Unit est la classe mère utilisée par les entités attaquantes
/// </summary>
public class Unit
{
    /// <summary>
    /// Nombre de points de vie des unités
    /// </summary>
    private int hp;

    /// <summary>
    /// Propriété permettant d'accéder aux points de vie de l'unité
    /// </summary>
    /// <value></value>
    public int HP {
        get => hp;

        set {
            int oldHP = hp;
            hp = value;

            if (oldHP < hp)
            {
                EventManager.OnUnitHeal.Invoke(new GameEventPayload()
                {
                    {"Unit", this},
                    {"HealAmount", hp - oldHP}
                });
            }
            else if (oldHP > hp)
            {
                EventManager.OnUnitHit.Invoke(new GameEventPayload()
                {
                    {"Unit", this},
                    {"HitAmount", oldHP - hp}
                });
            }
        }
    }

    /// <summary>
    /// La position des unités en x et y
    /// </summary>
    private Vector3 position;

    /// <summary>
    /// Accesseur de la position de l'unité
    /// </summary>
    public Vector3 Position 
    {
        get => position;

        set {
            Vector3 oldPosition = position;
            position = value;
            if (position != oldPosition)
            {
                EventManager.OnUnitMove.Invoke(new GameEventPayload()
                {
                    {"Unit", this},
                    {"NewPosition", position},
                    {"OldPosition", oldPosition}
                }
                );
            }
        }
    }

    /// <summary>
    /// Les dommages qu'infligent l'unité
    /// </summary>
    public int damage;

    /// <summary>
    /// Le cout initial d'une unité, a multiplier par le nombre d'unité
    /// </summary>
    public int initialPrice;

    /// <summary>
    /// Le nombre de cases traversées par une unité à chaque battement
    /// </summary>
    public int moveSpeed;

    /// <summary>
    /// Le palier à partir duquel le prix de l'unité augmente
    /// </summary>
    public int stepPrice;

    /// <summary>
    /// Le facteur d'évolution du prix lorsqu'une même unité est achetée plusieurs fois
    /// </summary>
    public float priceFactor;

    /// <summary>
    /// Le nom de l'unité
    /// </summary>
    public string maname;

    /// <summary>
    /// L'icone utilisée dans l'UI
    /// </summary>
    public Sprite icon;

    public GameObject prefab;

    public Unit(Unit unit) {
        this.HP = unit.HP;
        this.Position = unit.Position;
        this.damage = unit.damage;
        this.initialPrice = unit.initialPrice;
        this.moveSpeed = unit.moveSpeed;
        this.stepPrice = unit.stepPrice;
        this.priceFactor = unit.priceFactor;
        this.maname = unit.maname;
        this.icon = unit.icon;
        this.prefab = unit.prefab;
    }

    public Unit(UnitAsset unitAsset, Vector3 position)
    {
        this.HP = unitAsset.maxHP;
        this.Position = position;
        this.damage = unitAsset.damage;
        this.initialPrice = unitAsset.initialPrice;
        this.moveSpeed = unitAsset.moveSpeed;
        this.stepPrice = unitAsset.stepPrice;
        this.priceFactor = unitAsset.priceFactor;
        this.maname = unitAsset.maname;
        this.icon = unitAsset.icon;
        this.prefab = unitAsset.prefab;
    }
}
