using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class SpellCastRule : Rule
{
    #region Methods
    public override void OnEvent(Event newEvent, FightHandler fightHandler)
    {

        if (newEvent is SpellCastEvent spellCastEvent)
        {
            Debug.Log("Spell Cast rule activated");

            ListeningEffect newListeningEffect = new ListeningEffect(newEvent.TargetId,
                new InstantTrigger(), new InstantTrigger(), spellCastEvent.SpellCast.Effects);
            fightHandler.ListeningEffects.Add(newListeningEffect);
            fightHandler.FireEvent(new ListeningEffectPlacedEvent(spellCastEvent.TargetId, 
                spellCastEvent.SourceId, newListeningEffect.Id));
            
        }
    }

    public override void OnAfterEvent(Event newEvent, FightHandler fightHandler)
    {

    }
    #endregion
}

