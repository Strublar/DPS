using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class EntityStatChangedRule : Rule
{
    #region Methods
    public override void OnEvent(Event newEvent, FightHandler fightHandler)
    {

        if (newEvent is EntityStatChangedEvent statChangedEvent)
        {
            Debug.Log("EntityStatChanged rule activated with stat : "+statChangedEvent.StatId);
            fightHandler.Entities[statChangedEvent.TargetId].Stats[statChangedEvent.StatId] += statChangedEvent.ValueChange;
            
        }
    }

    public override void OnAfterEvent(Event newEvent, FightHandler fightHandler)
    {

    }
    #endregion
}

