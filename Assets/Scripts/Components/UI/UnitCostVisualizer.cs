using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitCostVisualizer : MonoBehaviour
{
    /// <summary>
    /// Référence vers le texte à actualiser
    /// </summary>
    private Text text;

    public UnitAsset unit;

    void Awake() {
        text = GetComponent<Text>();
        text.text = "" + unit.initialPrice;
    }

    void OnEnable() {
        EventManager.OnUnitChange.AddListener(UpdateText);
    }

    void OnDisable() {
        EventManager.OnUnitChange.RemoveListener(UpdateText);
    }

    void UpdateText(GameEventPayload gepl) {
        if(gepl.Get<string>("Item") == unit.maname)
            text.text = "" + gepl.Get<int>("Amount");
    }
}
