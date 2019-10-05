﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// La classe Turret est la classe mère utilisée par les entités de types "tourelles"
/// </summary>
public class Turret : GameEntity
{
    /// <summary>
    /// Le nombre de points de vie de la tourelle. -- Nécessaire pour les tourelles de type "barrière"
    /// </summary>
    public int hp;
    
    /// <summary>
    /// Les dégâts infligés par la tourelle aux unités du joueur
    /// </summary>
    public int damage;

    /// <summary>
    /// Définit les zones attaquées par les tourelles
    /// </summary>
    public TurretBehaviour behaviour;

    /// <summary>
    /// Définit si la tourelle attaque toutes les unités (true), ou les unités une à une (false)
    /// </summary>
    public bool multipleAttack;

    /// <summary>
    /// La frequence d'attaque de la tourelle. 0 : tous les tours, 1 : un tour de délai, etc
    /// </summary>
    public int frequency;
}
