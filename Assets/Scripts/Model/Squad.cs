using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// La classe Squad est la classe encapsulant de multiples unités
/// </summary>
public class Squad : GameEntity
{
    /// <summary>
    /// La liste des unités comprises dans l'escouade
    /// </summary>
    public List<Unit> units = new List<Unit>();

    /// <summary>
    /// La valeur (prix) de l'escouade, nécessaire pour le remboursement en cas de vente
    /// </summary>
    public int value;

    public Unit currentUnit;

    public override Vector3 Position
    {
        get => position;

        set {
            Vector3 oldPosition = position;
            position = value;
            if (oldPosition != position)
            {
                EventManager.OnSquadMove.Invoke(new GameEventPayload(){
                    {"Squad", this},
                    {"NewPosition", position},
                    {"OldPosition", oldPosition}
                });
            }
        }
    }
}
