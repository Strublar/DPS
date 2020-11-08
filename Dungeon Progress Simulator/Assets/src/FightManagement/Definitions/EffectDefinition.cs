using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectDefinition
{
    #region Attributes
    private int id;
    private string name;
    private Type effectType;
    private int value;
    private TargetSelector targetSelector;
    private TargetSelector sourceSelector;
    private List<Condition> conditions;
    #endregion

    #region Getters & Setters
    public int Id { get => id; set => id = value; }
    public string Name { get => name; set => name = value; }
    public Type EffectType { get => effectType; set => effectType = value; }
    public int Value { get => value; set => this.value = value; }
    internal TargetSelector TargetSelector { get => targetSelector; set => targetSelector = value; }
    internal TargetSelector SourceSelector { get => sourceSelector; set => sourceSelector = value; }
    internal List<Condition> Conditions { get => conditions; set => conditions = value; }


    #endregion
}
