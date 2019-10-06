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

    public int startLevel;

    [Header("Objects to keep")]
    public List<GameObject> objectsToKeepBetweenLevels;

    /// <summary>
    /// Méthode appelée automatiquement par Unity au lancement
    /// du composant
    /// </summary>
    void Awake()
    {
        startLevel--;
        NextGame();

        EventManager.OnSquadDeath.AddListener(CheckGameOver);
        EventManager.OnOrganDeath.AddListener(NextGame);

        EventManager.OnTempoBeat.AddListener(_ => {

            SquadManager.MoveSquads();
            TurretManager.AttackTurrets();

        });

        ShopManager.InitializeShopManager();
    }


    void NextGame(GameEventPayload gepl = null)
    {
        // On passe au numéro de niveau suivant
        startLevel++;

        // On réinitialise le modèle
        MapManager.Reset();
        OrganManager.Reset();
        ShopManager.Reset();
        SquadManager.Reset();
        TempoManager.Reset();
        TurretManager.Reset();

        // On vide la scène
        MainComponent.Instance.ClearScene();

        // Puis on charge le bon niveau
        LevelManager.LoadLevel(startLevel);

        // Et on lance l'évènement de nouvelle vague
        EventManager.OnNextLevel.Invoke(new GameEventPayload());
    }

    public void ResetGame()
    {
        startLevel = 0;
        startLevel--;
        NextGame();
    }

    public void ResetLevel()
    {
        startLevel--;
        NextGame();
    }

    public void ClearScene()
    {
        GameObject[] rootObjects = UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects();

        foreach (GameObject obj in rootObjects)
        {
            if (!objectsToKeepBetweenLevels.Contains(obj))
                Destroy(obj);
        }
    }

    void CheckGameOver(GameEventPayload gepl)
    {
        if (SquadManager.inGameSquads.Count == 0 && SquadManager.inInventorySquads.Count == 0)
        {
            EventManager.OnGameOver.Invoke(new GameEventPayload());
        }
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