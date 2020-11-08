using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LifeBarBehaviour : MonoBehaviour
{

    public int actualHp;
    public int maxHp;
    public Transform healthBar;
    public TextMeshProUGUI healthMaxText;
    public TextMeshProUGUI currentHealthText;

    // Start is called before the first frame update
    void Start()
    {
        healthMaxText.text = maxHp.ToString();
        currentHealthText.text = actualHp.ToString();
        UpdateSizeHealthBar();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSizeHealthBar();
    }

    void UpdateSizeHealthBar()
    {
        healthBar.localScale = new Vector3((float)actualHp / (float)maxHp, 1.0f, 1.0f);
        
        currentHealthText.text = actualHp.ToString();
        currentHealthText.text = actualHp.ToString();

    }

    public void InitBar()
    {
        healthMaxText.text = maxHp.ToString();
        currentHealthText.text = actualHp.ToString();
    }
}
