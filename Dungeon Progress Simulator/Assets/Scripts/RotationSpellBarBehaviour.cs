using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotationSpellBarBehaviour : MonoBehaviour
{
    public Transform cdImage;
    public Transform spellImage;
    public float maxCD = 15;
    public float actualCD = 0;
    public SpellIconBehaviour spellRawImage;
    private Vector3 positionDeBase;


    public Vector3 PositionDeBase { get => positionDeBase; set => positionDeBase = value; }

    // Start is called before the first frame update
    void Start()
    {
        positionDeBase = spellImage.position;
        updateCDImage();
    }

    // Update is called once per frame
    void Update()
    {
        if(actualCD > 0)
        {
            actualCD -= Time.deltaTime;
            updateCDImage();
        }
        if(actualCD <= 0)
        {
            actualCD = 0;
            updateCDImage();
        }
    }
    void updateCDImage()
    {
        cdImage.localScale = new Vector3(1.0f, (float)actualCD/(float)maxCD, 1.0f);
    }

}
