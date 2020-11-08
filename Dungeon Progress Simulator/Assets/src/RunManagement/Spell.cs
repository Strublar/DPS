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
    private string description;
    #endregion

    #region Getters & Setters
    public string Name { get => name; set => name = value; }
    public int Cooldown { get => cooldown; set => cooldown = value; }
    public List<Effect> Effects { get => effects; set => effects = value; }
    public ValidTarget ValidTarget { get => validTarget; set => validTarget = value; }
    public string Description { get => description; set => description = value; }
    #endregion

    #region Constructor
    public Spell()
    {
        effects = new List<Effect>();
    }
    #endregion

    #region Methods
    public string GetUpdateDescription(Entity owner)
    {
        description = "";
        foreach(Effect effect in effects)
        {
            int value = effect.GetUpdatedValue(owner);
            description += string.Format(effect.Description, value);
            description += " ";
        }

        description = description.Replace("\r", "");
        description = description.Replace(".", "");
        return description;
    }

    #endregion
}

public enum ValidTarget
{
    Enemy,
    Ally
}
