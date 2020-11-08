using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class AllAlliesSelector : TargetSelector
{
    #region Methods

    public override int[] GetTargets(Context context)
    {
        

        List<int> query = (from entity in GameManager.fightHandler.Entities
                           where entity.Value.Stats[Stat.isHero] == 1 &&
                           entity.Value.Stats[Stat.Alive] == 1
                           select entity.Value.Id).ToList();

        int[] targetIds = query.ToArray();
        
        return targetIds;
    }
    #endregion
}

