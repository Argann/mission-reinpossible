using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class SuppobusierShooter : MonoBehaviour
{
    public Turret turret;

    public GameObject obus;

    public GameObject spawner;

    public GameObject particlesTir;
    public GameObject particlesSol;

    void Start()
    {
        turret = GetComponent<TurretComponent>().turret;
    }

    void OnEnable()
    {
        EventManager.OnTempoBeat.AddListener(ProcessAttack);
    }

    void OnDisable()
    {
        EventManager.OnTempoBeat.RemoveListener(ProcessAttack);
    }

    void ProcessAttack(GameEventPayload gepl)
    {
        if (turret == null || TempoManager.beatNumber % turret.frequency != 0)
            return;

        AudioComponent.PlayFX("Suppobusier");

        foreach (Vector3 aimedPosition in ((AimedTurret)turret.behaviour).positions)
        {    
            List<Squad> squads = SquadManager.GetSquadsAtPosition(aimedPosition);

            GameObject ob = Instantiate(obus, spawner.transform.position, Quaternion.identity);

            DOTween.Sequence()
                .Append(
                    ob.transform.DOJump(Utils.ModelPositionToWorldPosition(aimedPosition), 3, 1, TempoManager.oneBeatEverySeconds / 2f).SetEase(Ease.InSine)
                )
                .AppendCallback(() => {
                    Destroy(ob);
                    Instantiate(particlesSol, Utils.ModelPositionToWorldPosition(aimedPosition), Quaternion.Euler(90,0,0));
                })
                .Play();
        }


        
    }
}
