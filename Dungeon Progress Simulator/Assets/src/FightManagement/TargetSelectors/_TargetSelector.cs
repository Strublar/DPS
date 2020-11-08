using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSelector
{
    #region Attributes
    private int value;

    #endregion

    #region Getters & Setters
    public int Value { get => value; set => this.value = value; }

    #endregion


    #region Methods
    public virtual int[] GetTargets(Context context)
    {
        int[] returnInt = { };
        return returnInt;
    }
    #endregion

    #region Static Methods

    public static void BuildFrom(string targetSelector, string tsValue)
    {

    }
    #endregion
}
