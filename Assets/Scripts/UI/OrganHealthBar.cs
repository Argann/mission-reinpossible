using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrganHealthBar : MonoBehaviour
{
    public Vector3 offset;
    private Image healthBar;
    private Image foreground;

    private GameObject rein;

    private float maxHP;

    // Start is called before the first frame update
    void Awake()
    {
        offset = new Vector3(0f,45f,0f);
        healthBar = GetComponent<Image>();
        foreground = healthBar.transform.GetChild(0).gameObject.GetComponent<Image>();
        EventManager.OnOrganHit.AddListener(_ => {
            foreground.fillAmount = (float)OrganManager.HP / maxHP;
        });
        EventManager.OnLevelLoaded.AddListener(_ => {
            maxHP = (float)OrganManager.HP;
            foreground.fillAmount = (float)OrganManager.HP / maxHP;
        });
    }

    void Start() {
        maxHP = (float)OrganManager.HP;
        foreground.fillAmount = (float)OrganManager.HP / maxHP;
    }

    void Update() {
        rein = GameObject.FindWithTag("Rein");
        if (rein != null) healthBar.transform.position = Camera.main.WorldToScreenPoint(rein.transform.position) - offset;
    }
}
