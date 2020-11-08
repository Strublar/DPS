using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passive
{
    #region Attributes
    private string name;
    private List<ListeningEffectDefinition> effects;

    #endregion

    #region Getters & Setters
    public string Name { get => name; set => name = value; }
    public List<ListeningEffectDefinition> Effects { get => effects; set => effects = value; }
    #endregion
}
