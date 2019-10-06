using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Manager permettant de gérer les tourelles en jeu
/// </summary>
public class TurretManager
{
    /// <summary>
    /// L'ensemble des tourelles présentes sur le terrain
    /// </summary>
    public static List<Turret> inGameTurrets = new List<Turret>();

    public static void Reset()
    {
        inGameTurrets = new List<Turret>();
    }

    /// <summary>
    /// Méthode permettant d'envoyer les évènements d'attaques 
    /// à toutes les tourelles
    /// </summary>
    public static void AttackTurrets()
    {
        foreach (Turret turret in inGameTurrets)
        {
            turret.ProcessAttack();
        }
    }

    /// <summary>
    /// Méthode permettant de générer une liste d'entité
    /// </summary>
    public static void AddTurret(Turret turret)
    {
        inGameTurrets.Add(turret);

        if (turret.turretType == Turret.TurretType.Attendrisseur)
        {
            // Entité
            GameObject go = GameObject.Instantiate(
                MainComponent.Instance.TurretMarteau,
                Utils.ModelPositionToWorldPosition(turret.Position),
                Quaternion.identity
            );
            go.GetComponent<TurretComponent>().turret = turret;
            go.transform.rotation = Quaternion.Euler(turret.rotation);

            // Case
            GameObject.Instantiate(
                MainComponent.Instance.tile, 
                Utils.ModelPositionToWorldPosition(turret.Position), 
                Quaternion.identity
                );
        }
        else if (turret.turretType == Turret.TurretType.Gunringue)
        {
            // Entité
            GameObject go = GameObject.Instantiate(
                MainComponent.Instance.TurretGunringue,
                Utils.ModelPositionToWorldPosition(turret.Position),
                Quaternion.identity
            );
            go.GetComponent<TurretComponent>().turret = turret;
            go.transform.rotation = Quaternion.Euler(turret.rotation);

            // Case
            GameObject.Instantiate(
                MainComponent.Instance.tile, 
                Utils.ModelPositionToWorldPosition(turret.Position), 
                Quaternion.identity
                );
        }
        else if (turret.turretType == Turret.TurretType.Suppobusier)
        {
            // Entité
            GameObject go = GameObject.Instantiate(
                MainComponent.Instance.TurretSuppobusier,
                Utils.ModelPositionToWorldPosition(turret.Position),
                Quaternion.identity
            );
            go.GetComponent<TurretComponent>().turret = turret;
            go.transform.rotation = Quaternion.Euler(turret.rotation);

            // Case
            GameObject.Instantiate(
                MainComponent.Instance.tile, 
                Utils.ModelPositionToWorldPosition(turret.Position), 
                Quaternion.identity
                );
        }
    }

    /// <summary>
    /// Méthode permettant de recharger la liste des niveaux
    /// </summary>
    public static List<TurretAsset> LoadTurretAssets()
    {
        List<TurretAsset> turretAssets = new List<TurretAsset>();

        Object[] rawObjects = Resources.LoadAll("Turrets");

        if (rawObjects.Count() > 0)
        {
            for (int i = 0; i < rawObjects.Count(); i++)
            {
                TurretAsset unit = rawObjects[i] as TurretAsset;

                if (unit != null)
                    turretAssets.Add(unit);
            }
        }

        return turretAssets;
    }
}
