using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Manager permettant de gérer la carte de jeu,
/// et la position générale des entités de jeu
/// </summary>
public static class MapManager
{
    /// <summary>
    /// Référence vers la carte de jeu actuelle
    /// </summary>
    public static GameMap map = new GameMap();

    /// <summary>
    /// Méthode permettant de générer les chemins du niveau
    /// </summary>
    public static void GeneratePaths(List<List<Vector3>> paths)
    {
        // On réinitialise la map
        map.Reset();

        // On assigne les chemins donnés en paramètres
        map.paths = paths;

        // On instantie ensuite les chemins
        foreach (List<Vector3> path in map.paths)
        {
            foreach (Vector3 position in path)
            {
                GameObject.Instantiate(MainComponent.Instance.tile, position, Quaternion.identity, MainComponent.Instance.mapContainer.transform);
            }
        }
    }

    /// <summary>
    /// Méthode permettant de supprimer tous les objets représentant la carte
    /// </summary>
    public static void EmptyMapObjects()
    {
        foreach (Transform child in MainComponent.Instance.mapContainer.transform)
        {
            if (Application.isPlaying)
            {
                GameObject.Destroy(child.gameObject);
            }
            else
            {
                GameObject.DestroyImmediate(child.gameObject);
            }
        }
    }

    /// <summary>
    /// Méthode permettant de savoir si une case est actuellement
    /// occupée par une entité de jeu ou non
    /// </summary>
    public static bool IsCellEmpty(Vector2 position)
    {
        return map.gameEntities.Any(_ => _.position == position);
    }

    /// <summary>
    /// Methode permettant de récupérer le GameEntity situé à
    /// la position donnée en paramètre
    /// </summary>
    public static GameEntity GetEntityAtPosition(Vector2 position)
    {
        return map.gameEntities.Find(_ => _.position == position);
    }

    /// <summary>
    /// Méthode permettant de récupérer la position de la case
    /// située juste après la position donnée en paramètre.
    /// 
    /// Si la position donnée n'est présente dans aucun chemin, 
    /// une exception sera envoyée.
    /// 
    /// Si la position donnée est la dernière position disponible
    /// du chemin, alors elle est renvoyée telle quelle
    /// </summary>
    /// <param name="currentPosition"></param>
    /// <returns></returns>
    public static Vector3 GetNextPositionInPath(Vector3 currentPosition)
    {
        List<Vector3> path = map.paths.Find(_ => _.Contains(currentPosition));

        if (path == null)
            throw new System.Exception("La position donnée n'est présente dans aucun chemin");

        int index = path.IndexOf(currentPosition);

        index++;

        if (index < path.Count)
        {
            return path[index];
        }
        else
        {
            return currentPosition;
        }
    }
    
}
