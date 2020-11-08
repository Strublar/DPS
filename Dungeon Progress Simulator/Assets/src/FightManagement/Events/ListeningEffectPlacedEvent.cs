using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class ListeningEffectPlacedEvent : Event
{
    #region Attributes
    private int listeningEffectId;
    #endregion

    #region Getters & Setters
    public int ListeningEffectId { get => listeningEffectId; set => listeningEffectId = value; }
    #endregion

    #region Constructor
    public ListeningEffectPlacedEvent(int targetId, int sourceId, int listeningEffectId) : base(targetId, sourceId)
    {
        this.listeningEffectId = listeningEffectId;
    }


    #endregion
}

