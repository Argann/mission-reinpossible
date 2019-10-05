using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manager permettant de gérer les escouades en jeu
/// </summary>
public class ShopManager
{
    /// <summary>
    /// L'ensemble des unités disponibles à l'achat
    /// </summary>
    public static List<Unit> units = new List<Unit>();

    /// <summary>
    /// Le montant disponible pour que le joueur achète des unités
    /// </summary>
    public static int money = 0;

    /// <summary>
    /// Le nombre d'unités actuellement sélectionnées
    /// </summary>
    public static int currentAmount = 0;

    /// <summary>
    /// Le type d'unité actuellement sélectionné
    /// </summary>
    public static Unit currentUnit = null;

    /// <summary>
    /// Le prix de l'escouade pour un nombre d'unité sélectionné
    /// </summary>
    public static int currentCost = 0;

    /// <summary>
    /// Méthode d'achat d'une unité
    /// </summary>
    /// <param name="unit">Le type d'unité à acheter</param>
    /// <returns>true si l'unité peut être achetée, false sinon</returns>
    public static bool PurchaseUnit(Unit unit) {
        if (currentUnit == null) {
            currentUnit = unit;
        }
        if(currentUnit == unit) {
            int currentPrice = (int)(unit.initialPrice * Mathf.Pow(unit.priceFactor, currentAmount / unit.stepPrice));

            if (currentCost + currentPrice > money)
                return false;

            currentCost += currentPrice;
            currentAmount ++;
        } else {
            return false;
        }
        return true;
    }

    /// <summary>
    /// Méthode de vente d'une unité
    /// </summary>
    /// <param name="unit">Le type d'unité à vendre</param>
    /// <returns>true si l'unité peut être vendue, false sinon</returns>
    public static bool SellUnit(Unit unit) {
        if (currentUnit == null) {
            currentUnit = unit;
        }
        if(currentUnit == unit) {
            if (currentAmount < 1)
                return false;

            currentAmount --;
            currentCost -= (int)(unit.initialPrice * Mathf.Pow(unit.priceFactor, currentAmount / unit.stepPrice));
        } else {
            return false;
        }
        return true;
    }

    /// <summary>
    /// Méthode opérant l'achat de l'escouade. Réinitialise les valeurs propres à l'achat en cours
    /// </summary>
    public static void PurchaseSquad() {
        SquadManager.PurchaseSquad(currentUnit, currentAmount, currentCost);
        money -= currentCost;
        currentUnit = null;
        currentAmount = 0;
    }

    /// <summary>
    /// Méthode procédant à la vente d'une escouade
    /// </summary>
    /// <param name="squad">L'escouade à vendre</param>
    public static void SellSquad(Squad squad) {
        SquadManager.SellSquad(squad);
        money += squad.value;
    }
}
