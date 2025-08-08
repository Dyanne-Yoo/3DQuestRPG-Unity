using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class QuestInfo
{
    public int id;
    public string npcName;
    public string context;
    public Reward reward;
    public string targetName;
    public int targetCount;
    public int currentCount;
    public delegate void QuestClearCallback(bool success, QuestInfo quest);

    public QuestInfo(int id, string npcName, string context, Reward reward, string targetName, int targetCount)
    {
        this.id = id;
        this.npcName = npcName;
        this.context = context;
        this.reward = reward;
        this.targetName = targetName;
        this.targetCount = targetCount;
        this.currentCount = 0;
    }

    public void ClearQuest(QuestClearCallback callback)
    {
        callback(true, null);
    }

    public bool CheckClear()
    {
        if (currentCount < targetCount)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public int RemainCount()
    {
        return -1;
    }

    public void Progress(QuestClearCallback callback = null, int value = 1)
    {
        currentCount += value;
        if (CheckClear())
        {
            callback(true, this);
        }
        else
        {
            callback(false, this);
        }
    }

    public override string ToString()
    {
        string value = "";
        value += $"Quest\n";
        value += $"npcName : {npcName}\n";
        value += $"context : {context}\n";
        value += $"reward : {reward}\n";
        value += $"targetName : {targetName}\n";
        value += $"targetCount : {targetCount}\n";
        return value;
    }

    public class Reward
    {
        public string rewardText;
        public float rewardValue;

        public Reward(string rewardText, float rewardValue)
        {
            this.rewardText = rewardText;
            this.rewardValue = rewardValue;
        }

        public override string ToString()
        {
            string value = "";
            value += $"Reward\n";
            value += $"rewardText : {rewardText}\n";
            value += $"rewardValue : {rewardValue}\n";
            return value;
        }
    }
}
