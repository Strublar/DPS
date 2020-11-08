using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect
{
    #region Attributes
    protected int value;
    protected TargetSelector targets;
    protected TargetSelector sources;
    protected List<Condition> conditions;


    #endregion

    #region Getters & Setters
    public TargetSelector Targets { get => targets; set => targets = value; }
    public TargetSelector Sources { get => sources; set => sources = value; }
    public List<Condition> Conditions { get => conditions; set => conditions = value; }
    public int Value { get => value; set => this.value = value; }
    #endregion

    #region Constructor
    public Effect()
    {

    }
    public Effect(TargetSelector sources, TargetSelector targets, int value, List<Condition> conditions)
    {
        this.targets = targets;
        this.sources = sources;
        this.conditions = new List<Condition>();
        this.value = value;
        this.conditions = conditions;
    }
    #endregion

    #region Methods

    public virtual void Execute(Context context, FightHandler fightHandler)
    {

    }

    public bool ConditionValid(Context context,FightHandler fightHandler)
    {
        foreach (Condition condition in conditions)
        {
            if (!condition.IsValid(context,fightHandler))
            {
                return false;
            }
        }
        return true;
    }


    #endregion
}
