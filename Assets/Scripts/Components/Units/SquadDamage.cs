using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class SquadDamage : MonoBehaviour
{
    private Squad squad;
    private HealthBarPosition hbp;

    private GameObject canvas;

    void Start()
    {
        squad = GetComponent<SquadComponent>().squad;
        hbp = GetComponent<HealthBarPosition>();
        hbp.instance.GetComponent<Text>().text = squad.units.Count + "";
        canvas = GameObject.Find("Canvas");
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
            Invoke(DisplayDamage(gepl.Get<int>("HitAmount")), 1.05f);
            
        }
    }

    string DisplayDamage(int dmg) {
        hbp.instance.GetComponent<Text>().text = squad.units.Count + "";
        if(dmg > 0) {
            GameObject dmgInstance = Instantiate(MainComponent.Instance.DamageUIPrefab, canvas.transform);
            dmgInstance.GetComponent<Text>().text = ""+dmg;
            dmgInstance.transform.position = Camera.main.WorldToScreenPoint(transform.position);
            dmgInstance.transform.DOMove(dmgInstance.transform.position + new Vector3(0, 90, 0), 2f, false);
            Destroy(dmgInstance, 1.5f);
        }
        return null;
    }

    void ProcessDeath(GameEventPayload gepl)
    {
        if (gepl.Get<Squad>("Squad") == squad)
        {
            AudioComponent.PlayUnitDeath(squad.currentUnit);
            Destroy(gameObject, TempoManager.oneBeatEverySeconds / 2f);
            if (hbp != null)
                Destroy(hbp.instance);
        }
    }
}
