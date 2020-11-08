using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class TauntEffect : Effect
{
    #region Constructor

    public TauntEffect() : base()
    {

    }

    public TauntEffect(TargetSelector sources, TargetSelector targets, int value, List<Condition> conditions)
            : base(sources, targets, value, conditions)
    {

    }
    #endregion

    #region Methods
    public override void Execute(Context context, FightHandler fightHandler)
    {
        if (ConditionValid(context, fightHandler))
        {
            Debug.Log("Taunt Effect executed");
            foreach(Entity entity in fightHandler.Entities.Values)
            {
                if(entity.Id != context.SourceId)
                {
                    int threadDrop = entity.Stats[Stat.Threat];
                    fightHandler.FireEvent(new EntityStatChangedEvent(entity.Id, entity.Id, Stat.Threat, -1 * threadDrop));

                }
            }
        }
    }
    #endregion
}

