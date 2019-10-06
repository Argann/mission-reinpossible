using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelNumberVisualizer : MonoBehaviour
{
    /// <summary>
    /// Référence vers le texte à actualiser
    /// </summary>
    private Text text;

    void Awake() {
        text = GetComponent<Text>();
        text.text = "" + ShopManager.Money;
    }

    void OnEnable() {
        EventManager.OnNextLevel.AddListener(UpdateText);
    }

    void OnDisable() {
        EventManager.OnNextLevel.RemoveListener(UpdateText);
    }

    void UpdateText(GameEventPayload gepl) {
        text.text = "" + MainComponent.Instance.startLevel;
    }
}
