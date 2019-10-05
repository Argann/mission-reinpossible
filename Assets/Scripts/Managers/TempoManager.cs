using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Manager permettant de gérer le tempo du jeu
/// </summary>
public static class TempoManager
{
    /// <summary>
    /// Numéro de battement actuel
    /// </summary>
    public static int beatNumber = 0;

    /// <summary>
    /// Fréquence de battements, en secondes
    /// </summary>
    public static float oneBeatEverySeconds = 1f;

    /// <summary>
    /// Méthode permettant de lancer le système de battements du jeu
    /// </summary>
    public static void StartBeat()
    {
        MainComponent.Instance.StartCoroutine(TempoCoroutine());
    }

    /// <summary>
    /// Méthode permettant de stopper le système de battements du jeu
    /// </summary>
    public static void StopBeat()
    {
        MainComponent.Instance.StopCoroutine(TempoCoroutine());
    }

    /// <summary>
    /// Coroutine de battement
    /// </summary>
    /// <returns></returns>
    private static IEnumerator TempoCoroutine()
    {
        while (true)
        {
            EventManager.OnTempoBeat.Invoke(new GameEventPayload(){
                {"BeatNumber", beatNumber}
            });

            beatNumber++;

            yield return new WaitForSeconds(oneBeatEverySeconds);
        }
    }
    
}
