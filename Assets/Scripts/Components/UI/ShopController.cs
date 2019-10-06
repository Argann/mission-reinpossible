using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    public UnitAsset unitAsset;

    public void Buy() {
        Unit unit = new Unit(unitAsset, new Vector3(0, 0, 0));
        ShopManager.PurchaseUnit(unit);
    }

    public void Buy5() {
        for (int i = 0; i < 5; i++) Buy();
    }

    public void Sell() {
        Unit unit = new Unit(unitAsset, new Vector3(0, 0, 0));
        ShopManager.SellUnit(unit);
    }

    public void Sell5() {
        for (int i = 0; i < 5; i++) Sell();
    }
}
