using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class OtherWorldEncounterPhase : MonoBehaviour
{
    public PlayerTurnPassBB playerTurnBB;

    public Image characterImg;
    public Button escapeBtn;
    public Button fallInTimeAndSpaceBtn;
    public Button nextPlayerBtn;
    public Button delayBtn;

    public Dictionary<int, int> dOtherWorldPlayers;
    Queue<int> qOtherWorldPlayers;

    //int nowPlayer;

    public void Init()
    {
        dOtherWorldPlayers = new Dictionary<int, int>();
        qOtherWorldPlayers = new Queue<int>();
    }

    public void OnUpdate()
    {
        //AddDictionaryKeyToList();

        NextPlayer();

        playerTurnBB.OnUpdate(UI_General.Ins.ui_RulePhase.nowPlayerID);
        nextPlayerBtn.interactable = true;
        Debug.Log("Other World Player Count : " + dOtherWorldPlayers.Count);
    }

    public void CheckOtherWorldCount()
    {
        AddDictionaryKeyToList();
    }

    public void OnClickOtherWorldEncounterCard()
    {
        RuleMaster.Ins.OtherWorldEncounterCardDraw(UI_General.Ins.ui_RulePhase.nowPlayerID);
        UI_General.Ins.OpenCardInfo(UI_General.eCardInfo.OtherWorld);
        UI_General.Ins.ui_CardInfo.OtherWorldSetting();
        this.gameObject.SetActive(false);
    }

    public void OnClickNextPlayerBtn()
    {
        dOtherWorldPlayers[UI_General.Ins.ui_RulePhase.nowPlayerID] -= 1;
        Debug.Log(UI_General.Ins.ui_RulePhase.nowPlayerID.GetCharacterTB().strName_Kor + "count : " + dOtherWorldPlayers[UI_General.Ins.ui_RulePhase.nowPlayerID]);
        CheckPlayerEscape();
        if (!CheckQueueEmpty())
        {
            NextPlayer();
            playerTurnBB.OnUpdate(UI_General.Ins.ui_RulePhase.nowPlayerID);
        }
        else
        {
            nextPlayerBtn.interactable = false;
            Debug.Log("All Players Done");
        }
    }

    //시간과 공간상에서 해맬경우는, 우선 0의 기회값을 가지고, onupdate에서 사라지게 만든다.(이래야 아컴조우때 제외되고, 다른세계 조우때에도 제외됨)
    public void OnClickLostInTimeAndSpaceBtn()
    {
        dOtherWorldPlayers[UI_General.Ins.ui_RulePhase.nowPlayerID] -= 2;
        if (!CheckQueueEmpty())
        {
            NextPlayer();
            playerTurnBB.OnUpdate(UI_General.Ins.ui_RulePhase.nowPlayerID);
        }
        else
        {
            nextPlayerBtn.interactable = false;
            Debug.Log("All Players Done");
        }
    }

    public void OnClickEscapeBtn()
    {
        dOtherWorldPlayers.Remove(UI_General.Ins.ui_RulePhase.nowPlayerID);
        if (!CheckQueueEmpty())
        {
            NextPlayer();
            playerTurnBB.OnUpdate(UI_General.Ins.ui_RulePhase.nowPlayerID);
        }
        else
        {
            nextPlayerBtn.interactable = false;
            Debug.Log("All Players Done");
        }
    }
    //다른세계는 지연되는 경우가 존재함으로 만듬
    public void OnClickDelayBtn()
    {
        if (!CheckQueueEmpty())
        {
            NextPlayer();
            playerTurnBB.OnUpdate(UI_General.Ins.ui_RulePhase.nowPlayerID);
        }
        else
        {
            nextPlayerBtn.interactable = false;
            Debug.Log("All Players Done");
        }
    }

    void AddDictionaryKeyToList()
    {
        while(qOtherWorldPlayers.Count > 0)
        {
            qOtherWorldPlayers.Dequeue();
        }

        var toList = dOtherWorldPlayers.ToList();

        for(int i = 0; i < dOtherWorldPlayers.Count; i++)
        {
            if(toList[i].Value < 1)
            {
                dOtherWorldPlayers.Remove(toList[i].Key);       //이 경우는 시간과 공간상에서 실종인 인간을 아컴조우까지는 여기에 잡아뒀다가 다른세계 조우할 때 풀어줌으로 완전히 기회를 없애는 방법이다.
            }
        }

        ResetPlayers();
    }

    void NextPlayer()
    {
        UI_General.Ins.ui_RulePhase.nowPlayerID = qOtherWorldPlayers.Dequeue();
        characterImg.sprite = DataMng.LoadCharacterScaleImage(UI_General.Ins.ui_RulePhase.nowPlayerID);
    }

    void CheckPlayerEscape()
    {
        if (dOtherWorldPlayers[UI_General.Ins.ui_RulePhase.nowPlayerID] < 1)
        {
            dOtherWorldPlayers.Remove(UI_General.Ins.ui_RulePhase.nowPlayerID);
            Debug.Log("Escape!");
        }
    }

    void ResetPlayers()
    {
        int checkIndex = PlayersMng.turnIndex;

        for (int i = 0; i < PlayersMng.lPlayers.Count; i++)
        {
            if (dOtherWorldPlayers.ContainsKey(PlayersMng.lPlayers[checkIndex]))
            {
                qOtherWorldPlayers.Enqueue(PlayersMng.lPlayers[checkIndex]);
            }
            checkIndex++;
            if (checkIndex > PlayersMng.lPlayers.Count - 1)
                checkIndex = 0;
        }
    }

    bool CheckQueueEmpty()
    {
        if (qOtherWorldPlayers.Count > 0)
            return false;
        else
            return true;
    }
}
