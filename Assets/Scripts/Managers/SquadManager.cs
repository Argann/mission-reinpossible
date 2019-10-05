using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manager permettant de gérer les escouades en jeu
/// </summary>
public class SquadManager
{
    /// <summary>
    /// L'ensemble des escouades présentes sur le terrain
    /// </summary>
    public static List<Squad> inGameSquads = new List<Squad>();

    /// <summary>
    /// L'ensemble des escouades présentes dans l'inventaire
    /// </summary>
    public static List<Squad> inInventorySquads = new List<Squad>();

    /// <summary>
    /// Méthode permettant d'acheter des unités pour les ajouter dans une escouade
    /// </summary>
    /// <param name="unit">Le type d'unité de l'escouade</param>
    /// <param name="number">Le nombre d'unités à ajouter à l'escouade</param>
    public static void PurchaseSquad(Unit unit, int number, int value) {
        Squad squad = new Squad();
        squad.value = value;
        for(int i=0; i<number; i++) {
            squad.units.Add(new Unit(unit));
        }
        inInventorySquads.Add(squad);
    }

    public static void SellSquad(Squad squad) {
        inInventorySquads.Remove(squad);
    }

    /// <summary>
    /// Méthode permettant de passer une escouade de l'inventaire sur le terrain
    /// <param name="squad">L'escouade invoquée sur le terrain</param>
    /// </summary>
    public static void SummonSquad(Squad squad) {
        inInventorySquads.Remove(squad);
        inGameSquads.Add(squad);
    }

    /// <summary>
    /// Méthode permettant de déplacer toutes les escouades en jeu
    /// </summary>
    public static void MoveSquads()
    {
        foreach(Squad squad in inGameSquads) {
            //squad.TriggerMovement();
        }
    }

    /// <summary>
    /// Méthode permettant d'infliger des dégâts aux unités, une par une
    /// </summary>
    /// <param name="squad">L'escouade subissant l'attaque</param>
    /// <param name="damage">Les dégâts répartis sur les unités</param>
    public static void DamageSquad(Squad squad, int damage) {
        while (damage > 0 && squad.units.Count > 0){
            Unit unit = squad.units[0];
            damage -= DamageUnit(unit, damage);
            if (unit.HP <= 0) {
                squad.units.Remove(unit);
            }
        }
        if (squad.units.Count == 0) {
            inGameSquads.Remove(squad);
        }
    }

    /// <summary>
    /// Méthode permettant d'infliger des dégâts aux unités, toutes à la fois
    /// </summary>
    /// <param name="squad">L'escouade subissant l'attaque</param>
    /// <param name="damage">Les dégâts infligés à toutes les unités</param>
    public static void DamageSplashSquad(Squad squad, int damage) {
        for(int i=squad.units.Count; i>-1; i--) {
            Unit unit = squad.units[i];
            DamageUnit(unit, damage);
            if (unit.HP <= 0) {
                squad.units.Remove(unit);
            }
        }
        if (squad.units.Count == 0) {
            inGameSquads.Remove(squad);
        }
    }

    /// <summary>
    /// Methode permettant de connaitre la vie totale d'une escouade
    /// </summary>
    /// <param name="squad">L'escouade dont on veut connaitre la vie</param>
    /// <returns></returns>
    public static int GetSquadHealth(Squad squad) {
        int totalHealth = 0;
        foreach(Unit unit in squad.units) {
            totalHealth += unit.HP;
        }
        return totalHealth;
    }

    /// <summary>
    /// Méthode permettant d'infliger des dégâts à une unité
    /// </summary>
    /// <param name="unit">L'unité endommagée</param>
    /// <param name="damage">Les dégâts infligés</param>
    /// <returns>Les dégâts réellement infligés</returns>
    public static int DamageUnit(Unit unit, int damage) {
        int result = Mathf.Min(unit.HP, damage);
        unit.HP -= damage;
        return result;
    }

    /// <summary>
    /// Méthode appelée lorsque l'escouade atteint l'organe : l'escouade est détruire en infligeant la somme des dommages de ses unités
    /// </summary>
    /// <param name="squad">L'escouade atteignant l'organe</param>
    /// <returns>Les dégâts infligés par l'escouade</returns>
    public static int Kamikazee(Squad squad) {
        int result = 0;
        foreach(Unit unit in squad.units) {
            result += unit.damage;
        }
        inGameSquads.Remove(squad);
        return result;
    }
}
