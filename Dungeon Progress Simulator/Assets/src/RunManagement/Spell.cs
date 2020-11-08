using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell
{
    #region Attributes
    private string name;
    private int cooldown;
    private List<Effect> effects;
    private ValidTarget validTarget;

    #endregion

    #region Getters & Setters
    public string Name { get => name; set => name = value; }
    public int Cooldown { get => cooldown; set => cooldown = value; }
    public List<Effect> Effects { get => effects; set => effects = value; }
    public ValidTarget ValidTarget { get => validTarget; set => validTarget = value; }
    #endregion

    #region Constructor
    public Spell()
    {
        effects = new List<Effect>();
    }
    #endregion
}

public enum ValidTarget
{
    Enemy,
    Ally
}
