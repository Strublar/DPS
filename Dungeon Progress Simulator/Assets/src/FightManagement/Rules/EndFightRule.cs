using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class EndFightRule : Rule
{
    #region Methods
    public override void OnEvent(Event newEvent, FightHandler fightHandler)
    {

        if (newEvent is EntityDiesEvent entityDiesEvent)
        {
            if(fightHandler.Entities[entityDiesEvent.TargetId].Stats[Stat.isBoss]==1)
            {
                Debug.Log("End Fight Rule activated");
                Debug.Log("Victory to the player");
                Run.run.BossVictory();
                //TODO Fin du match
            }
            else if (fightHandler.Entities[entityDiesEvent.TargetId].Stats[Stat.isHero] == 1)
            {
                int heroAliveCount = 0;
                foreach(KeyValuePair<int,Entity> entry in fightHandler.Entities)
                {
                    Entity entity = entry.Value;
                    if(entity.Stats[Stat.isHero] == 1 && entity.Stats[Stat.Alive] == 1)
                    {
                        heroAliveCount++;
                    }
                    
                }
                if (heroAliveCount == 0)
                {
                    Debug.Log("End Fight Rule activated");
                    Debug.Log("Defeat");
                    Run.run.BossDefeat();
                    //TODO end of run
                }
            }

        }
    }

    #endregion

}

