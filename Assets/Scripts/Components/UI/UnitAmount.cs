using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitAmount : MonoBehaviour
{
    /// <summary>
    /// Référence vers le texte à actualiser
    /// </summary>
    private Text text;

    /// <summary>
    /// Le nom de l'item associé à ce champ
    /// </summary>
    public string maname;

    void Awake() {
        text = GetComponent<Text>();
    }

    void OnEnable() {
        EventManager.OnPurchaseUnit.AddListener(UpdateText);
    }

    void OnDisable() {
        EventManager.OnPurchaseUnit.RemoveListener(UpdateText);
    }

    void UpdateText(GameEventPayload gepl) {
        if(gepl.Get<string>("Item") == maname)
            text.text = "" + gepl.Get<int>("Amount");
    }
}
