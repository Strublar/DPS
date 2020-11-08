using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class EffectSourceSelector : TargetSelector
{
    #region Methods

    public override int[] GetTargets(Context context)
    {
        int[] targetIds = { context.SourceId };
        return targetIds;
    }
    #endregion
}

