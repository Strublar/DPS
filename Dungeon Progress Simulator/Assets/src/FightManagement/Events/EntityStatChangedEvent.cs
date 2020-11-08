using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class EntityStatChangedEvent : Event
{
    #region Attributes
    private Stat statId;
    private int valueChange;
    #endregion

    #region Getters & Setters
    public Stat StatId { get => statId; set => statId = value; }
    public int ValueChange { get => valueChange; set => valueChange = value; }
    #endregion

    #region Constructor
    public EntityStatChangedEvent(int targetId, int sourceId, Stat stat, int valueChange) : base(targetId, sourceId)
    {
        this.statId = stat;
        this.valueChange = valueChange;
    }


    #endregion
}

