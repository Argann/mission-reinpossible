using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Manager permettant le chargement et la récupération
/// des niveaux designés dans le dossier Resources
/// </summary>
public static class LevelManager
{
    /// <summary>
    /// Liste des niveaux récupérés dans les dossiers
    /// </summary>
    public static List<LevelAsset> levels;

    /// <summary>
    /// Constructeur de classe statique
    /// </summary>
    static LevelManager()
    {
        RefreshLevelList();
    }

    /// <summary>
    /// Méthode permettant de charger le niveau donné en paramètre
    /// </summary>
    public static void LoadLevel(int levelIndex)
    {
        if (levelIndex < 0 || levelIndex >= levels.Count)
            return;

        // On récupère le fichier correspondant au niveau choisi
        LevelAsset level = levels[levelIndex];

        // On transforme les chemins possibles afin d'avoir quelque chose
        // de compréhensible par le MapManager
        List<List<Vector3>> paths = level.paths.Select(_ => _.path).ToList();

        // On envoi les chemins possibles au manager de cartes
        MapManager.GeneratePaths(paths);
    }

    /// <summary>
    /// Méthode permettant de recharger la liste des niveaux
    /// </summary>
    public static void RefreshLevelList()
    {
        levels = new List<LevelAsset>();

        Object[] rawlevels = Resources.LoadAll("Levels");

        if (rawlevels.Count() > 0)
        {
            for (int i = 0; i < rawlevels.Count(); i++)
            {
                LevelAsset level = rawlevels[i] as LevelAsset;

                if (level != null)
                    levels.Add(level);
            }
        }
    }
}