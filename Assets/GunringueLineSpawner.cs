using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class GunringueLineSpawner : MonoBehaviour
{
    public GameObject lineObject;

    public GameObject particles;

    public GameObject spawner;

    public Turret turret;

    public float noise;

    public void Start()
    {
        turret = gameObject.GetComponent<TurretComponent>().turret;
    }

    void OnEnable()
    {
        EventManager.OnTurretAttack.AddListener(ProcessAttack);
    }

    void OnDisable()
    {
        EventManager.OnTurretAttack.RemoveListener(ProcessAttack);
    }

    public void ProcessAttack(GameEventPayload gepl)
    {
        if (gepl.Get<Turret>("Turret") != turret)
            return;

        DOTween.Sequence().InsertCallback(TempoManager.oneBeatEverySeconds / 2, () => AttackAnimation(gepl));
    }

    public void AttackAnimation(GameEventPayload gepl)
    {
        GameObject go = Instantiate(lineObject, Vector3.zero, Quaternion.identity);

        LineRenderer lineRenderer = go.GetComponent<LineRenderer>();

        Vector3 endPosition = Utils.ModelPositionToWorldPosition(gepl.Get<Squad>("Squad").Position);
        Vector3 startPosition = spawner.transform.position;

        Instantiate(particles, endPosition, Quaternion.Euler(Vector3.right * -90));

        float distance = Vector3.Distance(startPosition, endPosition);
        Vector3 direction = (endPosition - startPosition).normalized;
        float segmentLength = distance / lineRenderer.positionCount;

        Sequence seq = DOTween.Sequence();

        Vector3 currentTarget = startPosition;

        for (int i = 0; i < lineRenderer.positionCount; i++)
        {
            currentTarget = startPosition + (direction * (i * segmentLength));
            currentTarget += Random.insideUnitSphere * noise;
            lineRenderer.SetPosition(i, currentTarget);
        }
    }
}
