using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class HealEffect : Effect
{
    #region Constructor

    public HealEffect() : base()
    {

    }

    public HealEffect(TargetSelector sources, TargetSelector targets, int value, List<Condition> conditions)
            : base(sources, targets, value, conditions)
    {

    }
    #endregion

    #region Methods
    public override void Execute(Context context, FightHandler fightHandler)
    {
        if (ConditionValid(context, fightHandler))
        {
            Debug.Log("Healing  Effect executed");
            foreach (int targetId in targets.GetTargets(context))
            {
                Entity source = fightHandler.Entities[sources.GetTargets(context)[0]];
                float healing = value * (100.0f + source.Stats[Stat.Healing]) / (100.0f);
                fightHandler.FireEvent(new EntityStatChangedEvent(targetId, targetId, Stat.Hp, (int)healing));
            }
            foreach (int sourceId in sources.GetTargets(context))
            {
                fightHandler.FireEvent(new EntityStatChangedEvent(sourceId, sourceId, Stat.Threat, value));
            }
        }
    }

    public override int GetUpdatedValue(Entity owner)
    {
        int value = (int)((float)this.value * (100.0f + (float)owner.Stats[Stat.Healing]) / 100.0f);
        return value;
    }
    #endregion
}
