using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquadDamage : MonoBehaviour
{
    private Squad squad;
    private HealthBarPosition hbp;
    private int maxHealth;

    void Start()
    {
        squad = GetComponent<SquadComponent>().squad;
        hbp = GetComponent<HealthBarPosition>();
        maxHealth = SquadManager.GetSquadHealth(squad);
        hbp.back.rectTransform.sizeDelta = new Vector2(10 + maxHealth*.8f, 3);
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
            hbp.fill.fillAmount = (float)(SquadManager.GetSquadHealth(squad)) / (float)(maxHealth);
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
