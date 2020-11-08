using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class SpellFactory
{
    public static Spell BuildNewSpell()
    {
        return new Spell();
    }

    public static Spell BuildTestSpell()
    {
        Spell returnSpell = new Spell();

        List<Condition> conditions = new List<Condition> { new TargetAliveCondition(1) };
        Effect newEffect = new DealDamageEffect(new EffectSourceSelector(), 
            new EffectHolderSelector(), 50, conditions);


        returnSpell.Cooldown = 1;
        returnSpell.ValidTarget = ValidTarget.Enemy;
        returnSpell.Effects = new List<Effect> { newEffect };
        return returnSpell;
    }

    public static Spell BuildTestHealingSpell()
    {
        Spell returnSpell = new Spell();

        List<Condition> conditions = new List<Condition> { new TargetAliveCondition(1) };
        Effect newEffect = new HealEffect(new EffectSourceSelector(),
            new EffectHolderSelector(), 5, conditions);


        returnSpell.Cooldown = 3;
        returnSpell.ValidTarget = ValidTarget.Ally;
        returnSpell.Effects = new List<Effect> { newEffect };
        return returnSpell;
    }
}

