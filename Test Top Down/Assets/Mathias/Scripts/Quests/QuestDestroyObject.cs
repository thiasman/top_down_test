using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestDestroyObject : MonoBehaviour
{
    private string QuestName = "Destroy the slime spawner";
    public GameObject myPrefab;
    // Start is called before the first frame update
    void Start()
    {
    }

    void OnDestroy()
    {
        Instantiate(myPrefab, transform.position, Quaternion.identity);
        print("Script was destroyed");
        QuestManager.SetQuestStatus(QuestName, Quest.QUESTSTATUS.COMPLETE);
    }

}
