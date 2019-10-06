using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarPosition : MonoBehaviour
{
    public GameObject Healthbar;


    [HideInInspector]
    public GameObject instance;
    
    [HideInInspector]
    public Image back;
    
    [HideInInspector]
    public Image fill;
    // Start is called before the first frame update
    void Awake()
    {
        instance = Instantiate(Healthbar, FindObjectOfType<Canvas>().transform);
        back = instance.GetComponent<Image>();
        fill = new List<Image>(back.GetComponentsInChildren<Image>()).Find(img => img != back);
    }

    // Update is called once per frame
    void Update()
    {
        back.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0, 0.5f, 0));
    }
}
