using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
* -----FightHandler-----
* Fire the Events and process all the actions of the Events
* Manage what happens in the fight
*/
public class FightHandler
{
    #region Attributes
    private Dictionary<int, Entity> entities;
    private List<Rule> rules;
    private List<ListeningEffect> listeningEffects;



    #endregion

    #region Getters & Setters
    public Dictionary<int, Entity> Entities { get => entities; set => entities = value; }
    public List<Rule> Rules { get => rules; set => rules = value; }
    public List<ListeningEffect> ListeningEffects { get => listeningEffects; set => listeningEffects = value; }
    #endregion

    #region Constructor
    public FightHandler()
    {
        
        //Initialisation
        entities = new Dictionary<int, Entity>();
        rules = new List<Rule>() {
            new EntityStatChangedRule(),
            new SpellCastRule(), 
            new DeathRule(), 
            new EndFightRule(),
            new OverHealingRule()
        };
        listeningEffects = new List<ListeningEffect>();

        
    }
    #endregion

    #region Methods
    public void FireEvent(Event newEvent)
    {
        Debug.Log("New Event Fired : "+newEvent);
        StoreEvent(newEvent);
        ApplyEventTrigger(newEvent);
    }

    public void StoreEvent(Event newEvent)
    {
        entities.TryGetValue(newEvent.TargetId, out Entity targetEntity);
        targetEntity.Events.Add(newEvent);
    }

    public void ApplyEventTrigger(Event newEvent)
    {
        TriggerRuleExecution(newEvent);
        TriggerListeningEffectsExecution(newEvent);
        TriggerRuleAfterExecution(newEvent);
        TriggerListeningEffectsEnd(newEvent);
    }

    public void TriggerRuleExecution(Event newEvent)
    {
        foreach (Rule rule in Rules)
        {
            rule.OnEvent(newEvent, this);
        }
    }

    public void TriggerRuleAfterExecution(Event newEvent)
    {
        foreach (Rule rule in Rules)
        {
            rule.OnAfterEvent(newEvent, this);
        }
    }

    public void TriggerListeningEffectsExecution(Event newEvent)
    {
        foreach (ListeningEffect listeningEffect in listeningEffects)
        {
            if (listeningEffect.ShouldTriggerExecution(newEvent))
            {
                Debug.Log("Listening Effect Executed");
                Context context = new Context(listeningEffect.HolderId, newEvent.SourceId);
                listeningEffect.Execute(newEvent, context, this);
            }
        }
    }

    public void TriggerListeningEffectsEnd(Event newEvent)
    {
        List<ListeningEffect> purgingList = new List<ListeningEffect>();
        foreach (ListeningEffect listeningEffect in listeningEffects)
        {
            if (listeningEffect.ShouldTriggerEnd(newEvent))
            {
                purgingList.Add(listeningEffect);
            }
        }
        foreach (ListeningEffect listeningEffect in purgingList)
        {
            listeningEffects.Remove(listeningEffect);
        }
    }
    #endregion
}
