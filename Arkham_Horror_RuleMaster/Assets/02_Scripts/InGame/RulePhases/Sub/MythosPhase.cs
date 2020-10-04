using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MythosPhase : MonoBehaviour
{
    public void Init()
    {

    }

    public void OnClickMythosCardBtn()
    {
        RuleMaster.Ins.MythosEncounterCardDraw();
        UI_General.Ins.OpenCardInfo(UI_General.eCardInfo.Mythos);
        UI_General.Ins.ui_CardInfo.MythosSetting();
    }
}
