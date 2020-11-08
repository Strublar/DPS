using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rule
{
    #region Methods
    public virtual void OnEvent(Event newEvent, FightHandler fightHandler)
    {

    }

    public virtual void OnAfterEvent(Event newEvent, FightHandler fightHandler)
    {

    }

    #endregion
}
