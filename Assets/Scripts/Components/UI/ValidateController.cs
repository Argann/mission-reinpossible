using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValidateController : MonoBehaviour
{
    public GameObject squadPrefab;

    public GameObject view;

    public void Buy() {
        GameObject instance = Instantiate(squadPrefab, view.transform);
        ShopManager.PurchaseSquad(instance);
    }


    public static void Sell(GameObject instance) {
        Destroy(instance);
    }
}
