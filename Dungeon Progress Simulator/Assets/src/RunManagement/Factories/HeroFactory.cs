using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class HeroFactory
{
    public static Hero BuildNewHero()
    {
        Hero returnHero = new Hero();
        EntityDefinition definition = new EntityDefinition();
        definition.BaseListeningEffects = new List<ListeningEffectDefinition>();
        definition.BaseStats = new Dictionary<Stat, int>
        {
            {Stat.Hp,100 },
            {Stat.Healing,0 },
            {Stat.Damage,0 },
            {Stat.Armor,50 },
            {Stat.Alive,1 },
            {Stat.Threat,0 },
            {Stat.isBoss,0 },
            {Stat.isHero,1 }

        };
        definition.Name = "Xavier";
        returnHero.Definition = definition;
        return returnHero;
    }
}

