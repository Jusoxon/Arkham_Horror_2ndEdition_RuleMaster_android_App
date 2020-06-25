using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.U2D;
using UnityEngine.UI;

public class UI_CardInfo : MonoBehaviour
{
    public Image BB;
    public Image cardBackground;

    public UI_PlaceCardInfo UI_PlaceCardInfo;
    public UI_AbyssCardInfo UI_AbyssCardInfo;
    public UI_MythosCardInfo UI_MythosCardInfo;
    public UI_PlaceDoubleCard UI_PlaceDoubleCard;

    private void Start()
    {
        this.gameObject.SetActive(false);
    }
    public void UI_CardInfoInit(eNowPhase _eNowPhase, int _cardNum)
    {
        this.gameObject.SetActive(true);
        //카드 뒷면 이미지는 각 페이즈의 카드데이터에 있는 녀석을 불러오게 해야함. (현재 카드 데이터 내에 이미지관련 없음.)
        switch(_eNowPhase)
        {
            case eNowPhase.PlaceEncounterPhase:
                {
                    UI_PlaceCardInfo.gameObject.SetActive(true);
                    UI_AbyssCardInfo.gameObject.SetActive(false);
                    UI_MythosCardInfo.gameObject.SetActive(false);
                    UI_PlaceDoubleCard.gameObject.SetActive(false);
                    //cardBackground.sprite = 
                    UI_PlaceCardInfo.CardInfoSetting(_cardNum);
                    break;
                }

            case eNowPhase.AbyssEncounterPhase:
                {
                    UI_PlaceCardInfo.gameObject.SetActive(false);
                    UI_AbyssCardInfo.gameObject.SetActive(true);
                    UI_MythosCardInfo.gameObject.SetActive(false);
                    UI_PlaceDoubleCard.gameObject.SetActive(false);
                    //cardBackground.sprite = 
                    UI_AbyssCardInfo.CardInfoSetting(_cardNum);
                    break;
                }

            case eNowPhase.MythologyPhase:
                {
                    UI_PlaceCardInfo.gameObject.SetActive(false);
                    UI_AbyssCardInfo.gameObject.SetActive(false);
                    UI_MythosCardInfo.gameObject.SetActive(true);
                    UI_PlaceDoubleCard.gameObject.SetActive(false);
                    //cardBackground.sprite = 
                    UI_MythosCardInfo.CardInfoSetting(_cardNum);
                    break;
                }
        }
    }

    public void OnClickEscapeBtn()
    {
        this.gameObject.SetActive(false);
        if(RuleMaster.Ins.isCheckSectNum)
        {
            //UI_General.Ins.UI_RuleMaster.CloseMythosUI();
            //UI_General.Ins.UI_RuleMaster.OpenPlaceUI();
            //RuleMaster.Ins.isCheckSectNum = false;
            UI_General.Ins.UI_SystemMessage.MessageInit(eMessageCheck.IsCorrect);
        }
        else
            RuleMaster.Ins.CheckExceptionCard();
    }

    public void OnClickSectBtn(int _num)
    {
        this.gameObject.SetActive(false);
        if(RuleMaster.Ins.isCheckSectNum)
        {
            //UI_General.Ins.UI_RuleMaster.CloseAbyssUI();
            //UI_General.Ins.UI_RuleMaster.OpenPlaceUI();
            //RuleMaster.Ins.isCheckSectNum = false;
            UI_General.Ins.UI_SystemMessage.MessageInit(eMessageCheck.IsCorrect);
        }
        else
        {
            RuleMaster.Ins.selectSectNum = _num;
            RuleMaster.Ins.CheckExceptionCard();
        }

    }
}
