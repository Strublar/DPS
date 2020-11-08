using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Condition
{
    #region Attributes
    private int value;
    #endregion

    #region Getters & Setters
    public int Value { get => value; set => this.value = value; }
    #endregion

    #region Constructor
    public Condition()
    {
    }

    public Condition(int value)
    {
        this.value = value;
    }

    #endregion

    #region Methods
    public virtual bool IsValid(Context context,FightHandler fightHandler)
    {
        return true;
    }
    #endregion
}
