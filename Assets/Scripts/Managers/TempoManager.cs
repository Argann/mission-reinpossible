using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
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
    public static float oneBeatEverySeconds = .9756f;

    public static Sequence tempoSequence;

    public static void Reset()
    {
        beatNumber = 0;
    }

    /// <summary>
    /// Méthode permettant de lancer le système de battements du jeu
    /// </summary>
    public static void StartBeat()
    {
        tempoSequence = DOTween.Sequence()
            .AppendInterval(oneBeatEverySeconds)
            .AppendCallback(
                () => {
                    EventManager.OnTempoBeat.Invoke(new GameEventPayload(){
                        {"BeatNumber", beatNumber}
                    });

                    beatNumber++;
                }
            )
            .SetLoops(-1)
            .Play();
    }
    
}
