using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dungeon
{
    #region Attributes
    private int bossesDone;
    private Boss currentBoss;

    
    #endregion

    #region Getters & Setters
    public int BossesDone { get => bossesDone; set => bossesDone = value; }
    public Boss CurrentBoss { get => currentBoss; set => currentBoss = value; }
    #endregion

    #region Constructor
    public Dungeon()
    {
        bossesDone = 0;
        GenerateNewBoss();
    }
    #endregion

    #region Methods
    public void GenerateNewBoss()
    {
        Debug.Log("Preparing for a new Boss");
        currentBoss = BossFactory.BuildNewBoss();
    }

    public void Nextboss()
    {
        bossesDone++;
        if(bossesDone >= 3)
        {
            Debug.Log("Dungeon Done");
            Run.run.StartNewDungeon();
        }
        else
        {
            GenerateNewBoss();
            
        }
    }
    #endregion
}
