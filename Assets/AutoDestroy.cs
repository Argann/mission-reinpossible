﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    void Awake () {
        EventManager.OnNextLevel.AddListener(_ => Destroy(gameObject));

    }
}
