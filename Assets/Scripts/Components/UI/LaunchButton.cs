using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaunchButton : MonoBehaviour
{
    public GameObject content;

    public static LaunchButton instance;

    public List<GameObject> objectsToDisable = new List<GameObject>();

    void Awake() {
        instance = this;
    }

    public void ToGame() {
        if (SquadManager.inInventorySquads.Count == 0)
            return;

        foreach(Button button in content.GetComponentsInChildren<Button>(true)) {
            button.gameObject.SetActive(!button.gameObject.activeInHierarchy);
        }

        foreach (var item in objectsToDisable)
        {
            item.SetActive(false);
        }

        gameObject.SetActive(false);
    }


    public static void ToShop() {
        foreach(Button button in instance.content.GetComponentsInChildren<Button>(true)) {
            button.gameObject.SetActive(!button.gameObject.activeInHierarchy);
        }

        foreach (var item in instance.objectsToDisable)
        {
            item.SetActive(true);
        }

        instance.gameObject.SetActive(true);
    }
}
