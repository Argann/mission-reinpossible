using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
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

    public GameObject pylone;

    /// <summary>
    /// Prefab représentant une squad
    /// </summary>
    public GameObject Squad;

    public GameObject TurretMarteau;

    public GameObject TurretGunringue;

    public GameObject TurretSuppobusier;

    public GameObject VictoryUI;

    public GameObject DamageUIPrefab;

    public GameObject Rein;

    [Header("Variables")]
    public float modelToWorldScaleFactor;

    public int startLevel;

    [Header("Objects to keep")]
    public List<GameObject> objectsToKeepBetweenLevels;

    public bool isFirstBeat = true;

    /// <summary>
    /// Méthode appelée automatiquement par Unity au lancement
    /// du composant
    /// </summary>
    void Awake()
    {
        // Et on lance le tempo !
        TempoManager.StartBeat();
        VictoryUI.transform.DOScale(0f,0f);

        startLevel--;
        NextGame();

        EventManager.OnSquadDeath.AddListener(CheckGameOver);
        EventManager.OnOrganDeath.AddListener(_ => {
            NextGame(_);
            VictoryUI.transform.DOScale(1f,1f);
            StartCoroutine(DisappearAfterDelay());
        });

        EventManager.OnTempoBeat.AddListener(_ => {

            if (isFirstBeat)
            {
                isFirstBeat = false;
                AudioComponent.Instance.source.Play();
            }

            SquadManager.MoveSquads();
            TurretManager.AttackTurrets();

        });

        ShopManager.InitializeShopManager();
    }

    IEnumerator DisappearAfterDelay() {
        yield return new WaitForSeconds(2f);
        VictoryUI.transform.DOScale(0f,1.5f);
        VictoryUI.transform.DORotate(new Vector3(0,0,0), 1.5f, RotateMode.FastBeyond360);
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
        EventManager.OnLevelLoaded.Invoke(new GameEventPayload());
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
}