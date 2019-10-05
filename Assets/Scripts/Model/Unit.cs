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
    private Vector2 position;

    /// <summary>
    /// Accesseur de la position de l'unité
    /// </summary>
    public Vector2 Position 
    {
        get => position;

        set {
            Vector2 oldPosition = position;
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
    private int damage;

    /// <summary>
    /// Le cout initial d'une unité, a multiplier par le nombre d'unité
    /// </summary>
    public int initialPrice;

    /// <summary>
    /// Le nombre de cases traversées par une unité à chaque battement
    /// </summary>
    public int moveSpeed;
}
