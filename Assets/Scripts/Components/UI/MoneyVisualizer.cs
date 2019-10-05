using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyVisualizer : MonoBehaviour
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
        EventManager.OnPurchaseSquad.AddListener(UpdateText);
    }

    void OnDisable() {
        EventManager.OnPurchaseSquad.RemoveListener(UpdateText);
    }

    void UpdateText(GameEventPayload gepl) {
        text.text = "" + gepl.Get<int>("Amount");
    }
}
