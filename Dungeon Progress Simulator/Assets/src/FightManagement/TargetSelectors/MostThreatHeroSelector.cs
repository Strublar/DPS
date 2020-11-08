using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class MostThreatHeroSelector : TargetSelector
{
    #region Methods

    public override int[] GetTargets(Context context)
    {
        int[] targetIds = new int[1];
        List<int> query = (from entity in GameManager.fightHandler.Entities
                                where entity.Value.Stats[Stat.isHero] == 1 &&
                                entity.Value.Stats[Stat.Alive] == 1
                                select entity.Value.Id).ToList();

        List<int> mostThreatQuery = new List<int>();
        int maxThreat = 0;
        foreach(int element in query)
        {
            Entity entity = GameManager.fightHandler.Entities[element];
            Debug.LogWarning("Menace de l'entité : " + entity.Id + " = "+ entity.Stats[Stat.Threat]);
            if (entity.Stats[Stat.Threat]>maxThreat)
            {
                maxThreat = entity.Stats[Stat.Threat];
                mostThreatQuery = new List<int> { entity.Id };
                
            }
            else if (entity.Stats[Stat.Threat] == maxThreat)
            {
                mostThreatQuery.Add(entity.Id);
            }
        }

        int index = UnityEngine.Random.Range(0, mostThreatQuery.Count-1);
        targetIds[0] = mostThreatQuery[index];
        return targetIds;
    }
    #endregion
}

