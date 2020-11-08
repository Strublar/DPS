using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossSpellBarBehaviour : MonoBehaviour
{
    public Transform cdImage;
    public Transform spellImage;
    public float maxCD = 15;
    public float actualCD = 0;
    public SpellIconBehaviour spellRawImage;
    private Vector3 positionDeBase;
    public MouseOverSpellInfoBehaviour infobulle;
    private bool mouseOver = false;
    private float timerMouseOver = 0.7f;
    public Vector3 PositionDeBase { get => positionDeBase; set => positionDeBase = value; }

    // Start is called before the first frame update
    void Start()
    {
        positionDeBase = spellImage.position;
        updateCDImage();
        infobulle.gameObject.SetActive(mouseOver);
    }

    // Update is called once per frame
    void Update()
    {
        if (actualCD > 0 && GameManager.gameManager.pulled)
        {
            actualCD -= Time.deltaTime;
            updateCDImage();
        }
        if (actualCD <= 0)
        {
            actualCD = 0;
            updateCDImage();
        }
        if (mouseOver && timerMouseOver > 0 && !Input.GetMouseButtonDown(0) && !Input.GetMouseButtonDown(1))
        {
            timerMouseOver -= Time.deltaTime;
        }
        if (timerMouseOver <= 0)
        {
            timerMouseOver = 0;
            infobulle.gameObject.SetActive(mouseOver);
        }
    }

    public void updateCDImage()
    {
        cdImage.localScale = new Vector3(1.0f, (float)actualCD / (float)maxCD, 1.0f);
    }
    public void OnPointerEnter()
    {
        mouseOver = true;
    }
    public void OnPointerExit()
    {
        mouseOver = false;
        timerMouseOver = 1.0f;
        infobulle.gameObject.SetActive(mouseOver);
    }

}