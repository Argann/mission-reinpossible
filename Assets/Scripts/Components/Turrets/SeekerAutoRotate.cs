using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SeekerAutoRotate : MonoBehaviour
{
    public Turret turret;

    public GameObject rotationObject;

    void Start()
    {
        turret = GetComponent<TurretComponent>().turret;
    }

    void OnEnable()
    {
        EventManager.OnTurretAttack.AddListener(ProcessAttack);
    }

    void OnDisable()
    {
        EventManager.OnTurretAttack.RemoveListener(ProcessAttack);
    }

    void ProcessAttack(GameEventPayload gepl)
    {
        if (gepl.Get<Turret>("Turret") != turret)
            return;

        Vector3 targetPos = gepl.Get<Squad>("Squad").Position;

        transform.DOLookAt(Utils.ModelPositionToWorldPosition(targetPos), TempoManager.oneBeatEverySeconds / 1.6f).SetEase(Ease.InOutBack);
    }
}
