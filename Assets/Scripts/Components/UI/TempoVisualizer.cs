using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TempoVisualizer : MonoBehaviour
{
    /// <summary>
    /// Référence vers l'image représentant le tempo
    /// </summary>
    private Image image;

    void Awake()
    {
        image = GetComponent<Image>();
    }

    // Méthode appelée lors de l'activation du composant
    void OnEnable()
    {
        EventManager.OnTempoBeat.AddListener(ProcessTempoEvent);
    }

    // Méthode appelée lors de la désactivation du composant
    void OnDisable()
    {
        EventManager.OnTempoBeat.RemoveListener(ProcessTempoEvent);
    }

    void ProcessTempoEvent(GameEventPayload _)
    {
        if (_.Get<int>("BeatNumber") % 2 == 0)
        {
            image.color = Color.white;
        }
        else
        {
            image.color = Color.black;
        }
    }
}
