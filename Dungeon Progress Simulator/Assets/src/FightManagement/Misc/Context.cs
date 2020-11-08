using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Context
{
    #region Attributes
    private int holderId;
    private int sourceId;

    #endregion

    #region Getters & Setters
    public int HolderId { get => holderId; set => holderId = value; }
    public int SourceId { get => sourceId; set => sourceId = value; }
    #endregion

    #region Constructor
    public Context(int holderId, int sourceId)
    {
        this.holderId = holderId;
        this.sourceId = sourceId;
    }

    #endregion
}
