using UnityEngine;

[CreateAssetMenu(menuName = "Game Design/Unit Asset", fileName = "New Unit Asset")]
public class UnitAsset : GameEntityAsset
{
    public int maxHP;

    public int damage;

    public int initialPrice;

    public int moveSpeed;

    public int stepPrice;

    public float priceFactor;

    public string maname;
}