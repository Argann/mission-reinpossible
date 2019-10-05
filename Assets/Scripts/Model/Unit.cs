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
    public int hp;

    /// <summary>
    /// La position des unités en x et y
    /// </summary>
    public Vector2 position;

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
}
