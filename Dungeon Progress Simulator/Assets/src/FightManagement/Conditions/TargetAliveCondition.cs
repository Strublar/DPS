using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class TargetAliveCondition : Condition
{
    public TargetAliveCondition(int value):base(value)
    {
    }

    #region Methods
    public override bool IsValid(Context context, FightHandler fightHandler)
    {
        if(fightHandler.Entities[context.HolderId].Stats[Stat.Alive] == Value)
        {
            return true;
        }
        return false;
    }
    #endregion
}

