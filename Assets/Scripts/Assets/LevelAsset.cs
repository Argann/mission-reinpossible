using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe d'Asset représentant un niveau de jeu
/// </summary>
[CreateAssetMenu(menuName = "Game Design/Level Asset", fileName = "New Level Asset")]
public class LevelAsset : ScriptableObject
{
    /// <summary>
    /// Structure associant un asset d'entité à une position de base
    /// </summary>
    [System.Serializable]
    public struct EntityStartPosition
    {
        public GameEntityAsset entityAsset;

        public Vector3 startPosition;
    }

    /// <summary>
    /// La liste des entités du niveau
    /// </summary>
    public List<EntityStartPosition> gameEntities = new List<EntityStartPosition>();

    /// <summary>
    /// Liste de tous les chemins possibles pour le niveau
    /// </summary>
    public List<Path> paths = new List<Path>();
}