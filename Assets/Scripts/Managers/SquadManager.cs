using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manager permettant de gérer les escouades en jeu
/// </summary>
public class SquadManager : MonoBehaviour
{
    /// <summary>
    /// Instance statique du manager d'escouades
    /// </summary>
    public static SquadManager instance;

    /// <summary>
    /// L'ensemble des escouades présentes sur le terrain
    /// </summary>
    public List<Squad> inGameSquads;

    /// <summary>
    /// L'ensemble des escouades présentes dans l'inventaire
    /// </summary>
    public List<Squad> inInventorySquads;

    /// <summary>
    /// Méthode lancée automatiquement par Unity
    /// lors du chargement du script
    /// Enregistre l'instance de classe et initialise la liste d'escouades
    /// </summary>
    void Awake()
    {
        if (instance == null) {
            this.inGameSquads = new List<Squad>();
            this.inInventorySquads = new List<Squad>();
            instance = this;
        }
    }

    /// <summary>
    /// Méthode permettant d'acheter des unités pour les ajouter dans une escouade
    /// </summary>
    /// <param name="squad">L'escouade achetée</param>
    public void PurchaseSquad(Squad squad) {
        //todo : le purchase doit ajouter des unités à une escouade, pas juste ajouter une escouade toute faite
        inInventorySquads.Add(squad);
    }

    /// <summary>
    /// Méthode permettant de passer une escouade de l'inventaire sur le terrain
    /// <param name="squad">L'escouade invoquée sur le terrain</param>
    /// </summary>
    public void SummonSquad(Squad squad) {
        inInventorySquads.Remove(squad);
        inGameSquads.Add(squad);
    }

    /// <summary>
    /// Méthode permettant de déplacer toutes les escouades en jeu
    /// </summary>
    public void MoveSquads()
    {
        foreach(Squad squad in inGameSquads) {
            squad.TriggerMovement();
        }
    }

    /// <summary>
    /// Méthode permettant d'infliger des dégâts aux unités, une par une
    /// </summary>
    /// <param name="squad">L'escouade subissant l'attaque</param>
    /// <param name="damage">Les dégâts répartis sur les unités</param>
    public void DamageSquad(Squad squad, int damage) {
        while (damage > 0 && squad.units.Count > 0){
            Unit unit = squad.units[0];
            damage -= unit.DamageUnit(damage);
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
    public void DamageSplashSquad(Squad squad, int damage) {
        for(int i=squad.units.Count; i>-1; i--) {
            Unit unit = squad.units[i];
            unit.DamageUnit(damage);
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
    public int GetSquadHealth(Squad squad) {
        int totalHealth = 0;
        foreach(Unit unit in squad.units) {
            totalHealth += unit.HP;
        }
        return totalHealth;
    }
}
