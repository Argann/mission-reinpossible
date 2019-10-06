using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    public List<GameObject> credits;

    public void StartGame() {
        SceneManager.LoadScene("Main Scene");
    }

    public void StartCredit() {
        foreach(GameObject go in credits) {
            go.SetActive(!go.activeInHierarchy);
        }
    }

    public void Exit() {
        Application.Quit();
    }
}
