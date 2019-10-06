using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaunchButton : MonoBehaviour
{
    public GameObject content;

    public List<GameObject> objectsToDisable = new List<GameObject>();

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
}
