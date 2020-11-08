using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity
{
    public static int nextId = 0;
    #region Attributes
    private int id;
    private string name;
    private Dictionary<Stat, int> stats;
    private List<Event> events;
    private EntityDefinition entityDefinition;

    

    #endregion

    #region Getters & Setters
    public int Id { get => id; set => id = value; }
    public Dictionary<Stat, int> Stats { get => stats; set => stats = value; }
    public List<Event> Events { get => events; set => events = value; }
    public EntityDefinition EntityDefinition { get => entityDefinition; set => entityDefinition = value; }
    public string Name { get => name; set => name = value; }
    #endregion

    #region Constructor

    public Entity()
    {
        this.id = Entity.GetNextId();
        stats = new Dictionary<Stat, int>();
        events = new List<Event>();
    }

    
    #endregion

    #region Static Methods
    public static int GetNextId()
    {
        return ++Entity.nextId;
    }
    #endregion
}
