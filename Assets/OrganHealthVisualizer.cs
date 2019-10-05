using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OrganHealthVisualizer : MonoBehaviour
{
    private TextMeshProUGUI text;
    
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        text.text = $"Organ life : {OrganManager.HP}";
    }

    // Méthode appelée lors de l'activation du composant
    void OnEnable()
    {
        EventManager.OnOrganHit.AddListener(ProcessOrganHit);
    }

    // Méthode appelée lors de la désactivation du composant
    void OnDisable()
    {
        EventManager.OnOrganHit.RemoveListener(ProcessOrganHit);
    }

    void ProcessOrganHit(GameEventPayload _)
    {
        text.text = $"Organ life : {OrganManager.HP}";
    }
}
