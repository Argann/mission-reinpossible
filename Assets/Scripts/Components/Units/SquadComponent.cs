using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquadComponent : MonoBehaviour
{
    public Squad squad;

    public void CreateUnits()
    {
        foreach (Unit unit in squad.units)
        {
            Vector2 pos = Random.insideUnitCircle * .8f;
            Vector3 realPos = new Vector3(
                Utils.ModelPositionToWorldPosition(squad.Position).x + pos.x,
                Utils.ModelPositionToWorldPosition(squad.Position).y,
                Utils.ModelPositionToWorldPosition(squad.Position).z + pos.y
            );

            Instantiate(unit.prefab, realPos, Quaternion.Euler(0, -45, 0), transform);
        }
    }
}
