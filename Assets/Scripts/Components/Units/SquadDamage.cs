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
        if (gepl.Get<Squad>("Squad") == squad)
        {
            // TODO
        }
    }

    void ProcessDeath(GameEventPayload gepl)
    {
        if (gepl.Get<Squad>("Squad") == squad)
        {
            Destroy(gameObject, TempoManager.oneBeatEverySeconds / 2f);
        }
    }
}
