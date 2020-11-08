using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListeningEffect
{
    //Factory pool control and ID attribution
    public static int nextId = 0;

    #region Attributes
    private int id;
    private int holderId;
    private Trigger executionTrigger;
    private Trigger endTrigger;
    private List<Effect> effects;



    #endregion

    #region Getters & Setters

    public int Id { get => id; set => id = value; }
    public int HolderId { get => holderId; set => holderId = value; }
    public Trigger ExecutionTrigger { get => executionTrigger; set => executionTrigger = value; }
    public Trigger EndTrigger { get => endTrigger; set => endTrigger = value; }
    public List<Effect> Effects { get => effects; set => effects = value; }

    #endregion

    #region Constructor


    public ListeningEffect(int holderId, Trigger executionTrigger, Trigger endTrigger, List<Effect> effects)
    {
        this.id = ListeningEffect.GetNextId();
        this.holderId = holderId;
        this.executionTrigger = executionTrigger;
        this.endTrigger = endTrigger;
        this.effects = effects;
        executionTrigger.ListeningEffectId = this.id;
        endTrigger.ListeningEffectId = this.id;
    }



    #endregion

    #region Static Methods
    public static int GetNextId()
    {
        return ++ListeningEffect.nextId;
    }
    #endregion

    #region Methods

    public bool ShouldTriggerExecution(Event newEvent)
    {
        if (executionTrigger.ShouldTrigger(newEvent))
        {
            return true;
        }
        return false;

    }

    public bool ShouldTriggerEnd(Event newEvent)
    {
        if (endTrigger.ShouldTrigger(newEvent))
        {
            return true;
        }
        return false;

    }

    public void Execute(Event newEvent, Context context, FightHandler fightHandler)
    {
        foreach (Effect effect in Effects)
        {
            effect.Execute(context, fightHandler);
        }
    }
    #endregion
}
