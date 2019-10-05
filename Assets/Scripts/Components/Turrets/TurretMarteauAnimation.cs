using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretMarteauAnimation : MonoBehaviour
{
    public Turret turret;

    public GameObject bras;

    void OnEnable()
    {
        EventManager.OnTempoBeat.AddListener(ProcessBeat);
    }

    void OnDisable()
    {
        EventManager.OnTempoBeat.RemoveListener(ProcessBeat);
    }

    void ProcessBeat(GameEventPayload gepl)
    {
        if (TempoManager.beatNumber % turret.frequency == 0)
        {
            bras.transform.localRotation = Quaternion.Euler(90, 0, 0);
        }
        else
        {
            bras.transform.localRotation = Quaternion.identity;
        }
    }
}
