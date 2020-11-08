using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Run
{
    public static Run run;//Singleton
    #region Attributes
    private int dungeonDone;
    private Dungeon currentDungeon;
    private List<Hero> team;

    #endregion

    #region Getters & Setters
    public int DungeonDone { get => dungeonDone; set => dungeonDone = value; }
    public Dungeon CurrentDungeon { get => currentDungeon; set => currentDungeon = value; }
    public List<Hero> Team { get => team; set => team = value; }
    #endregion

    #region Constructor
    public Run()
    {
        dungeonDone = -1;
        
    }
    #endregion

    #region Methods

    public void StartNewDungeon()
    {
        dungeonDone++;
        Debug.Log("Starting a new Dungeon");
        currentDungeon = DungeonFactory.BuildNewDungeon(dungeonDone);
    }

    #endregion

    #region Static Methods
    public static void Init()
    {
        Debug.Log("Starting a new Run !");
        Run.run = new Run();
        
        Run.run.Team = new List<Hero>
        {
            HeroFactory.BuildNewHero(HeroClass.Warrior),
            HeroFactory.BuildNewHero(HeroClass.Paladin),
            HeroFactory.BuildNewHero(HeroClass.Rogue),
            HeroFactory.BuildNewHero(HeroClass.Hunter),
            HeroFactory.BuildNewHero(HeroClass.Barbarian),
            HeroFactory.BuildNewHero(HeroClass.Mage),
            HeroFactory.BuildNewHero(HeroClass.Warlock),
            HeroFactory.BuildNewHero(HeroClass.Priest),
            HeroFactory.BuildNewHero(HeroClass.Druid),
            HeroFactory.BuildNewHero(HeroClass.Shaman)
        };

        Run.run.team[0].Definition.Name = "Stephane";
        Run.run.team[1].Definition.Name = "Henry";
        Run.run.team[2].Definition.Name = "Christiane";
        Run.run.team[3].Definition.Name = "Anguérant";
        Run.run.team[4].Definition.Name = "Soizic";
        Run.run.team[5].Definition.Name = "Guénolé";
        Run.run.team[6].Definition.Name = "GROTON";
        Run.run.team[7].Definition.Name = "Prius";
        Run.run.team[8].Definition.Name = "Michel";
        Run.run.team[9].Definition.Name = "Truc";

    }

    public void BossVictory()
    {
        Run.run.CurrentDungeon.Nextboss(dungeonDone);
        GameManager.gameManager.StartNextBoss();
        GameManager.gameManager.pulled = false;
       
    }

    public void BossDefeat()
    {
        SceneManager.LoadScene("MenuScene", LoadSceneMode.Single);
    }
    #endregion
}
