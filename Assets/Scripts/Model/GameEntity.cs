using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe représentant une entité de jeu
/// </summary>
public class GameEntity
{
    /// <summary>
    /// Position actuelle de l'entité
    /// </summary>
    protected Vector3 position;

    public virtual Vector3 Position
    {
        get => position;
        set => position = value;
    }

    /// <summary>
    /// Position actuelle de l'entité
    /// </summary>
    public Vector3 rotation;
}