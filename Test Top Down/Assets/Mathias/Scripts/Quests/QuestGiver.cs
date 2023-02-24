using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuestGiver : MonoBehaviour
{
    public string QuestName = string.Empty;
    public Text Captions = null;
    public string[] CaptionText;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        Quest.QUESTSTATUS Status = QuestManager.GetQuestStatus(QuestName);
        Captions.text = CaptionText[(int)Status];
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Quest.QUESTSTATUS Status = QuestManager.GetQuestStatus(QuestName);
        if (Status == Quest.QUESTSTATUS.UNASSIGNED)
        {
            QuestManager.SetQuestStatus(QuestName, Quest.QUESTSTATUS.ASSIGNED);
        }
        else if (Status == Quest.QUESTSTATUS.COMPLETE)
        {
            SceneManager.LoadScene(5);
        }
    }
}