using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCQuest : MonoBehaviour
{
    public List<QuestInfo> quests = new List<QuestInfo>();

    // Start is called before the first frame update
    void Start()
    {
        InitQuests();
    }

    private void OnMouseDown()
    {
        OnClick();
    }

    public void OnClick()
    {
        QuestManager.instance.OpenQuestPanel(GiveQuest());
    }

    private void InitQuests()
    {
        string targetName = "Wood Mon";
        QuestInfo.Reward reward = new QuestInfo.Reward("15골드", 15);
        quests.Add(new QuestInfo(1, "Collector", "출몰지역에 있는 몬스터 한 마리를 잡아주세요", reward, targetName, 1));
    }

    public QuestInfo GiveQuest()
    {
        QuestInfo quest = quests[Random.Range(0, quests.Count)];

        return quest;
    }
}
