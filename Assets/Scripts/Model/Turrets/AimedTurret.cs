using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// La classe AimedTurret désigne les tourelles qui ciblent 1..n cases définies
/// </summary>
public class AimedTurret : TurretBehaviour
{
    /// <summary>
    /// La liste des cases ciblées par la tourelle
    /// </summary>
    public List<Vector2> positions;
}