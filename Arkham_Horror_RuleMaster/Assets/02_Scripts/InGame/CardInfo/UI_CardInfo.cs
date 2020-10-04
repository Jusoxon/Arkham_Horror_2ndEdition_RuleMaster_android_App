using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using global_define;

public class UI_CardInfo : MonoBehaviour
{
    #region INSPECTOR
    public ArkhamCardInfo arkhamCard;
    public OtherWorldCardInfo otherWorldCard;
    public MythosCardInfo mythosCard;

    public Image cardInfoBBImg;

    public List<InfoCards> lSubCards;

    public int cardNum;
    
    #endregion
    
    public enum eOpenMode
    {
        ArkhamCardInfo,
        OtherWorldCardInfo,
        MythosCardInfo,
    }

    public eOpenMode eMode;

    public void OnClickSection(int _section)
    {
        UI_General.Ins.OpenPhase();     //수정 필요

        if(eMode == eOpenMode.ArkhamCardInfo)
        {
            RuleMaster.Ins.ArkhamExceptionCard(cardNum, _section);
        }
        else if(eMode == eOpenMode.MythosCardInfo)
        {

        }
    }

    public void OnClickCard()
    {
        UI_General.Ins.OpenPhase();
    }

    public void OnClickSubCard(int _cardNum)
    {
        switch(eMode)
        {
            case eOpenMode.ArkhamCardInfo:
                arkhamCard.SettingText(lSubCards[_cardNum].cardNum);
                cardNum = lSubCards[_cardNum].cardNum;
                break;
        
            case eOpenMode.OtherWorldCardInfo:
                otherWorldCard.SettingText(lSubCards[_cardNum].cardNum);
                cardNum = lSubCards[_cardNum].cardNum;
                break;

            case eOpenMode.MythosCardInfo:                          //필요 없는거 같은데?
                mythosCard.SettingText(lSubCards[_cardNum].cardNum);
                cardNum = lSubCards[_cardNum].cardNum;
                break;
        }

    }

    #region Arkham Encounter
    public void ArkhamCardSetting()
    {
        eMode = eOpenMode.ArkhamCardInfo;
        ArkhamSubCardSetting();
        cardNum = RuleMaster.Ins.lArkhamCard[0];
        arkhamCard.SettingText(cardNum) ;
        cardInfoBBImg.sprite = DataMng.LoadArkhamCardImage(cardNum);
    }

    void ArkhamSubCardSetting()
    {
        for (int i = 0; i < lSubCards.Count; i++)
        {
            lSubCards[i].gameObject.SetActive(false);
        }

        if(RuleMaster.Ins.lArkhamCard.Count < 2)
        {
            for (int i = 0; i < lSubCards.Count; i++)
            {
                lSubCards[i].gameObject.SetActive(false);
            }
        }

        else
        {
            for (int i = 0; i < RuleMaster.Ins.lArkhamCard.Count; i++)
            {
                lSubCards[i].gameObject.SetActive(true);
                lSubCards[i].ArkhamInit(RuleMaster.Ins.lArkhamCard[i]);
            }
        }
    }

    #endregion

    #region OtherWorld Encounter

    public void OtherWorldSetting()
    {
        eMode = eOpenMode.OtherWorldCardInfo;
        OtherWorldSubCardSetting();
        otherWorldCard.SettingText(RuleMaster.Ins.lOtherWorldCard[0]);
        cardInfoBBImg.sprite = DataMng.LoadOtherWorldCardImage(RuleMaster.Ins.lOtherWorldCard[0]);
    }

    void OtherWorldSubCardSetting()
    {
        for (int i = 0; i < lSubCards.Count; i++)
        {
            lSubCards[i].gameObject.SetActive(false);
        }

        if (RuleMaster.Ins.lOtherWorldCard.Count < 2)
        {
            for (int i = 0; i < lSubCards.Count; i++)
            {
                lSubCards[i].gameObject.SetActive(false);
            }
        }

        else
        {
            for (int i = 0; i < RuleMaster.Ins.lOtherWorldCard.Count; i++)
            {
                lSubCards[i].gameObject.SetActive(true);
                lSubCards[i].OtherWorldInit(RuleMaster.Ins.lOtherWorldCard[i]);
            }
        }
    }


    #endregion

    #region Mythos Encounter
    public void MythosSetting()
    {
        eMode = eOpenMode.MythosCardInfo;
        mythosCard.SettingText(RuleMaster.Ins.nowMythosCard);
        cardInfoBBImg.sprite = DataMng.LoadMythosCardImage(RuleMaster.Ins.nowMythosCard);
        for (int i = 0; i < lSubCards.Count; i++)
            lSubCards[i].gameObject.SetActive(false);
    }
    #endregion


}
