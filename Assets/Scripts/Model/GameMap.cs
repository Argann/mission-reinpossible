using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// La classe GameMap représente la grille de jeu
/// </summary>
public class GameMap
{
    /// <summary>
    /// La matrice représentant le terrain
    /// </summary>
    public List<GameEntity> gameEntities = new List<GameEntity>();

    /// <summary>
    /// Liste de tous les chemins possibles pour le niveau
    /// </summary>
    public List<List<Vector3>> paths = new List<List<Vector3>>();

    /// <summary>
    /// Méthode permettant de reset la carte actuelle.
    /// </summary>
    public void Reset()
    {
        gameEntities = new List<GameEntity>();
        paths = new List<List<Vector3>>();
    }
}
