
using UnityEngine;

public class Utils
{
    public static Vector3 ModelPositionToWorldPosition(Vector3 modelPosition)
    {
        return modelPosition * MainComponent.Instance.modelToWorldScaleFactor;
    }
}