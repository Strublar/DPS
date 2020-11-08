using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class HeroesBehaviour : MonoBehaviour
{
    public string heroesName;
    public RawImage bg;
    public TextMeshProUGUI nameText;
    public Image imageClasse;
    public Role roleActuel = Role.Tank;
    public bool isDead = false;
    public MajorSpellBarBehaviour majorSpellBar;
    public RotationSpellBarBehaviour rotationSpellBar;
    public GameObject heroLifeBar;
    public Entity heroEntity;
    public Hero linkedHero;
    public enum Role
    {
        Tank,
        DPS,
        Heal
    };

    // Start is called before the first frame update
    void Start()
    {
        nameText.text = heroesName;
        colorBackground();
    }

    

    // Update is called once per frame
    void Update()
    {
        UpdateStats();
    }

    #region Control methods
    public void OnDrag()
    {

        if (Input.GetMouseButton(1) == true && Input.GetMouseButton(0) == false)
        {
            if (majorSpellBar.actualCD > 0)
            {
                ;
            }
            else
            {
                majorSpellBar.spellImage.position = Input.mousePosition;
            }
        }

        if (Input.GetMouseButton(0) == true && Input.GetMouseButton(1) == false)
        {
            if (rotationSpellBar.actualCD > 0)
            {
                ;
            }
            else
            {
                rotationSpellBar.spellImage.position = Input.mousePosition;
            }
        }
    }

    public void OnDragEnd()
    {

        if (majorSpellBar.spellRawImage.CollidingWith != null && majorSpellBar.PositionDeBase != majorSpellBar.spellImage.position)
        {
            if (majorSpellBar.spellRawImage.CollidingWith.name == "Boss" && linkedHero.SignatureSpell.ValidTarget == ValidTarget.Enemy)
            {
                Debug.Log("OUCH ! VIOLET");
                Entity target = majorSpellBar.spellRawImage.CollidingWith.GetComponent<BossBehaviour>().bossEntity;
                GameManager.fightHandler.FireEvent(new SpellCastEvent(target.Id, heroEntity.Id, linkedHero.SignatureSpell));
                majorSpellBar.actualCD = majorSpellBar.maxCD;
            }
            else
            {
                if (linkedHero.SignatureSpell.ValidTarget == ValidTarget.Ally)
                {
                    Debug.Log("Youpi :) VIOLET + " + majorSpellBar.spellRawImage.CollidingWith.name);
                    Entity target = majorSpellBar.spellRawImage.CollidingWith.GetComponent<HeroesBehaviour>().heroEntity;
                    GameManager.fightHandler.FireEvent(new SpellCastEvent(target.Id, heroEntity.Id, linkedHero.SignatureSpell));
                    majorSpellBar.actualCD = majorSpellBar.maxCD;
                }
            }

            
        }

        //Debug.Log(rotationSpellBar.spellRawImage.CollidingWith);

        if (rotationSpellBar.spellRawImage.CollidingWith != null && rotationSpellBar.PositionDeBase != rotationSpellBar.spellImage.position)
        {
            //TODO PROPRE
            if (rotationSpellBar.spellRawImage.CollidingWith.name == "Boss"
                && linkedHero.RotationSpells[0].ValidTarget == ValidTarget.Enemy)
            {
                Debug.Log("OUCH ! JAUNE");
                Entity target = rotationSpellBar.spellRawImage.CollidingWith.GetComponent<BossBehaviour>().bossEntity;
                GameManager.fightHandler.FireEvent(new SpellCastEvent(target.Id, heroEntity.Id, linkedHero.RotationSpells[0]));
                rotationSpellBar.actualCD = rotationSpellBar.maxCD;
            }
            else
            {
                if(linkedHero.RotationSpells[0].ValidTarget == ValidTarget.Ally)
                {
                    Debug.Log("Youpi :) JAUNE");
                    Entity target = rotationSpellBar.spellRawImage.CollidingWith.GetComponent<HeroesBehaviour>().heroEntity;
                    GameManager.fightHandler.FireEvent(new SpellCastEvent(target.Id, heroEntity.Id, linkedHero.RotationSpells[0]));
                    rotationSpellBar.actualCD = rotationSpellBar.maxCD;
                }
            }

            
        }

        majorSpellBar.spellImage.position = majorSpellBar.PositionDeBase;
        rotationSpellBar.spellImage.position = rotationSpellBar.PositionDeBase;
        //Debug.Log("Je suis laché");
    }
    #endregion

    #region Methods
    private void colorBackground()
    {
        if (isDead)
        {
            bg.color = Color.grey;
        }
        else if (roleActuel == Role.Tank)
        {
            bg.color = Color.cyan;
        }
        else if (roleActuel == Role.DPS)
        {
            bg.color = Color.magenta;
        }
        else if (roleActuel == Role.Heal)
        {
            bg.color = Color.green;
        }
    }

    public void InitHero(Hero hero, Entity entity)
    {
        this.heroEntity = entity;
        this.heroesName = entity.Name;
        this.linkedHero = hero;
        nameText.text = this.heroesName;
        heroLifeBar.GetComponent<LifeBarBehaviour>().maxHp = heroEntity.EntityDefinition.BaseStats[Stat.Hp];
        heroLifeBar.GetComponent<LifeBarBehaviour>().actualHp = heroEntity.Stats[Stat.Hp];
        heroLifeBar.GetComponent<LifeBarBehaviour>().InitBar();

        this.rotationSpellBar.maxCD = hero.RotationSpells[0].Cooldown;
        this.majorSpellBar.maxCD = hero.SignatureSpell.Cooldown;
    }

    public void UpdateStats()
    {
        this.heroLifeBar.GetComponent<LifeBarBehaviour>().actualHp = this.heroEntity.Stats[Stat.Hp];
    }
    #endregion
}
