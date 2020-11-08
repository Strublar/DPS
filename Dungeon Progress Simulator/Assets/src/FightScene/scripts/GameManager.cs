using System.Collections;
using System.Collections.Generic;
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

        StartRun();
        StartNextBoss();

        
    }

    // Update is called once per frame
    void Update()
    {


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

        Debug.Log("New Boss ready : " + fightHandler.Entities[boss.Id].Name);

        int index = 0;
        foreach (Hero hero in Run.run.Team)
        {
            Entity heroEntity = EntityFactory.BuildNewEntity(hero.Definition);
            fightHandler.Entities.Add(heroEntity.Id, heroEntity);

            //Update Hero 
            heroObjects[index].GetComponent<HeroesBehaviour>().InitHero(hero,heroEntity);
            

            Debug.Log("New Hero ready : " + fightHandler.Entities[heroEntity.Id].Name);
            index++;
        }
        pulled = false;

    }

    
    #endregion
}
