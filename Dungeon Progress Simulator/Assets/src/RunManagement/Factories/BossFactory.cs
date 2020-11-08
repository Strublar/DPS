using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class BossFactory
{
    private static string dir = Environment.CurrentDirectory;
    public static Boss BuildNewBoss(int bossId = 0, int bossDifficulty = 0)
    {
        Boss returnBoss = new Boss();
        EntityDefinition definition = new EntityDefinition();


        definition.BaseStats = ParseBaseStats(bossId, bossDifficulty);
        definition.BaseListeningEffects = ParsePassives();
        returnBoss.Spells = new List<Spell>
        {
            ParseSpell(),
            ParseSpell(),
            ParseSpell(),
            ParseSpell(),
            ParseSpell()
        };

        definition.Name = ParseName();
        returnBoss.Definition = definition;
        return returnBoss;
    }

    private static Dictionary<Stat,int> ParseBaseStats(int bossId, int bossDifficulty)
    {
        //Parsing Stats
        string csv = "/Assets/Data/Bosses.csv";
        string path = Path.GetFullPath(dir + csv);
        StreamReader strReader = new StreamReader(path);

        Dictionary<Stat,int> baseStats = new Dictionary<Stat, int>();

        string fileString = strReader.ReadToEnd();
        string[] lines = fileString.Split('\n');

        string[] fields = lines[bossId + 1].Split(';');
        if (fields[0].Equals(bossId.ToString()))
        {
            baseStats.Add(Stat.Hp, (int)((float)Int32.Parse(fields[1])*(100.0f+20.0f*bossDifficulty)/100.0f));
            baseStats.Add(Stat.Armor, (int)((float)Int32.Parse(fields[2]) * (100.0f + 20.0f * bossDifficulty) / 100.0f));
            baseStats.Add(Stat.Alive, 1);
            baseStats.Add(Stat.Damage, 20*bossDifficulty);
            baseStats.Add(Stat.Healing, 20 * bossDifficulty);
            baseStats.Add(Stat.isBoss, 1);
            baseStats.Add(Stat.isHero, 0);
            baseStats.Add(Stat.Threat, 0);
        }
        else
        {
            throw new Exception(" Invalid Boss Id given in builder, table might be wrong");
        }

        return baseStats;
    }

    private static List<ListeningEffectDefinition> ParsePassives()
    {
        //Parsing passives
        string csv = "/Assets/Data/BossPassives.csv";
        string path = Path.GetFullPath(dir + csv);
        StreamReader strReader = new StreamReader(path);

        List<ListeningEffectDefinition> baseListeningEffects = new List<ListeningEffectDefinition>();

        string fileString = strReader.ReadToEnd();
        string[] lines = fileString.Split('\n');

        int randomPassiveId = UnityEngine.Random.Range(0, lines.Length - 2);


        string[] fields = lines[randomPassiveId + 1].Split(';');
        if (fields[0].Equals(randomPassiveId.ToString()))
        {
            ListeningEffectDefinition newPassive = new ListeningEffectDefinition();

            object newExecutionTrigger = Activator.CreateInstance(Type.GetType(fields[1]));
            if (newExecutionTrigger is Trigger execTrigger)
            {
                newPassive.ExecutionTrigger = execTrigger;
                newPassive.ExecutionTrigger.Value = Int32.Parse(fields[2]);
            }

            object newEndTrigger = Activator.CreateInstance(Type.GetType(fields[3]));
            if (newExecutionTrigger is Trigger endTrigger)
            {
                newPassive.ExecutionTrigger = endTrigger;
                newPassive.ExecutionTrigger.Value = Int32.Parse(fields[4]);
            }
            //Effects parsing
            List<Effect> effects = new List<Effect>();
            if(!fields[5].Equals(""))
            {
                effects.Add(ParseEffect(Int32.Parse(fields[5])));
            }
            if (!fields[6].Equals(""))
            {
                effects.Add(ParseEffect(Int32.Parse(fields[6])));
            }
            if (!fields[7].Equals(""))
            {
                effects.Add(ParseEffect(Int32.Parse(fields[7])));
            }
            newPassive.Effects = effects;
            baseListeningEffects.Add(newPassive);

        }

        return baseListeningEffects;
    }

    private static Effect ParseEffect(int effectId)
    {
        //Parsing passives
        string csv = "/Assets/Data/BossEffects.csv";
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
                newEffect.Sources = new EffectHolderSelector();

            }
            newEffect.Conditions = new List<Condition>();
        }
        else
        {
            throw new Exception("Invalid Effect Id, table might be wrong");
        }
        
        return newEffect;
    }

    private static string ParseName()
    {
        string csv = "/Assets/Data/BossNames.csv";
        string path = Path.GetFullPath(dir + csv);
        StreamReader strReader = new StreamReader(path);

        string fileString = strReader.ReadToEnd();
        string[] lines = fileString.Split('\n');
        int randomNameId = UnityEngine.Random.Range(0, lines.Length - 1);

        return lines[randomNameId];
    }

    private static Spell ParseSpell()
    {
        string csv = "/Assets/Data/BossSpells.csv";
        string path = Path.GetFullPath(dir + csv);
        StreamReader strReader = new StreamReader(path);

        string fileString = strReader.ReadToEnd();
        string[] lines = fileString.Split('\n');
        int randomSpellId = UnityEngine.Random.Range(0, lines.Length - 2);

        Spell newSpell = new Spell();

        string[] fields = lines[randomSpellId + 1].Split(';');

        if (fields[0].Equals(randomSpellId.ToString()))
        {
            newSpell.Name = fields[1];
            newSpell.Cooldown = Int32.Parse(fields[2]);
            newSpell.Effects = new List<Effect>();
            if(!fields[3].Equals(""))
            {

                newSpell.Effects.Add(ParseEffect(Int32.Parse(fields[3])));
            }
            if (!fields[4].Equals(""))
            {

                newSpell.Effects.Add(ParseEffect(Int32.Parse(fields[4])));
            }
            if (!fields[5].Equals(""))
            {

                newSpell.Effects.Add(ParseEffect(Int32.Parse(fields[5])));
            }

        }
        else
        {
            throw new Exception("Invalid Spell Id, table might be wrong");
        }
        return newSpell;
    }
}

