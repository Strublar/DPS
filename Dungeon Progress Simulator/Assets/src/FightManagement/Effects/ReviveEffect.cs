using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class ReviveEffect : Effect
{
    #region Constructor

    public ReviveEffect() : base()
    {

    }

    public ReviveEffect(TargetSelector sources, TargetSelector targets, int value, List<Condition> conditions)
            : base(sources, targets, value, conditions)
    {

    }
    #endregion

    #region Methods
    public override void Execute(Context context, FightHandler fightHandler)
    {
        if (ConditionValid(context, fightHandler))
        {
            Debug.Log("Revive Effect executed");
            if(fightHandler.Entities[context.HolderId].Stats[Stat.Alive] == 0)
            {
                int resetHp = fightHandler.Entities[context.HolderId].Stats[Stat.Hp];
                fightHandler.FireEvent(new EntityStatChangedEvent(context.HolderId, context.HolderId, Stat.Hp, -1*resetHp + 1));
                fightHandler.FireEvent(new EntityStatChangedEvent(context.HolderId, context.HolderId, Stat.Alive, 1));
            }
        }
    }

    public override int GetUpdatedValue(Entity owner)
    {

        return base.GetUpdatedValue(owner);
    }
    #endregion
}

