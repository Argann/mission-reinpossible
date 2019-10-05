using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        transform.LookAt(Utils.ModelPositionToWorldPosition(targetPos));
    }
}
