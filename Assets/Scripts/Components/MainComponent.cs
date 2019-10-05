using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe représentant le composant principal controlant le jeu.
/// </summary>
public class MainComponent : MonoBehaviour
{
    /// <summary>
    /// Instance statique du Main Component
    /// </summary>
    private static MainComponent instance;

    public static MainComponent Instance
    {
        get {
            if (instance == null)
            {
                instance = GameObject.Find("Main Component").GetComponent<MainComponent>();
            }
            return instance;
        }
    }

    [Header("Containers")]
    public GameObject mapContainer;

    /// <summary>
    /// Préfab représentant une tuile de jeu
    /// </summary>
    [Header("Prefabs")]
    [Tooltip("Quel est le préfab représentant une tuile de jeu ?")]
    public GameObject tile;

    /// <summary>
    /// Prefab représentant une squad
    /// </summary>
    public GameObject Squad;

    public GameObject TurretMarteau;

    public GameObject TurretGunringue;

    public GameObject TurretSuppobusier;

    [Header("Variables")]
    public float modelToWorldScaleFactor;

    public int level;

    /// <summary>
    /// Méthode appelée automatiquement par Unity au lancement
    /// du composant
    /// </summary>
    void Awake()
    {
        MapManager.EmptyMapObjects();
        LevelManager.LoadLevel(level);

        EventManager.OnTempoBeat.AddListener(_ => {

            SquadManager.MoveSquads();
            TurretManager.AttackTurrets();

        });
    }

    void OnEnable()
    {
        TempoManager.StartBeat();
    }

    void OnDisable()
    {
        TempoManager.StopBeat();
    }
}