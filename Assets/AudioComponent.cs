using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class AudioComponent : MonoBehaviour
{
    [System.Serializable]
    public struct AudioElement
    {
        public string name;
        public AudioClip clip;
        public float delay;

        [Range(0, 1)]
        public float volume;
    }

    public List<AudioElement> elements;

    public AudioSource source;

    public static void PlayFX(AudioElement e)
    {
        DOTween.Sequence()
            .InsertCallback(e.delay, () => {
                Instance.source.PlayOneShot(e.clip, e.volume);
            });
    }

    public static void PlayFX(string search)
    {
        AudioElement e = Instance.elements.Find(_ => _.name.Contains(search.Trim()));

        if (e.clip == null)
        {
            Debug.Log($"Aucun son ayant le nom {search} n'a été trouvé !");
            return;
        }

        PlayFX(e);
    }

    public static void PlayRandomFX(string search)
    {
        List<AudioElement> es = Instance.elements.FindAll(_ => _.name.Contains(search.Trim()));

        if (es == null || es.Count == 0)
        {
            Debug.Log($"Aucun son ayant le nom {search} n'a été trouvé !");
            return;
        }

        PlayFX(es[Random.Range(0, es.Count)]);
    }

    public static void PlayUnitMove(Unit unit)
    {
        if (unit.unitType == UnitAsset.UnitType.Petit)
        {
            PlayRandomFX("Petit Virus - Move");
        }
        else if (unit.unitType == UnitAsset.UnitType.Moyen)
        {
            PlayRandomFX("Moyen Virus GT - Move");
            PlayRandomFX("Moyen Virus PT - Move");

        }
        else if (unit.unitType == UnitAsset.UnitType.Gros)
        {
            PlayRandomFX("Gros Virus - Move");

        }
    }

    public static void PlayUnitDeath(Unit unit)
    {
        if (unit.unitType == UnitAsset.UnitType.Petit)
        {
            PlayRandomFX("Petit Virus - Death");
        }
        else if (unit.unitType == UnitAsset.UnitType.Moyen)
        {
            PlayRandomFX("Moyen Virus GT - Death");
            PlayRandomFX("Moyen Virus PT - Death");

        }
        else if (unit.unitType == UnitAsset.UnitType.Gros)
        {
            PlayRandomFX("Gros Virus - Death");

        }
    }

    private static AudioComponent instance;

    public static AudioComponent Instance
    {
        get {
            if (instance == null)
            {
                instance = GameObject.Find("Main Camera").GetComponent<AudioComponent>();
            }
            return instance;
        }
    }
}
