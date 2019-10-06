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

    public static void Reset()
    {
        map = new GameMap();
    }

    /// <summary>
    /// Méthode permettant de générer les chemins du niveau
    /// </summary>
    public static void GeneratePaths(List<List<Vector3>> paths)
    {
        // On réinitialise la map
        map.ResetPaths();

        // On assigne les chemins donnés en paramètres
        map.paths = paths;

        // On instantie ensuite les chemins
        foreach (List<Vector3> path in map.paths)
        {
            int i = 0;
            foreach (Vector3 position in path)
            {
                if (i == path.Count - 1)
                {
                    GameObject.Instantiate(MainComponent.Instance.pylone, Utils.ModelPositionToWorldPosition(position), Quaternion.identity);
                    GameObject.Instantiate(MainComponent.Instance.Rein, Utils.ModelPositionToWorldPosition(position), Quaternion.Euler(0, -150, 0));
                }
                else
                {
                    GameObject.Instantiate(MainComponent.Instance.tile, Utils.ModelPositionToWorldPosition(position), Quaternion.identity);
                }
                i++;
            }
        }
    }

    /// <summary>
    /// Méthode permettant de générer une liste d'entité
    /// </summary>
    public static void GenerateGameEntities(List<GameEntity> entities)
    {
        map.ResetEntities();

        map.gameEntities = entities;

        foreach (GameEntity entity in map.gameEntities)
        {
            if (entity is Turret turret)
            {
                TurretManager.AddTurret(turret);
            }
        }
    }

    /// <summary>
    /// Méthode permettant de savoir si une case est actuellement
    /// occupée par une entité de jeu ou non
    /// </summary>
    public static bool IsCellEmpty(Vector3 position)
    {
        return map.gameEntities.Any(_ => _.Position == position);
    }

    /// <summary>
    /// Methode permettant de récupérer le GameEntity situé à
    /// la position donnée en paramètre
    /// </summary>
    public static List<GameEntity> GetEntitiesAtPosition(Vector3 position)
    {
        return map.gameEntities.FindAll(_ => _.Position == position);
    }

    public static List<GameEntity> GetEntitiesAtPositions(List<Vector3> positions)
    {
        return map.gameEntities.FindAll(_ => positions.Contains(_.Position));
    }

    public static bool IsEndOfPath(Vector3 position)
    {
        return map.paths.Any(_ => _[_.Count - 1] == position);
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
