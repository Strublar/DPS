using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger
{
    #region Attributes
    private int listeningEffectId;
    private int value;
    #endregion

    #region Getters & Setters
    public int ListeningEffectId { get => listeningEffectId; set => listeningEffectId = value; }
    public int Value { get => value; set => this.value = value; }
    #endregion


    #region Methods
    public virtual bool ShouldTrigger(Event newEvent)
    {
        return true;
    }

    

    #endregion
}
