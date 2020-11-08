using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RunInfoBehaviour : MonoBehaviour
{

    public TextMeshProUGUI invoText;
    // Update is called once per frame
    void Update()
    {
        invoText.text = "Dungeon : "+(Run.run.DungeonDone+1)+"\nBoss "+(Run.run.CurrentDungeon.BossesDone+1)+"/3";
    }
}
