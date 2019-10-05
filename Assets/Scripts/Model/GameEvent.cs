using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Classe représentant la charge utile
/// d'un évènement.
/// </summary>
public class GameEventPayload : Dictionary<string, System.Object>
{
    /// <summary>
    /// Méthode permettant de récupérer une
    /// valeur du payload sous forme d'un objet
    /// donné en paramètre
    /// </summary>
    public T Get<T>(string key) {
        return (T) this[key];
    }
}

/// <summary>
/// Classe permettant d'utiliser les Unity Events
/// avec un paramètre.
/// </summary>
/// <typeparam name="GameEventPayload"></typeparam>
[System.Serializable]
public class GameEvent : UnityEvent<GameEventPayload> {}
