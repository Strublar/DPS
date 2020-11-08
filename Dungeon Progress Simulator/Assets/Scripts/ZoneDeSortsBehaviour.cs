using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;

public class ZoneDeSortsBehaviour : MonoBehaviour
{
    private MajorSpellBarBehaviour[] listeSorts;
    public MajorSpellBarBehaviour prefabSpellBar;
    public Transform zoneDeSort;
    private RectTransform background;
    public float ratio = 0.05f;

    public MajorSpellBarBehaviour[] ListeSorts { get => listeSorts; set => listeSorts = value; }
    public RectTransform Background { get => background; set => background = value; }

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2((int)(background.sizeDelta.x - (background.sizeDelta.x * ratio)), gameObject.GetComponent<RectTransform>().sizeDelta.y);
    }

    // Update is called once per frame
    void Update()
    {
        
    }   

    public void AutoDestruction()
    {
        Destroy(this.gameObject);
    }

    public void agencerSorts(List<Spell> sorts)
    {
        listeSorts = new MajorSpellBarBehaviour[sorts.Count];
        int counter = 0;

        foreach (Spell sort in sorts)
        {
            MajorSpellBarBehaviour spellBar = Instantiate(prefabSpellBar, zoneDeSort);
            listeSorts[counter] = spellBar;
            spellBar.maxCD = sort.Cooldown;
            spellBar.actualCD = spellBar.maxCD;
            spellBar.name = sort.Name;
            counter += 1;
        }

        counter = 1;
        float unit = gameObject.GetComponent<RectTransform>().sizeDelta.x / (listeSorts.Length + 1);
        foreach (MajorSpellBarBehaviour sort in listeSorts)
        {
            sort.GetComponent<RectTransform>().anchoredPosition = new Vector2((unit * counter) - (gameObject.GetComponent<RectTransform>().sizeDelta.x / 2), 0);
            counter += 1;
        }
    }
}
