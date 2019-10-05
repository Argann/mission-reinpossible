/// <summary>
/// Classe statique listant tous les évènement utilisés dans le jeu
/// </summary>
public static class EventManager
{
    /// <summary>
    /// Evenement invoqué lorsqu'un battement de jeu
    /// survient.
    /// 
    /// "BeatNumber" -> (int) Numéro du battement survenu
    /// </summary>
    public static GameEvent OnTempoBeat = new GameEvent();

    /// <summary>
    /// Evenement invoqué lorsqu'une unité est soignée
    ///
    /// "Unit" -> (Unit) Unité soignée
    /// 
    /// "HealAmount" -> (int) Montant du soin
    /// </summary>
    public static GameEvent OnUnitHeal = new GameEvent();

    /// <summary>
    /// Evenement invoqué lorsqu'une unité est blessée
    ///
    /// "Unit" -> (Unit) Unité blessée
    /// 
    /// "HitAmount" -> (int) Montant des dégats
    /// </summary>
    public static GameEvent OnUnitHit = new GameEvent();

    /// <summary>
    /// Evenement invoqué lorsqu'une unité se déplace
    ///
    /// "Unit" -> (Unit) Unité se déplaçant
    /// 
    /// "NewPosition" -> (Vector2) Nouvelle position de l'unité
    ///
    /// "OldPosition" -> (Vector2) Ancienne position de l'unité
    /// </summary>
    public static GameEvent OnUnitMove = new GameEvent();
}