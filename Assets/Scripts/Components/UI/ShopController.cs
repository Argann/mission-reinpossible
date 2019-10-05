using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopController : MonoBehaviour
{
    public UnitAsset unitAsset;
    public void Buy() {
        Unit unit = new Unit(unitAsset, new Vector3(0, 0, 0));
        ShopManager.PurchaseUnit(unit);
    }

    public void Sell() {
        Unit unit = new Unit(unitAsset, new Vector3(0, 0, 0));
        ShopManager.SellUnit(unit);
    }
}
