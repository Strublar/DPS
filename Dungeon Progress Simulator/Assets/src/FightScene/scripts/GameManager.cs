using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static FightHandler fightHandler;
    public static GameManager gameManager;
    public GameObject bossObject;
    public GameObject[] heroObjects;
    public bool pulled;

    #region Unity Methods
    private void Awake()
    {
        GameManager.gameManager = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        //Run.Init();
       
        StartRun();
        StartNextBoss();

        
    }

    // Update is called once per frame
    void Update()
    {
        CheckAggro();
        //OPTIMIZABLE
        if(!pulled)
        {
            foreach(GameObject obj in heroObjects)
            {
                obj.GetComponent<HeroesBehaviour>().ResetCooldown();
            }
        }
    }

    #endregion

    #region Methods
    public void StartRun()
    {
        Run.run.StartNewDungeon();
        
    }

    public void StartNextBoss()
    {
        GameManager.fightHandler = new FightHandler();
        Entity boss = EntityFactory.BuildNewEntity(Run.run.CurrentDungeon.CurrentBoss.Definition);

        fightHandler.Entities.Add(boss.Id,boss);

        //Update boss 
        bossObject.GetComponent<BossBehaviour>().InitBoss(Run.run.CurrentDungeon.CurrentBoss, boss);


        int index = 0;
        foreach (Hero hero in Run.run.Team)
        {
            Entity heroEntity = EntityFactory.BuildNewEntity(hero.Definition);
            GameManager.fightHandler.Entities.Add(heroEntity.Id, heroEntity);

            //Update Hero 
            heroObjects[index].GetComponent<HeroesBehaviour>().InitHero(hero,heroEntity);
            


            index++;
        }


        
        pulled = false;

    }

    void CheckAggro()
    {
        HeroesBehaviour heroKaLaggro = null;
        int highestThreat = 0;

        foreach(GameObject hero in heroObjects)
        {
            if(hero.GetComponent<HeroesBehaviour>().heroEntity.Stats[Stat.Alive] == 1)
            {
                if (hero.GetComponent<HeroesBehaviour>().heroEntity.Stats[Stat.Threat] > highestThreat)
                {
                    highestThreat = hero.GetComponent<HeroesBehaviour>().heroEntity.Stats[Stat.Threat];
                    heroKaLaggro = hero.GetComponent<HeroesBehaviour>();
                }
                hero.GetComponent<HeroesBehaviour>().isAggro = false;
            }
            
        }
        if(heroKaLaggro != null)
        {
            heroKaLaggro.isAggro = true;
        }

    }

    
    #endregion
}
