using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    public enum QUESTSTATUS { UNASSIGNED, ASSIGNED, COMPLETE };
    public QUESTSTATUS Status = QUESTSTATUS.UNASSIGNED;
    public string QuestName = string.Empty;
}