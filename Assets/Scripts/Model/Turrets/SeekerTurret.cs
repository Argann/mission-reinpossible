using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// La classe SeekerTurret désigne les tourelles qui ciblent une unité plutôt qu'une case
/// </summary>
public class SeekerTurret : TurretBehaviour
{
    /// <summary>
    /// La victime de cette tourelle
    /// </summary>
    public Squad squad;
}