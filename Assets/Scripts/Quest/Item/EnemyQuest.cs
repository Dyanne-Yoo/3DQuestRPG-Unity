using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Obj_Info))]
public class EnemyQuest : MonoBehaviour
{
    private Obj_Info enemyInfo;

    private void Start()
    {
         enemyInfo = GetComponent<Obj_Info>();
    }

    //enemy 잡았을 때 호출
    public void CheckClearQuest()
    {
        List<QuestInfo> clearQuests = new List<QuestInfo>();
        foreach (var item in QuestManager.instance.acceptedQuests)
        {
            if (item.targetName == enemyInfo.obj_Name)
            {
                item.Progress((success, quest)=> 
                {
                    if (success)
                    {
                        FindObjectOfType<Manager_Inven>().gold += (int)quest.reward.rewardValue;
                        clearQuests.Add(item);
                        Debug.Log("clear quest");
                    }
                    else
                    {
                        Debug.Log("remain : " + quest.currentCount);
                    }
                });
            }
        }

        foreach (var item in clearQuests)
        {
            QuestManager.instance.ClearQuest(item);
        }
    }
}
