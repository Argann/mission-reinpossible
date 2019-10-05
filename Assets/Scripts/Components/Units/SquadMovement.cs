using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquadMovement : MonoBehaviour
{
    private Squad squad;

    void Start()
    {
        squad = GetComponent<SquadComponent>().squad;
    }

    // Méthode appelée lors de l'activation du composant
    void OnEnable()
    {
        EventManager.OnSquadMove.AddListener(ProcessMovement);
    }

    // Méthode appelée lors de la désactivation du composant
    void OnDisable()
    {
        EventManager.OnSquadMove.RemoveListener(ProcessMovement);
    }
    
    void ProcessMovement(GameEventPayload gepl)
    {
        Squad s = gepl.Get<Squad>("Squad");

        if (s == squad)
            transform.position = Utils.ModelPositionToWorldPosition(squad.Position);

    }
}
