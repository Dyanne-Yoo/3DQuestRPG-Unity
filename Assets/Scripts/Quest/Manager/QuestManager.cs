using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    public static QuestManager instance;

    public GameObject questPanel;
    public Text npcName;
    public Text textContext;
    public Text rewardContext;
    public Button buttonQuestAccept;
    public Button buttonQuestDeny;

    public List<QuestInfo> acceptedQuests = new List<QuestInfo>();

    public UnityEvent clearEvent;
    public UnityEvent aleadyAcceptedEvent;
    public UnityEvent openQuestEvent;

    public UnityEvent denyEvent;
    public UnityEvent acceptEvent;

    private void Awake()
    {
        if (instance != this)
        {
            instance = this;
        }
    }

    public void ClearQuest(QuestInfo quest)
    {
        acceptedQuests.Remove(quest);
        clearEvent?.Invoke();
    }

    public void OpenQuestPanel(QuestInfo quest)
    {
        if(quest == null)
        {
            Debug.Log("OpenQuestPanel : quest is null");
            return;
        }

        if (CheckAleadyAcceptedQuest(quest))
        {
            Debug.Log("이미 받은 퀘스트");
            aleadyAcceptedEvent?.Invoke();
            return;
        }

        openQuestEvent?.Invoke();

        InitButtonAction(quest);

        SetQuestInfo(quest);

        SetQuestPanel(true);
    }

    private bool CheckAleadyAcceptedQuest(QuestInfo quest)
    {
        foreach (var item in acceptedQuests)
        {
            if(quest.id == item.id)
            {
                return true;
            }
        }
        return false;
    }



    #region Debug

    public void ViewAcceptedQuests()
    {
        foreach (var item in acceptedQuests)
        {
            Debug.Log(item);
        }
    }

    #endregion

    #region UI

    //퀘스트 팝업에 퀘스트 정보 세팅
    private void SetQuestInfo(QuestInfo quest)
    {
        npcName.text = quest.npcName;
        textContext.text = quest.context;
        rewardContext.text = quest.reward.rewardText;
    }

    //퀘스트 수락, 거절 이벤트 버튼에 세팅(Button 컴포넌트에 있는 이벤트는 무시됨)
    private void InitButtonAction(QuestInfo quest)
    {
        buttonQuestAccept.onClick.RemoveAllListeners();

        buttonQuestDeny.onClick.RemoveAllListeners();

        buttonQuestAccept.onClick.AddListener(() => 
        { 
            AcceptQuest(quest); 
        });

        buttonQuestDeny.onClick.AddListener(() => { DenyQuest(); });
    }

    //퀘스트 수락 이벤트
    private void AcceptQuest(QuestInfo quest)
    {
        acceptedQuests.Add(quest);

        acceptEvent?.Invoke();
    }

    //퀘스트 거절 이벤트
    private void DenyQuest()
    {
        denyEvent?.Invoke();
    }

    //퀘스트 팝업 온오프
    public void SetQuestPanel(bool value)
    {
        questPanel.SetActive(value);
    }

    #endregion


    
}
