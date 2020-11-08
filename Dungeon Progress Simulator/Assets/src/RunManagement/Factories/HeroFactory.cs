using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class HeroFactory
{
    private static string dir = Environment.CurrentDirectory;

    public static Hero BuildNewHero(HeroClass heroClass)
    {
        Hero returnHero = new Hero();
        EntityDefinition definition = new EntityDefinition();
        definition.BaseListeningEffects = new List<ListeningEffectDefinition>();
        definition.BaseStats = ParseStats(heroClass);
        List<Spell> baseSpells = ParseSpellList(heroClass);
        returnHero.RotationSpells = new List<Spell> { baseSpells[0] };
        returnHero.SignatureSpell = baseSpells[1];

        

        definition.Name = "Xavier";
        returnHero.Definition = definition;
        
        return returnHero;
    }

    private static Dictionary<Stat,int> ParseStats(HeroClass heroClass)
    {


        Dictionary<Stat,int> baseStats  = new Dictionary<Stat, int>
        {
            {Stat.Healing,0 },
            {Stat.Damage,0 },
            {Stat.Alive,1 },
            {Stat.Threat,0 },
            {Stat.isBoss,0 },
            {Stat.isHero,1 }

        };

        //Parsing Stats
        string csv = "/Assets/Data/Heroes.csv";
        string path = Path.GetFullPath(dir + csv);
        StreamReader strReader = new StreamReader(path);

        string fileString = strReader.ReadToEnd();
        string[] lines = fileString.Split('\n');

        int heroClassId = (int)heroClass;
        string[] fields = lines[heroClassId + 1].Split(';');
        
        if (fields[1].Equals(heroClass.ToString()))
        {
            baseStats.Add(Stat.Hp, Int32.Parse(fields[2]));
            baseStats.Add(Stat.Armor, Int32.Parse(fields[3]));

        }
        else
        {
            throw new Exception(" Invalid Hero class Id given in builder, table might be wrong");
        }

        return baseStats;
    }

    private static List<Spell> ParseSpellList(HeroClass heroClass)
    {
        //Parsing Stats
        string csv = "/Assets/Data/Heroes.csv";
        string path = Path.GetFullPath(dir + csv);
        StreamReader strReader = new StreamReader(path);

        List<Spell> baseSpells = new List<Spell>();

        string fileString = strReader.ReadToEnd();
        string[] lines = fileString.Split('\n');

        int heroClassId = (int)heroClass;
        string[] fields = lines[heroClassId + 1].Split(';');

        if (fields[1].Equals(heroClass.ToString()))
        {
            baseSpells.Add(ParseSpell(Int32.Parse(fields[4])));
            baseSpells.Add(ParseSpell(Int32.Parse(fields[5])));
        }
        else
        {
            throw new Exception(" Invalid Hero class Id given in builder, table might be wrong");
        }
        return baseSpells;
    }

    private static Spell ParseSpell(int spellId)
    {
        Debug.LogWarning("Starting to parse spell " + spellId);
        Spell baseSpell = new Spell();

        string csv = "/Assets/Data/HeroSpells.csv";
        string path = Path.GetFullPath(dir + csv);
        StreamReader strReader = new StreamReader(path);

        string fileString = strReader.ReadToEnd();
        string[] lines = fileString.Split('\n');

        string[] fields = lines[spellId + 1].Split(';');

        if (fields[0].Equals(spellId.ToString()))
        {
            baseSpell.Name = fields[1];
            baseSpell.Cooldown = Int32.Parse(fields[2]);
            //TODO BETTER
            baseSpell.ValidTarget = (fields[3].Equals("Ally") ? ValidTarget.Ally : ValidTarget.Enemy);
            if (!fields[4].Equals(""))
            {
                baseSpell.Effects.Add(ParseEffect(Int32.Parse(fields[4])));
            }
            if (!fields[5].Equals(""))
            {
                baseSpell.Effects.Add(ParseEffect(Int32.Parse(fields[5])));
            }
            if (!fields[6].Equals("") )
            {
                Debug.LogWarning("CP 1 ["+fields[6]+"]");
                try
                {
                    baseSpell.Effects.Add(ParseEffect(Int32.Parse(fields[6])));
                }
                catch(FormatException) { }
            }

        }
        else
        {
            throw new Exception(" Invalid Hero class Id given in builder, table might be wrong");
        }
        return baseSpell;
    }

    private static Effect ParseEffect(int effectId)
    {
        //Parsing passives
        string csv = "/Assets/Data/HeroEffects.csv";
        string path = Path.GetFullPath(dir + csv);
        StreamReader strReader = new StreamReader(path);

        Effect newEffect = new Effect();

        string fileString = strReader.ReadToEnd();
        string[] lines = fileString.Split('\n');
        string[] fields = lines[effectId + 1].Split(';');

        if (fields[0].Equals(effectId.ToString()))
        {

            object newEffectObject = Activator.CreateInstance(Type.GetType(fields[1]));

            if (newEffectObject is Effect effect)
            {
                newEffect = effect;
                newEffect.Value = Int32.Parse(fields[2]);
                object targetSelectorObject = Activator.CreateInstance(Type.GetType(fields[3]));
                if (targetSelectorObject is TargetSelector targetSelector)
                {
                    newEffect.Targets = targetSelector;
                    newEffect.Targets.Value = Int32.Parse(fields[4]);
                }
                newEffect.Sources = new EffectSourceSelector();

            }
            newEffect.Conditions = new List<Condition>();

            object newConditionObject = Activator.CreateInstance(Type.GetType(fields[5]));
            if(newConditionObject is Condition condition)
            {
                condition.Value = Int32.Parse(fields[6]);
            }

            newEffect.Description = fields[7];
        }
        else
        {
            throw new Exception("Invalid Effect Id, table might be wrong");
        }

        return newEffect;
    }

}

public enum HeroClass : int
{
    Warrior = 0,
    Paladin = 1,
    Rogue = 2,
    Hunter = 3,
    Barbarian = 4,
    Mage = 5,
    Warlock = 6,
    Priest = 7,
    Druid = 8,
    Shaman = 9

}













