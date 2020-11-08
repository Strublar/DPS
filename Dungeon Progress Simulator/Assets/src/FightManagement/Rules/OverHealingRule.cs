using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class OverHealingRule : Rule
{
    #region Methods
    public override void OnEvent(Event newEvent, FightHandler fightHandler)
    {


    }

    public override void OnAfterEvent(Event newEvent, FightHandler fightHandler)
    {
        Debug.Log("Debug 1 ");
        if (newEvent is EntityStatChangedEvent statChangedEvent)
        {
            Debug.Log("Debug 2 ");
            if (statChangedEvent.StatId == Stat.Hp)
            {
                Debug.Log("Debug 3 : Current Hp : " + fightHandler.Entities[newEvent.TargetId].Stats[Stat.Hp]);
                Debug.Log("Debug 3 : Max Hp : " + fightHandler.Entities[newEvent.TargetId].EntityDefinition.BaseStats[Stat.Hp]);
                if (fightHandler.Entities[newEvent.TargetId].Stats[Stat.Hp] > 
                    fightHandler.Entities[newEvent.TargetId].EntityDefinition.BaseStats[Stat.Hp])
                {
                    Debug.Log("OverHealing rule activated");
                    fightHandler.Entities[newEvent.TargetId].Stats[Stat.Hp] = 
                        fightHandler.Entities[newEvent.TargetId].EntityDefinition.BaseStats[Stat.Hp];


                }
            }
        }
    }
    #endregion
}

