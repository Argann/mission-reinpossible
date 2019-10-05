using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Path
{
    [SerializeField]
    public List<Vector3> path = new List<Vector3>();

    public Vector2 this[int key]
    {
        get
        {
            return path[key];
        }
        set
        {
            path[key] = value;
        }
    }
}