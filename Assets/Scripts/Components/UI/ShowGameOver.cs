using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowGameOver : MonoBehaviour
{
    public List<GameObject> objectsToShow;

    // Méthode appelée lors de l'activation du composant
    void OnEnable()
    {
        EventManager.OnGameOver.AddListener(ProcessGameOver);
        EventManager.OnNextLevel.AddListener(ProcessNextLevel);
    }

    // Méthode appelée lors de la désactivation du composant
    void OnDisable()
    {
        EventManager.OnGameOver.RemoveListener(ProcessGameOver);
        EventManager.OnNextLevel.RemoveListener(ProcessNextLevel);
    }

    void ProcessGameOver(GameEventPayload _)
    {
        foreach (GameObject obj in objectsToShow)
        {
            obj.SetActive(true);
        }
    }

    void ProcessNextLevel(GameEventPayload _)
    {
        foreach (GameObject obj in objectsToShow)
        {
            obj.SetActive(false);
        }
    }
}
