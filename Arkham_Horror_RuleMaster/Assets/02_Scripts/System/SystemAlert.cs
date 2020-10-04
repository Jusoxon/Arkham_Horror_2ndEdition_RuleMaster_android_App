using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SystemAlert : MonoBehaviour
{
    public enum eOpenSystemMode
    {
        //물어보는 것들.
        NoOtherWorld,
        SureApply,
        IsSuccesses,
        CheckApply,

        BackToTitle
    }

    public eOpenSystemMode eOpenMode;

    public Button yesBtn;
    public Button noBtn;

    public GameObject noOneInOtherWorld;
    public GameObject sureApply;
    public GameObject isSuccesses;
    public GameObject backToTitle;
    public GameObject isCheckApply;

    public int checkCardNum;
    public int checkCardSec;

    public void OpenSysAlert(eOpenSystemMode _mode, int _cardNum, int _secNum)
    {
        this.gameObject.SetActive(true);
        checkCardNum = _cardNum;
        checkCardSec = _secNum;
        switch(_mode)
        {
            case eOpenSystemMode.NoOtherWorld:
                eOpenMode = eOpenSystemMode.NoOtherWorld;
                noOneInOtherWorld.SetActive(true);
                sureApply.SetActive(false);
                isSuccesses.SetActive(false);
                backToTitle.SetActive(false);
                isCheckApply.SetActive(false);

                yesBtn.gameObject.SetActive(true);
                noBtn.gameObject.SetActive(false);
                break;

            case eOpenSystemMode.SureApply:
                eOpenMode = eOpenSystemMode.SureApply;
                noOneInOtherWorld.SetActive(false);
                sureApply.SetActive(true);
                isSuccesses.SetActive(false);
                backToTitle.SetActive(false);
                isCheckApply.SetActive(false);

                yesBtn.gameObject.SetActive(true);
                noBtn.gameObject.SetActive(true);
                break;

            case eOpenSystemMode.IsSuccesses:
                eOpenMode = eOpenSystemMode.IsSuccesses;
                noOneInOtherWorld.SetActive(false);
                sureApply.SetActive(false);
                isSuccesses.SetActive(true);
                backToTitle.SetActive(false);
                isCheckApply.SetActive(false);

                yesBtn.gameObject.SetActive(true);
                noBtn.gameObject.SetActive(true);
                break;

            case eOpenSystemMode.CheckApply:
                eOpenMode = eOpenSystemMode.CheckApply;
                noOneInOtherWorld.SetActive(false);
                sureApply.SetActive(false);
                isSuccesses.SetActive(false);
                isCheckApply.SetActive(true);
                backToTitle.SetActive(false);

                yesBtn.gameObject.SetActive(true);
                noBtn.gameObject.SetActive(true);
                break;

            case eOpenSystemMode.BackToTitle:
                eOpenMode = eOpenSystemMode.BackToTitle;
                noOneInOtherWorld.SetActive(false);
                sureApply.SetActive(false);
                isSuccesses.SetActive(false);
                backToTitle.SetActive(true);
                isCheckApply.SetActive(false);

                yesBtn.gameObject.SetActive(true);
                noBtn.gameObject.SetActive(true);

                break;
        }
    }

    public void OnClickYesBtn()
    {
        switch(eOpenMode)
        {
            case eOpenSystemMode.NoOtherWorld:
                UI_General.Ins.ui_RulePhase.OnClickNextPhaseBtn();
                this.gameObject.SetActive(false);
                break;

            case eOpenSystemMode.SureApply:
                CheckArkhamSureYes();
                if (checkCardNum == 63 && checkCardSec == 1)
                    return;
                this.gameObject.SetActive(false);       //63번 카드 여기서 걸림.
                break;

            case eOpenSystemMode.IsSuccesses:
                CheckArkhamSuccessYes();
                this.gameObject.SetActive(false);
                break;

            case eOpenSystemMode.CheckApply:
                this.gameObject.SetActive(false);
                break;

            case eOpenSystemMode.BackToTitle:
                this.gameObject.SetActive(false);
                SceneMng.ChangeScene(global_define.eScene.Title);
                break;
        }
    }

    public void OnClickNoBtn()
    {
        switch (eOpenMode)
        {
            case eOpenSystemMode.SureApply:
                CheckArkhamSureNo();
                this.gameObject.SetActive(false);
                break;

            case eOpenSystemMode.IsSuccesses:
                CheckArkhamSuccessNo();
                this.gameObject.SetActive(false);
                break;

            case eOpenSystemMode.BackToTitle:
                this.gameObject.SetActive(false);
                break;
        }
    }
    void CheckArkhamSureYes()
    {
        switch (checkCardNum)
        {
            case 61:
                //검은동굴 뽑기
                RuleMaster.Ins.ArkhamEncounterCardDraw(UI_General.Ins.ui_RulePhase.nowPlayerID, (int)global_define.ePlaceColor.Purple, 1);
                //카드 인포 열기
                UI_General.Ins.ui_CardInfo.ArkhamCardSetting();
                UI_General.Ins.OpenCardInfo(UI_General.eCardInfo.Arkham);
                break;
            case 62:
                if(checkCardSec == 1)
                {
                    //숲 뽑기
                    RuleMaster.Ins.ArkhamEncounterCardDraw(UI_General.Ins.ui_RulePhase.nowPlayerID, (int)global_define.ePlaceColor.Red, 1);
                    //카드 인포 열기
                    UI_General.Ins.ui_CardInfo.ArkhamCardSetting();
                    UI_General.Ins.OpenCardInfo(UI_General.eCardInfo.Arkham);
                }
                break;
            case 63:
                if(checkCardSec == 1)
                {
                    OpenSysAlert(eOpenSystemMode.IsSuccesses, checkCardNum, checkCardSec);
                }
                else if(checkCardSec == 2)
                {
                    RuleMaster.Ins.ArkhamEncounterCardDraw(UI_General.Ins.ui_RulePhase.nowPlayerID, (int)global_define.ePlaceColor.Blue, 1);
                    UI_General.Ins.ui_CardInfo.ArkhamCardSetting();
                    UI_General.Ins.OpenCardInfo(UI_General.eCardInfo.Arkham);
                }
                break;

        }
    }

    void CheckArkhamSuccessYes()
    {
        ////다른세계 조우를 열어야 함
        //switch(checkCardNum)
        //{
        //    case 62:
        //        if(checkCardSec == 2)
        //        {
        //
        //        }
        //            break;
        //}
    }

    void CheckArkhamSureNo()
    {
        //걸리는 케이스가 없음
    }

    void CheckArkhamSuccessNo()
    {
        switch (checkCardNum)
        {
            case 6:
                //신화페이즈열기 및 드로우
                UI_General.Ins.ui_RulePhase.OpenExceptionPhase(UI_RulePhase.eOpenPhase.MythosPhase);
                break;
            case 7:
                //다른세계조우카드열기 및 드로우
                UI_General.Ins.ui_RulePhase.OpenExceptionPhase(UI_RulePhase.eOpenPhase.OtherWorldPhase);
                break;
            case 63:
                //다른세계조우카드열기 및 드로우
                UI_General.Ins.ui_RulePhase.OpenExceptionPhase(UI_RulePhase.eOpenPhase.OtherWorldPhase);
                break;
        }
    }

}
