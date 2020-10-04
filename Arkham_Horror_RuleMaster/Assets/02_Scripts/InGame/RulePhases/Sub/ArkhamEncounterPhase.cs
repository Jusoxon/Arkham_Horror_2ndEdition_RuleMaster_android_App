using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArkhamEncounterPhase : MonoBehaviour
{
    #region INSPECTOR
    public OtherWorldEncounterPhase otherWorldPhase;
    public PlayerTurnPassBB playerTurnBB;

    public Button nextPlayerBtn;
    public Button fallOtherWorldBtn;
    public Image characterImg;
    #endregion
    Queue<int> qArkhamPlayers;

    //public int nowPlayer;

    public void Init()
    {
        qArkhamPlayers = new Queue<int>();
    }


    public void OnUpdate()
    {
        ResetPlayers();
        NextPlayer();

        nextPlayerBtn.interactable = true;
        fallOtherWorldBtn.interactable = true;

        playerTurnBB.OnUpdate(UI_General.Ins.ui_RulePhase.nowPlayerID);
    }

    //public int GetNowPlayer() { return nowPlayer; }

    public void OnClickNextPlayerBtn()
    {
        if(!CheckQueueEmpty())
        {
            NextPlayer();
            playerTurnBB.OnUpdate(UI_General.Ins.ui_RulePhase.nowPlayerID);
        }
        else
        {
            nextPlayerBtn.interactable = false;
            fallOtherWorldBtn.interactable = false;
            Debug.Log("All Players Done");
        }

        
    }

    public void OnClickFallOtherWorldBtn()
    {
        otherWorldPhase.dOtherWorldPlayers.Add(UI_General.Ins.ui_RulePhase.nowPlayerID, 2);       //2를 넣는 이유는 기본적으로 다른세계조우는 2번 진행하기 때문

        if (!CheckQueueEmpty())
        {
            NextPlayer();
            playerTurnBB.OnUpdate(UI_General.Ins.ui_RulePhase.nowPlayerID);
        }
        else
        {
            nextPlayerBtn.interactable = false;
            fallOtherWorldBtn.interactable = false;
            Debug.Log("All Players Done");
        }
    }

    public void OnClickArkhamEncounterCard(int _eColor)
    {
        RuleMaster.Ins.ArkhamEncounterCardDraw(UI_General.Ins.ui_RulePhase.nowPlayerID, _eColor);
        UI_General.Ins.OpenCardInfo(UI_General.eCardInfo.Arkham);
        UI_General.Ins.ui_CardInfo.ArkhamCardSetting();
        this.gameObject.SetActive(false);
        
    }

    void NextPlayer()
    {
        UI_General.Ins.ui_RulePhase.nowPlayerID = qArkhamPlayers.Dequeue();
        characterImg.sprite = DataMng.LoadCharacterScaleImage(UI_General.Ins.ui_RulePhase.nowPlayerID);
    }

    void ResetPlayers()
    {
        while(qArkhamPlayers.Count > 0)
        {
            qArkhamPlayers.Dequeue();
        }

        int checkIndex = PlayersMng.turnIndex;

        for(int i = 0; i < PlayersMng.lPlayers.Count; i++)
        {
            if (otherWorldPhase.dOtherWorldPlayers.ContainsKey(PlayersMng.lPlayers[checkIndex]))
            {

            }
            else
                qArkhamPlayers.Enqueue(PlayersMng.lPlayers[checkIndex]);

            checkIndex++;
            if (checkIndex > PlayersMng.lPlayers.Count - 1)
                checkIndex = 0;
        }
    }

    bool CheckQueueEmpty()
    {
        if (qArkhamPlayers.Count > 0)
            return false;
        else
            return true;
    }


}
