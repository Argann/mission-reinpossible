using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyEnabler : MonoBehaviour
{
    /// <summary>
    /// Référence vers le texte à actualiser
    /// </summary>
    private Button button;

    void Awake() {
        button = GetComponent<Button>();
        button.interactable = false;
    }

    void OnEnable() {
        EventManager.OnAmountChange.AddListener(UpdateEnable);
    }

    void OnDisable() {
        EventManager.OnAmountChange.RemoveListener(UpdateEnable);
    }

    void UpdateEnable(GameEventPayload gepl) {
        if (gepl.Get<int>("Amount") > 0) {
            button.interactable = true;
        } else {
            button.interactable = false;
        }
    }
}
