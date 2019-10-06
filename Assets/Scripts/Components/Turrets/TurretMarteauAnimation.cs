using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class TurretMarteauAnimation : MonoBehaviour
{
    public Turret turret;

    public GameObject bras;

    public GameObject particules;

    public GameObject particuleSpawner;

    void Start()
    {
        turret = GetComponent<TurretComponent>().turret;
    }

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
        if (turret == null)
            return;

        if (TempoManager.beatNumber % turret.frequency == 0)
        {
            AudioComponent.PlayFX("Marteau - Stomp");

            DOTween.Sequence()
                .Append(
                    bras.transform.DOLocalRotate(new Vector3(90, 0, 0), TempoManager.oneBeatEverySeconds / 2f).SetEase(Ease.InOutBack)
                )
                .InsertCallback((TempoManager.oneBeatEverySeconds / 2) - .2f, () => {
                    GameObject.Instantiate(particules, particuleSpawner.transform.position, Quaternion.Euler(90, 0,0));
                });
            
        }
        else
        {
            AudioComponent.PlayFX("Marteau - Charge");

            bras.transform.DOLocalRotate(new Vector3(0, 0, 0), TempoManager.oneBeatEverySeconds / 2).SetEase(Ease.OutBack);
        }
    }
}
