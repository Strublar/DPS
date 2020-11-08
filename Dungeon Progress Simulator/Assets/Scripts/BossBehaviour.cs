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
    public ZoneDeSortsBehaviour zoneDeSort;
    public Transform transformBoss;
    public RectTransform backgroundTransform;

    private ZoneDeSortsBehaviour actualZoneDeSort;

    //public GameObject majorSpellBar;

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
    public void OnPointerEnter()
    {
        foreach (BossSpellBarBehaviour spell in actualZoneDeSort.ListeSorts)
        {
            //Ceci est une putain de rustine ([0])
            spell.infobulle.InitTooltip(bossUnit.Spells[0].Name, spell.maxCD, bossUnit.Spells[0].GetUpdateDescription(bossEntity));
        }
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

        if (actualZoneDeSort != null)
        {
            actualZoneDeSort.AutoDestruction();
        }

        actualZoneDeSort = Instantiate<ZoneDeSortsBehaviour>(zoneDeSort, transformBoss);
        actualZoneDeSort.Background = backgroundTransform;
        actualZoneDeSort.agencerSorts(boss.Spells);
    }

    public void UpdateStats()
    {
        bossLifeBar.GetComponent<LifeBarBehaviour>().actualHp = bossEntity.Stats[Stat.Hp];
    }

    public void CastSpells()
    {
        //C'est la rurururusttiiiiiiine
        int index = 0;
        foreach(BossSpellBarBehaviour spell in actualZoneDeSort.ListeSorts){
            if (spell.actualCD <= 0)
            {

                GameManager.fightHandler.FireEvent(new SpellCastEvent(bossEntity.Id, bossEntity.Id, bossUnit.Spells[index]));
                spell.actualCD = spell.maxCD;
            }
            index++;
        }
        
    }
    #endregion
}
