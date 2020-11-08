using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MouseOverSpellInfoBehaviour : MonoBehaviour
{

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI cdText;
    public TextMeshProUGUI descriptionText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void InitTooltip(string name, float cd, string description)
    {
        nameText.text = name;
        cdText.text = cd.ToString() + " s";
        descriptionText.text = description;
    }
}
