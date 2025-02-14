﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class DealDamageEffect : Effect
{
    #region Constructor

    public DealDamageEffect() : base()
    {

    }

    public DealDamageEffect(TargetSelector sources, TargetSelector targets, int value, List<Condition> conditions)
            : base(sources, targets, value, conditions)
    {

    }
    #endregion

    #region Methods
    public override void Execute(Context context, FightHandler fightHandler)
    {
        if (ConditionValid(context, fightHandler))
        {
            Debug.Log("Deal Damage Effect executed");
            foreach (int targetId in targets.GetTargets(context))
            {
                try
                {
                    Entity source = fightHandler.Entities[sources.GetTargets(context)[0]];
                    Entity target = fightHandler.Entities[targetId];
                    float damage = value * (100.0f + source.Stats[Stat.Damage]) / (100.0f + target.Stats[Stat.Armor]);
                    fightHandler.FireEvent(new EntityStatChangedEvent(targetId, targetId, Stat.Hp, -1 * (int)damage));
                }
                catch(Exception)
                {
                    Debug.LogWarning("Début debuggage : ");
                    Debug.LogWarning("Debuggage : " + fightHandler);
                    Debug.LogWarning("Debuggage : " + fightHandler.Entities);
                    Debug.LogWarning("Debuggage : " + fightHandler.Entities[0]);
                    Debug.LogWarning("Debuggage : " + targetId);
                    Debug.LogWarning("Fin debuggage : ");
                }
            }

            foreach(int sourceId in sources.GetTargets(context))
            {
                Entity source = fightHandler.Entities[sourceId];//TODO SCALING THREAT
                fightHandler.FireEvent(new EntityStatChangedEvent(sourceId, sourceId, Stat.Threat, value));
            }
        }
    }

    public override int GetUpdatedValue(Entity owner)
    {
        int value = (int)((float)this.value * (100.0f + (float)owner.Stats[Stat.Damage]) / 100.0f);
        return value;
    }
    #endregion
}

