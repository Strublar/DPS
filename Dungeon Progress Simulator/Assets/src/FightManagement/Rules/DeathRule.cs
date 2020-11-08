using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class DeathRule : Rule
{
    #region Methods
    public override void OnEvent(Event newEvent, FightHandler fightHandler)
    {

        
    }

    public override void OnAfterEvent(Event newEvent, FightHandler fightHandler)
    {
        if (newEvent is EntityStatChangedEvent statChangedEvent)
        {
            if (statChangedEvent.StatId == Stat.Hp)
            {
                if(fightHandler.Entities[newEvent.TargetId].Stats[Stat.Hp] <= 0 
                    && fightHandler.Entities[newEvent.TargetId].Stats[Stat.Alive] == 1)
                {
                    Debug.Log("Death rule activated");
                    fightHandler.FireEvent(new EntityStatChangedEvent(newEvent.TargetId, newEvent.TargetId, Stat.Alive, -1));
                    if(fightHandler.Entities[newEvent.TargetId].Stats[Stat.Alive] == 0)
                    {
                        fightHandler.FireEvent(new EntityDiesEvent(newEvent.TargetId, newEvent.SourceId));
                    }
                }
            }
        }
    }
    #endregion
}

