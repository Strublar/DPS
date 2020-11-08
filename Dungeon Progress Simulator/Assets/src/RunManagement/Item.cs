using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    #region Attributes
    private string name;
    private List<Passive> passives;
    #endregion

    #region Getters & Setters
    public string Name { get => name; set => name = value; }
    public List<Passive> Passives { get => passives; set => passives = value; }
    #endregion
}
