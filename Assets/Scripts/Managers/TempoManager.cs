using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Manager permettant de gérer le tempo du jeu
/// </summary>
public class TempoManager : MonoBehaviour
{
    /// <summary>
    /// Instance statique du manager de tempo
    /// </summary>
    public static TempoManager instance;

    /// <summary>
    /// Evenement appelé à chaque battement de jeu
    /// </summary>
    [HideInInspector]
    public UnityEvent tempoEvent;

    /// <summary>
    /// Fréquence de battements, en secondes
    /// </summary>
    public float oneBeatEverySeconds;

    /// <summary>
    /// Coroutine gérant les battements
    /// </summary>
    private Coroutine tempoCoroutine;

    /// <summary>
    /// Méthode lancée automatiquement par Unity
    /// lors du chargement du script
    /// </summary>
    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    /// <summary>
    /// Méthode permettant de lancer le système de battements du jeu
    /// </summary>
    public void StartBeat()
    {
        tempoCoroutine = StartCoroutine(TempoCoroutine());
    }

    /// <summary>
    /// Méthode permettant de stopper le système de battements du jeu
    /// </summary>
    public void StopBeat()
    {
        if (tempoCoroutine == null)
            return;

        StopCoroutine(tempoCoroutine);
    }

    /// <summary>
    /// Coroutine de battement
    /// </summary>
    /// <returns></returns>
    private IEnumerator TempoCoroutine()
    {
        tempoEvent.Invoke();

        yield return new WaitForSeconds(oneBeatEverySeconds);
    }
    
}
