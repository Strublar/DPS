using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class InstantTrigger : Trigger
{
    #region Methods
    public override bool ShouldTrigger(Event newEvent)
    {
        if (newEvent is ListeningEffectPlacedEvent listeningEffectPlacedEvent)
        {
            if (listeningEffectPlacedEvent.ListeningEffectId == this.ListeningEffectId)
            {
                return true;
            }
        }

        return false;
    }
    #endregion
}

