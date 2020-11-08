using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class SpellCastEvent : Event
{

    #region Attributes
    private Spell spellCast;

    #endregion

    #region Getters & Setters
    public Spell SpellCast { get => spellCast; set => spellCast = value; }

    #endregion

    #region Constructor
    public SpellCastEvent(int targetId, int sourceId, Spell spellCast) : base(targetId, sourceId)
    {
        this.spellCast = spellCast;
    }



    #endregion
}

