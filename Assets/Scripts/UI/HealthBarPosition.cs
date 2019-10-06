﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarPosition : MonoBehaviour
{
    public GameObject UnitNumber;
    public Vector3 offset;

    [HideInInspector]
    public GameObject instance;

    // Start is called before the first frame update
    void Awake()
    {
        instance = Instantiate(UnitNumber, FindObjectOfType<Canvas>().transform);
    }

    // Update is called once per frame
    void Update()
    {
        instance.transform.position = Camera.main.WorldToScreenPoint(transform.position + offset);
    }
}
