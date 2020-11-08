using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BossBehaviour : MonoBehaviour
{

    public Boss bossUnit;
    public Entity bossEntity;
    public string bossName;
    public TextMeshProUGUI nameText;
    public GameObject bossLifeBar;
    public GameObject majorSpellBar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateStats();
        CastSpells();
    }

    #region Methods
    public void InitBoss(Boss boss, Entity entity)
    {
        this.bossEntity = entity;
        this.bossName = entity.Name;
        this.bossUnit = boss;
        nameText.text = this.bossName;

        bossLifeBar.GetComponent<LifeBarBehaviour>().maxHp = entity.EntityDefinition.BaseStats[Stat.Hp];
        bossLifeBar.GetComponent<LifeBarBehaviour>().actualHp = entity.Stats[Stat.Hp];
        bossLifeBar.GetComponent<LifeBarBehaviour>().InitBar();

        Debug.Log("Base CD : " + boss.Spells[0].Cooldown);
        this.majorSpellBar.GetComponent<MajorSpellBarBehaviour>().maxCD = boss.Spells[0].Cooldown;
        this.majorSpellBar.GetComponent<MajorSpellBarBehaviour>().actualCD = boss.Spells[0].Cooldown;
        this.majorSpellBar.GetComponent<MajorSpellBarBehaviour>().updateCDImage();

    }

    public void UpdateStats()
    {
        bossLifeBar.GetComponent<LifeBarBehaviour>().actualHp = bossEntity.Stats[Stat.Hp];
    }

    public void CastSpells()
    {
        //Todo better for more spells
        if(majorSpellBar.GetComponent<MajorSpellBarBehaviour>().actualCD <= 0)
        {

            GameManager.fightHandler.FireEvent(new SpellCastEvent(bossEntity.Id, bossEntity.Id, bossUnit.Spells[0]));
            majorSpellBar.GetComponent<MajorSpellBarBehaviour>().actualCD = 
                majorSpellBar.GetComponent<MajorSpellBarBehaviour>().maxCD;
        }
    }
    #endregion
}
