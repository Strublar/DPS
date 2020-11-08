using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero
{
    #region Attributes

    private HeroClass heroClass;
    private EntityDefinition definition;
    private List<Spell> rotationSpells;
    private Spell signatureSpell;
    private Item item;

    #endregion

    #region Getters & Setters
    public HeroClass HeroClass { get => heroClass; set => heroClass = value; }

    public List<Spell> RotationSpells { get => rotationSpells; set => rotationSpells = value; }
    public Item Item { get => item; set => item = value; }
    public EntityDefinition Definition { get => definition; set => definition = value; }
    public Spell SignatureSpell { get => signatureSpell; set => signatureSpell = value; }
    #endregion

    #region Constructor
    public Hero()
    {
        rotationSpells = new List<Spell>
        {
            SpellFactory.BuildTestSpell()
        };
        signatureSpell = SpellFactory.BuildTestHealingSpell();
    }
    #endregion
}
