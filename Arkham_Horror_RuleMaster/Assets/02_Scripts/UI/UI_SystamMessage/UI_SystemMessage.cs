using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using global_define;
using UnityEngine.UI;

public enum eMessageCheck
{
    IsSuccess,
    IsSure,
    IsCorrect,

}
public class UI_SystemMessage : MonoBehaviour
{
    #region INSPECTOR
    public Text questionTxt;
    public Button successBtn;
    public Button failBtn;
    public Button maintainBtn;

    public Text checkSuccessButtonTxt;
    public Text checkFailButtonTxt;

    bool checkDoubleMessage;
    #endregion

    public void MessageInit(eMessageCheck _message)
    {
        switch(_message)
        {
            case eMessageCheck.IsSuccess:
                {
                    questionTxt.text = TextMake.IS_SUCCESS_TEXT;
                    SetButtonInit(true, true, false);
                    SetButtonText(_message);
                    break;
                }
            case eMessageCheck.IsSure:
                {
                    questionTxt.text = TextMake.IS_SURE_TEXT;
                    SetButtonInit(true, true, false);
                    SetButtonText(_message);
                    break;
                }
            case eMessageCheck.IsCorrect:
                {
                    questionTxt.text = TextMake.IS_CORRECT_ABYSS_TEXT;
                    SetButtonInit(true, true, false);
                    SetButtonText(_message);
                    break;
                }
        }
        this.gameObject.SetActive(true);
    }

    void SetButtonInit(bool _success, bool _fail, bool _maintain)
    {
        successBtn.gameObject.SetActive(_success);
        failBtn.gameObject.SetActive(_fail);
        maintainBtn.gameObject.SetActive(_maintain);
    }
    void SetButtonText(eMessageCheck _message)
    {
        switch(_message)
        {
            case eMessageCheck.IsSuccess:
                {
                    checkSuccessButtonTxt.text = "성공";
                    checkFailButtonTxt.text = "실패";
                    break;
                }
            case eMessageCheck.IsSure:
                {
                    checkSuccessButtonTxt.text = "수락";
                    checkFailButtonTxt.text = "거절";
                    break;
                }
            case eMessageCheck.IsCorrect:
                {
                    checkSuccessButtonTxt.text = "네";
                    checkFailButtonTxt.text = "아니오";
                    break;
                }
        }

    }

    public void OnClickSuccessBtn()
    {
        if(RuleMaster.Ins.isCheckSectNum)
        {
            switch(RuleMaster.Ins.checkPhase)
            {
                case eCheckPhase.AbyssCheck:
                    {
                        UI_General.Ins.UI_RuleMaster.CloseAbyssUI();
                        UI_General.Ins.UI_RuleMaster.OpenPlaceUI();
                        RuleMaster.Ins.isCheckSectNum = false;
                        RuleMaster.Ins.checkPhase = eCheckPhase.None;
                        break;
                    }
                case eCheckPhase.MythosCheck:
                    {
                        UI_General.Ins.UI_RuleMaster.CloseMythosUI();
                        UI_General.Ins.UI_RuleMaster.OpenPlaceUI();
                        RuleMaster.Ins.isCheckSectNum = false;
                        RuleMaster.Ins.checkPhase = eCheckPhase.None;
                        break;
                    }
            }

        }
        else
        {
            //검은 동굴[2] 아컴 조우
            if(RuleMaster.Ins.checkPlaceCardNum == 61)
            {
                UI_General.Ins.UI_RuleMaster.OpenPlaceDoubleUI();
                UI_General.Ins.UI_RuleMaster.ClosePlaceUI();
                RuleMaster.Ins.checkPhase = eCheckPhase.PlaceCheck;
                RuleMaster.Ins.isCheckSectNum = true;
                UI_General.Ins.UI_RuleMaster.UI_CardInfo.UI_PlaceDoubleCard.ecolor = ePlaceColor.Purple;
            }
            //숲 아컴조우[2]
            else if (RuleMaster.Ins.checkPlaceCardNum == 62)
            {
                UI_General.Ins.UI_RuleMaster.OpenPlaceDoubleUI();
                UI_General.Ins.UI_RuleMaster.ClosePlaceUI();
                RuleMaster.Ins.checkPhase = eCheckPhase.PlaceCheck;
                RuleMaster.Ins.isCheckSectNum = true;
                UI_General.Ins.UI_RuleMaster.UI_CardInfo.UI_PlaceDoubleCard.ecolor = ePlaceColor.Red;
            }
            //실버 트와일라이트[2] 아컴 조우
            else if(RuleMaster.Ins.checkPlaceCardNum == 63)
            {
                if(!checkDoubleMessage)
                {
                    checkDoubleMessage = true;
                    MessageInit(eMessageCheck.IsSuccess);
                }
                else
                {
                    checkDoubleMessage = false;
                }
            }

        }
        this.gameObject.SetActive(false);
    }

    public void OnClickFailBtn()
    {
        if(RuleMaster.Ins.isCheckSectNum)
        {
            switch(RuleMaster.Ins.checkPhase)
            {
                case eCheckPhase.AbyssCheck:
                    {
                        UI_General.Ins.UI_RuleMaster.OpenAbyssUI();
                        UI_General.Ins.UI_RuleMaster.ClosePlaceUI();
                        RuleMaster.Ins.checkPhase = eCheckPhase.AbyssCheck;
                        RuleMaster.Ins.isCheckSectNum = true;
                        break;
                    }

                case eCheckPhase.MythosCheck:
                    {
                        UI_General.Ins.UI_RuleMaster.OpenMythosUI();
                        UI_General.Ins.UI_RuleMaster.ClosePlaceUI();
                        RuleMaster.Ins.checkPhase = eCheckPhase.MythosCheck;
                        RuleMaster.Ins.isCheckSectNum = true;
                        break;
                    }
            }
        }
        else
        {
            //신화카드 뽑기 체크만 하면 되는 경우.
            if (RuleMaster.Ins.checkPlaceCardNum == 6)
            {
                UI_General.Ins.UI_RuleMaster.OpenMythosUI();
                UI_General.Ins.UI_RuleMaster.ClosePlaceUI();
                RuleMaster.Ins.checkPhase = eCheckPhase.MythosCheck;
                RuleMaster.Ins.isCheckSectNum = true;
            }

            //다른세계 조우 뽑기 체크를 하는 경우 => 해당 카드가 조우세계에 맞는지 체크하는거 필요함.
            else if (RuleMaster.Ins.checkPlaceCardNum == 7 || RuleMaster.Ins.checkPlaceCardNum == 63)
            {
                UI_General.Ins.UI_RuleMaster.OpenAbyssUI();
                UI_General.Ins.UI_RuleMaster.ClosePlaceUI();
                RuleMaster.Ins.checkPhase = eCheckPhase.AbyssCheck;
                RuleMaster.Ins.isCheckSectNum = true;
                checkDoubleMessage = false;
            }

        }

        this.gameObject.SetActive(false);
    }

    
}
