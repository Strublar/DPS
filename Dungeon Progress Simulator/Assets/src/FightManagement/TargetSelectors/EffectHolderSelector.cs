using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class EffectHolderSelector : TargetSelector
{
    #region Methods

    public override int[] GetTargets(Context context)
    {
        int[] targetIds = { context.HolderId };
        return targetIds;
    }
    #endregion
}

