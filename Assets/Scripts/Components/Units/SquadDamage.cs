using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SquadDamage : MonoBehaviour
{
    private Squad squad;
    private HealthBarPosition hbp;

    void Start()
    {
        squad = GetComponent<SquadComponent>().squad;
        hbp = GetComponent<HealthBarPosition>();
        hbp.instance.GetComponent<Text>().text = squad.units.Count + "";
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
            hbp.instance.GetComponent<Text>().text = squad.units.Count + "";
        }
    }

    void ProcessDeath(GameEventPayload gepl)
    {
        if (gepl.Get<Squad>("Squad") == squad)
        {
            Destroy(hbp.instance);
            Destroy(gameObject);
        }
    }
}
