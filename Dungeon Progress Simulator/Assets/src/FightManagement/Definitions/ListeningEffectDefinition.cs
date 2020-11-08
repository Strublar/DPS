using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListeningEffectDefinition
{
    #region Attributes
    private int id;
    private Trigger executionTrigger;
    private Trigger endTrigger;
    private List<Effect> effects;


    #endregion

    #region Getters & Setters
    public Trigger ExecutionTrigger { get => executionTrigger; set => executionTrigger = value; }
    public Trigger EndTrigger { get => endTrigger; set => endTrigger = value; }
    public List<Effect> Effects { get => effects; set => effects = value; }
    public int Id { get => id; set => id = value; }
    #endregion
}
