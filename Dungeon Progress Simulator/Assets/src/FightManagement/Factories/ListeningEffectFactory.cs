using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListeningEffectFactory
{
    public static ListeningEffect BuildNewListeningEffect(int holderId,ListeningEffectDefinition definition)
    {

        return new ListeningEffect(holderId,definition.ExecutionTrigger,definition.EndTrigger,definition.Effects);
    }
}
