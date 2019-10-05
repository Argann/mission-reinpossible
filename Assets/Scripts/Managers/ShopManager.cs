using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public static int money = 1000;

    public static int Money {
        get => money;

        set {
            money = value;
            EventManager.OnPurchaseSquad.Invoke(new GameEventPayload() {
                {"Amount", value}
            });
        }
    }

    /// <summary>
    /// Le nombre d'unités actuellement sélectionnées
    /// </summary>
    private static int currentAmount = 0;

    public static int CurrentAmount {
        get => currentAmount;

        set {
            currentAmount = value;
            EventManager.OnPurchaseUnit.Invoke(new GameEventPayload() {
                {"Amount", value},
                {"Item", currentUnit.maname}
            });

        }
    }

    /// <summary>
    /// Le type d'unité actuellement sélectionné
    /// </summary>
    public static Unit currentUnit = null;

    /// <summary>
    /// Le prix de l'escouade pour un nombre d'unité sélectionné
    /// </summary>
    private static int currentCost = 0;

    /// <summary>
    /// Le prix de l'escouade pour un nombre d'unité sélectionné
    /// </summary>
    private static int currentPrice = 0;

    public static int CurrentPrice {
        get => currentPrice;

        set {
            currentPrice = value;
            EventManager.OnUnitChange.Invoke(new GameEventPayload() {
                {"Amount", value},
                {"Item", currentUnit.maname}
            });
        }
    }

    public static int CurrentCost {
        get => currentCost;

        set {
            currentCost = value;
            EventManager.OnAmountChange.Invoke(new GameEventPayload() {
                {"Amount", value},
                {"Item", currentUnit.maname}
            });
        }
    }

    /// <summary>
    /// Méthode d'achat d'une unité
    /// </summary>
    /// <param name="unit">Le type d'unité à acheter</param>
    /// <returns>true si l'unité peut être achetée, false sinon</returns>
    public static bool PurchaseUnit(Unit unit) {
        if (currentUnit == null) {
            currentUnit = unit;
        }
        if(currentUnit.maname == unit.maname) {
            CurrentPrice = (int)(unit.initialPrice * Mathf.Pow(unit.priceFactor, currentAmount / unit.stepPrice));

            if (currentCost + CurrentPrice > money)
                return false;

            CurrentCost += CurrentPrice;
            CurrentAmount ++;
            CurrentPrice = (int)(unit.initialPrice * Mathf.Pow(unit.priceFactor, currentAmount / unit.stepPrice));
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
        if (CurrentAmount < 1)
                return false;

        if (currentUnit == null) {
            currentUnit = unit;
        }
        if(currentUnit.maname == unit.maname) {
            CurrentAmount --;
            CurrentPrice = (int)(unit.initialPrice * Mathf.Pow(unit.priceFactor, currentAmount / unit.stepPrice));
            CurrentCost -= CurrentPrice;
            if (CurrentAmount == 0)
                currentUnit = null;

        } else {
            return false;
        }
        return true;
    }

    /// <summary>
    /// Méthode opérant l'achat de l'escouade. Réinitialise les valeurs propres à l'achat en cours
    /// </summary>
    public static void PurchaseSquad(GameObject instance) {
        Squad squad = SquadManager.PurchaseSquad(currentUnit, CurrentAmount, CurrentCost);
        Money -= CurrentCost;

        instance.GetComponentInChildren<Text>().text = ""+CurrentAmount;
        Button button = instance.GetComponentInChildren<Button>();
        button.onClick.AddListener(() => {
            ValidateController.Sell(instance);
            ShopManager.SellSquad(squad);
        });

        instance.transform
            .Find("Deployer")
            .GetComponent<Button>()
            .onClick.AddListener(() => {
                SquadManager.SummonSquad(squad);
                GameObject.Destroy(instance);
            });

        CurrentAmount = 0;
        CurrentPrice = currentUnit.initialPrice;
        CurrentCost = 0;
        currentUnit = null;
    }

    /// <summary>
    /// Méthode procédant à la vente d'une escouade
    /// </summary>
    /// <param name="squad">L'escouade à vendre</param>
    public static void SellSquad(Squad squad) {
        SquadManager.SellSquad(squad);
        Money += squad.value;
    }
}
