using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityDefinition
{
    #region Attributes
    private int id;
    private string name;
    private Dictionary<Stat, int> baseStats;
    private List<ListeningEffectDefinition> baseListeningEffects;


    #endregion

    #region Getters & Setters
    public int Id { get => id; set => id = value; }
    public string Name { get => name; set => name = value; }
    public Dictionary<Stat, int> BaseStats { get => baseStats; set => baseStats = value; }
    public List<ListeningEffectDefinition> BaseListeningEffects { get => baseListeningEffects; set => baseListeningEffects = value; }
    #endregion
}
