using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaunchButton : MonoBehaviour
{
    public GameObject content;

    public void ToGame() {
        foreach(Button button in content.GetComponentsInChildren<Button>(true)) {
            button.gameObject.SetActive(!button.gameObject.activeInHierarchy);
        }
    }
}
