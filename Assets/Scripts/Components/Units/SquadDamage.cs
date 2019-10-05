using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquadDamage : MonoBehaviour
{
    private Squad squad;

    void Start()
    {
        squad = GetComponent<SquadComponent>().squad;
    }

    void OnEnable()
    {
        EventManager.OnSquadHit.AddListener(ProcessHit);
        EventManager.OnSquadDeath.AddListener(ProcessDeath);
    }

    void OnDisable()
    {
        EventManager.OnSquadHit.RemoveListener(ProcessHit);
        EventManager.OnSquadDeath.RemoveListener(ProcessDeath);
    }

    void ProcessHit(GameEventPayload gepl)
    {
        Debug.Log("Damage!");

        if (gepl.Get<Squad>("Squad") == squad)
        {
            Debug.Log("But Not Me!");

            // TODO
        }
    }

    void ProcessDeath(GameEventPayload gepl)
    {
        Debug.Log("Dead!");
        if (gepl.Get<Squad>("Squad") == squad)
        {
            Debug.Log("But Not Me !");

            Destroy(gameObject);
        }
    }
}
