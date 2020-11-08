using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss
{
    #region Attributes
    private EntityDefinition definition;
    private List<Spell> spells;

    #endregion

    #region Getters & Setters
    
    public List<Spell> Spells { get => spells; set => spells = value; }
    public EntityDefinition Definition { get => definition; set => definition = value; }
    #endregion

    #region Constructor
    public Boss()
    {

    }
    #endregion
}
