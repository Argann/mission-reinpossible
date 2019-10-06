/// <summary>
/// Classe statique listant tous les évènement utilisés dans le jeu
/// </summary>
public static class EventManager
{
    /// <summary>
    /// Evenement invoqué lors d'un GameOver !
    /// </summary>
    public static GameEvent OnGameOver = new GameEvent();

    /// <summary>
    /// Evenement appelé lorsqu'on passe à un nouveau niveau
    /// </summary>
    public static GameEvent OnNextLevel = new GameEvent();

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

    /// <summary>
    /// Evenement invoqué lorsqu'une ou plusieurs unités sont ajoutées à une escouade
    /// 
    /// "Unit" -> (Unit) Unité venant d'être ajoutée à l'escouade
    /// 
    /// "Squad" -> (Squad) Escouade venant d'ajouter de nouvelles unités
    /// 
    /// "NumberAdded" -> (int) Nombre d'unités ajoutées à l'escouade
    /// </summary>
    /// <returns></returns>
    public static GameEvent OnUnitsAddedToSquad = new GameEvent();

    /// <summary>
    /// Evenement invoqué lorsqu'une escouade est invoquée dans le jeu
    /// 
    /// "Squad" -> (Squad) Escouade venant d'être invoquée
    /// </summary>
    /// <returns></returns>
    public static GameEvent OnSquadInvoked = new GameEvent();

    /// <summary>
    /// Evenement invoqué lorsqu'une escouade se déplace
    /// 
    /// "Squad" -> (Squad) Escouade venant de se déplacer
    /// 
    /// "NewPosition" -> (Vector2) Nouvelle position de l'escouade
    ///
    /// "OldPosition" -> (Vector2) Ancienne position de l'escouade
    /// </summary>
    /// <returns></returns>
    public static GameEvent OnSquadMove = new GameEvent();

    /// <summary>
    /// Evenement invoqué lorsqu'un joueur achète ou vend une unité
    /// 
    /// "Amount" -> (int) Nouvelle quantité à afficher
    /// /// 
    /// "Item" -> (string) Le nom de l'item affecté
    /// </summary>
    /// <returns></returns>
    public static GameEvent OnPurchaseUnit = new GameEvent();

    /// <summary>
    /// Evenement invoqué lorsqu'un joueur achète ou vend une escouade
    /// 
    /// "Amount" -> (int) Nouvelle quantité à afficher
    /// </summary>
    /// <returns></returns>
    public static GameEvent OnPurchaseSquad = new GameEvent();

    /// <summary>
    /// Evenement invoqué lorsque le nombre d'unités sélectionnées évolue
    /// 
    /// "Amount" -> (int) Nouvelle quantité à afficher
    /// </summary>
    /// <returns></returns>
    public static GameEvent OnAmountChange = new GameEvent();

    /// <summary>
    /// Evenement invoqué lorsque le nombre d'unités sélectionnées évolue
    /// 
    /// "Amount" -> (int) Nouveau prix à afficher
    /// </summary>
    /// <returns></returns>
    public static GameEvent OnUnitChange = new GameEvent();
    
    /// Evenement invoqué lorsqu'une escouade est blessée
    ///
    /// "Squad" -> (Squad) Squad blessée
    /// 
    /// "HitAmount" -> (int) Montant des dégats
    /// </summary>
    public static GameEvent OnSquadHit = new GameEvent();

    /// <summary>
    /// Evenement invoqué lorsqu'une escouade est tuée
    ///
    /// "Squad" -> (Squad) Squad tuée
    /// </summary>
    public static GameEvent OnSquadDeath = new GameEvent();

    /// <summary>
    /// Evenement invoqué lorsqu'une tourelle attaque une escouade
    /// 
    /// "Turret" -> (Turret) Tourelle attaquante
    /// 
    /// "Squad" -> (Squad) Escouade attaquée
    /// </summary>
    /// <returns></returns>
    public static GameEvent OnTurretAttack = new GameEvent();

    /// <summary>
    /// Evenement invoqué lorsque l'organe est blessé
    ///
    /// "HitAmount" -> (int) Montant des dégats
    /// </summary>
    public static GameEvent OnOrganHit = new GameEvent();

    /// <summary>
    /// Evenement invoqué lorsque l'organe est tuée
    /// </summary>
    public static GameEvent OnOrganDeath = new GameEvent();
}