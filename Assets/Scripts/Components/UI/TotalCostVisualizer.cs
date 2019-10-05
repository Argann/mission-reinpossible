using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalCostVisualizer : MonoBehaviour
{
    /// <summary>
    /// Référence vers le texte à actualiser
    /// </summary>
    private Text text;

    void Awake() {
        text = GetComponent<Text>();
        text.text = "Acheter (0)";
    }

    void OnEnable() {
        EventManager.OnAmountChange.AddListener(UpdateText);
    }

    void OnDisable() {
        EventManager.OnAmountChange.RemoveListener(UpdateText);
    }

    void UpdateText(GameEventPayload gepl) {
        text.text = "Acheter(" + gepl.Get<int>("Amount") + ")";
    }
}
