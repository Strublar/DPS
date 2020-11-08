using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class GainThreatEffect : Effect
{
    #region Constructor

    public GainThreatEffect() : base()
    {

    }

    public GainThreatEffect(TargetSelector sources, TargetSelector targets, int value, List<Condition> conditions)
            : base(sources, targets, value, conditions)
    {

    }
    #endregion

    #region Methods
    public override void Execute(Context context, FightHandler fightHandler)
    {
        if (ConditionValid(context, fightHandler))
        {
            Debug.Log("Gain threat  Effect executed");
            foreach (int targetId in targets.GetTargets(context))
            {
                fightHandler.FireEvent(new EntityStatChangedEvent(targetId, targetId, Stat.Threat, value));
            }
        }
    }

    public override int GetUpdatedValue(Entity owner)
    {
        
        return base.GetUpdatedValue(owner);
    }
    #endregion
}

