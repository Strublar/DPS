using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityFactory
{
    public static Entity BuildNewEntity(EntityDefinition definition)
    {
        Entity returnEntity = new Entity();
        returnEntity.Name = definition.Name;
        returnEntity.Stats = new Dictionary<Stat,int>(definition.BaseStats);
        returnEntity.EntityDefinition = definition;
        return returnEntity;            
    }
}
