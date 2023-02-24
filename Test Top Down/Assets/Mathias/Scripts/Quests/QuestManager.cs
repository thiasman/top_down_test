using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
	private static QuestManager ThisInstance = null;

    public Quest[] Quests;
    public static Quest.QUESTSTATUS GetQuestStatus(string QuestName)
    {
        foreach (Quest Q in ThisInstance.Quests)
        {
            if (Q.QuestName.Equals(QuestName))
            {
                return Q.Status;
            }
        }
        return Quest.QUESTSTATUS.UNASSIGNED;
    }
    public static void SetQuestStatus(string QuestName, Quest.QUESTSTATUS NewStatus)
    {
        foreach (Quest Q in ThisInstance.Quests)
        {
            if (Q.QuestName.Equals(QuestName))
            {
                Q.Status = NewStatus; return;
            }
        }
    }

    public static void Reset()
    {
        foreach (Quest Q in ThisInstance.Quests)
        {
            Q.Status = Quest.QUESTSTATUS.UNASSIGNED;
        }
    }

    void Awake()
	{
		/* Ensures that the object that QuestManager is attached to persists between scenes, and it makes sure that there is only ever one instance of the script in a scene.
		 * Calling DontDestroyOnLoad tells Unity to keep this object alive when transitioning scenes. By calling this function, we know that when we transition to a new
		 * level in our game, we will still be able to access the quest manager.
		*/ 
		if (ThisInstance == null)
		{
			DontDestroyOnLoad(this);
			ThisInstance = this;
		}
		else
		{
			DestroyImmediate(gameObject);
			// If ThisInstance has already been assigned to, then we know there is already an instance of QuestManager in the scene so we can safely destroy this copy,
			// preventing more than one from existing in a level.
		}
	}
}
