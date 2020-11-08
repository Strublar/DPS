using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event
{
    public static int nextEventId = 0;

    #region Attributes
    protected int id;
    protected int targetId;
    protected int sourceId;



    #endregion

    #region Getters & Setters
    public int Id { get => id; set => id = value; }
    public int TargetId { get => targetId; set => targetId = value; }
    public int SourceId { get => sourceId; set => sourceId = value; }
    #endregion

    #region Constructor
    public Event(int targetId, int sourceId)
    {
        this.id = Event.GetNextId();
        this.targetId = targetId;
        this.sourceId = sourceId;
    }
    #endregion

    #region Static Methods
    public static int GetNextId()
    {
        return ++Event.nextEventId;
    }
    #endregion
}
