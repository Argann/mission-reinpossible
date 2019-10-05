using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    public static Squad PurchaseSquad(Unit unit, int number, int value) {
        Squad squad = new Squad();
        squad.value = value;
        for(int i=0; i<number; i++) {
            squad.units.Add(new Unit(unit));
        }
        inInventorySquads.Add(squad);
        return squad;
    }

    /// <summary>
    /// Méthode permettant de supprimer de l'inventaire l'escouade cible
    /// </summary>
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

        GameObject squadGo = GameObject.Instantiate(MainComponent.Instance.Squad, Utils.ModelPositionToWorldPosition(squad.Position), Quaternion.identity);
        squadGo.GetComponent<SquadComponent>().squad = squad;
    }

    /// <summary>
    /// Méthode permettant de déplacer toutes les escouades en jeu
    /// </summary>
    public static void MoveSquads()
    {
        foreach(Squad squad in inGameSquads) {
            
            int squadMoveSpeed = squad.units[0].moveSpeed;
            Vector3 targetPosition = squad.Position;

            for (int i = 0; i < squadMoveSpeed; i++)
            {
                targetPosition = MapManager.GetNextPositionInPath(targetPosition);
            }

            squad.Position = targetPosition;
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
            EventManager.OnSquadHit.Invoke(new GameEventPayload()
            {
                {"Squad", squad},
                {"HitAmount", damage}
            });
        }
        if (squad.units.Count == 0) {
            inGameSquads.Remove(squad);
            EventManager.OnSquadDeath.Invoke(new GameEventPayload()
            {
                {"Squad", squad}
            });
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
            EventManager.OnSquadHit.Invoke(new GameEventPayload()
            {
                {"Squad", squad},
                {"HitAmount", damage}
            });
        }
        if (squad.units.Count == 0) {
            inGameSquads.Remove(squad);
            EventManager.OnSquadDeath.Invoke(new GameEventPayload()
            {
                {"Squad", squad}
            });
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

    /// <summary>
    /// Méthode permettant de recharger la liste des niveaux
    /// </summary>
    public static List<UnitAsset> LoadUnitAssets()
    {
        List<UnitAsset> unitAssets = new List<UnitAsset>();

        Object[] rawObjects = Resources.LoadAll("Units");

        if (rawObjects.Count() > 0)
        {
            for (int i = 0; i < rawObjects.Count(); i++)
            {
                UnitAsset unit = rawObjects[i] as UnitAsset;

                if (unit != null)
                    unitAssets.Add(unit);
            }
        }

        return unitAssets;
    }
}
