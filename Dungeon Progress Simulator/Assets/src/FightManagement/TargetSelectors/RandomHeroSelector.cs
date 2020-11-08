using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class RandomHeroSelector : TargetSelector
{
    #region Methods

    public override int[] GetTargets(Context context)
    {


        List<int> query = (from entity in GameManager.fightHandler.Entities
                           where entity.Value.Stats[Stat.isHero] == 1 &&
                           entity.Value.Stats[Stat.Alive] == 1
                           select entity.Value.Id).ToList();

        List<int> returnList = new List<int>();
        int timeout = 0;
        do
        {
            int randint = UnityEngine.Random.Range(0,query.Count-1);
            if(!returnList.Contains<int>(randint))
            {
                returnList.Add(randint);
            }
        } while (returnList.Count < this.Value || timeout>100);
        if(timeout>100)
        {
            Debug.LogWarning("Timeout happened in RandomHeroSelector, might bring exception later");
        }
        int[] targetId = new int[returnList.Count];
        for(int i=0;i<returnList.Count;i++)
        {
            targetId[i] = query[returnList[i]];
        }

        return targetId;
    }
    #endregion
}

