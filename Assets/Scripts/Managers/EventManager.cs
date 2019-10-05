/// <summary>
/// Classe statique listant tous les évènement utilisés dans le jeu
/// </summary>
public static class EventManager
{
    /// <summary>
    /// Evenement invoqué lorsqu'un battement de jeu
    /// survient.
    /// <para>"BeatNumber" -> Numéro du battement survenu</para>
    /// </summary>
    public static GameEvent OnTempoBeat = new GameEvent();
}