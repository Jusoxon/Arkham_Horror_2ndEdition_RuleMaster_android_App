using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_RulePhase : MonoBehaviour
{
    public enum eOpenPhase
    {
        MaintainPhase,
        MovePhase,
        ArkhamPhase,
        OtherWorldPhase,
        MythosPhase
    }
    public MaintainPhase maintainPhase;
    public MovePhase movePhase;
    public ArkhamEncounterPhase arkhamEncounterPhase;
    public OtherWorldEncounterPhase otherWorldPhase;
    public MythosPhase mythosPhase;

    public int nowPlayerID;

    public void Init()
    {
        maintainPhase.gameObject.SetActive(true);
        movePhase.gameObject.SetActive(false);
        arkhamEncounterPhase.gameObject.SetActive(false);
        otherWorldPhase.gameObject.SetActive(false);
        mythosPhase.gameObject.SetActive(false);

        maintainPhase.Init();
        movePhase.Init();
        arkhamEncounterPhase.Init();
        otherWorldPhase.Init();
        mythosPhase.Init();
    }

    public void OnClickNextPhaseBtn()
    {
        RuleMaster.Ins.NextPhase();

        switch (RuleMaster.Ins.CheckNowPhase())
        {
            case RuleMaster.eNowPhase.Maintain_Phase:
                maintainPhase.gameObject.SetActive(true);
                movePhase.gameObject.SetActive(false);
                arkhamEncounterPhase.gameObject.SetActive(false);
                otherWorldPhase.gameObject.SetActive(false);
                mythosPhase.gameObject.SetActive(false);

                PlayersMng.NextFirstPlayer();
                break;

            case RuleMaster.eNowPhase.Move_Phase:
                maintainPhase.gameObject.SetActive(false);
                movePhase.gameObject.SetActive(true);
                arkhamEncounterPhase.gameObject.SetActive(false);
                otherWorldPhase.gameObject.SetActive(false);
                mythosPhase.gameObject.SetActive(false);
                break;

            case RuleMaster.eNowPhase.ArkhamEncounter_Phase:
                maintainPhase.gameObject.SetActive(false);
                movePhase.gameObject.SetActive(false);
                arkhamEncounterPhase.gameObject.SetActive(true);
                otherWorldPhase.gameObject.SetActive(false);
                mythosPhase.gameObject.SetActive(false);

                arkhamEncounterPhase.OnUpdate();
                break;

            case RuleMaster.eNowPhase.OtherWorldEncounter_Phase:
                otherWorldPhase.CheckOtherWorldCount();
                if (otherWorldPhase.dOtherWorldPlayers.Count<1)
                {
                    UI_General.Ins.systemAlert.OpenSysAlert(SystemAlert.eOpenSystemMode.NoOtherWorld,0,0);
                    UI_General.Ins.systemAlert.gameObject.SetActive(true);
                }
                else
                {
                    otherWorldPhase.OnUpdate();
                }

                maintainPhase.gameObject.SetActive(false);
                movePhase.gameObject.SetActive(false);
                arkhamEncounterPhase.gameObject.SetActive(false);
                otherWorldPhase.gameObject.SetActive(true);
                mythosPhase.gameObject.SetActive(false);

                break;

            case RuleMaster.eNowPhase.Mythos_Phase:
                maintainPhase.gameObject.SetActive(false);
                movePhase.gameObject.SetActive(false);
                arkhamEncounterPhase.gameObject.SetActive(false);
                otherWorldPhase.gameObject.SetActive(false);
                mythosPhase.gameObject.SetActive(true);
                break;
        }
    }

    public void OpenNowPhase()
    {
        switch (RuleMaster.Ins.CheckNowPhase())
        {
            case RuleMaster.eNowPhase.Maintain_Phase:
                maintainPhase.gameObject.SetActive(true);
                movePhase.gameObject.SetActive(false);
                arkhamEncounterPhase.gameObject.SetActive(false);
                otherWorldPhase.gameObject.SetActive(false);
                mythosPhase.gameObject.SetActive(false);
                break;

            case RuleMaster.eNowPhase.Move_Phase:
                maintainPhase.gameObject.SetActive(false);
                movePhase.gameObject.SetActive(true);
                arkhamEncounterPhase.gameObject.SetActive(false);
                otherWorldPhase.gameObject.SetActive(false);
                mythosPhase.gameObject.SetActive(false);
                break;

            case RuleMaster.eNowPhase.ArkhamEncounter_Phase:
                maintainPhase.gameObject.SetActive(false);
                movePhase.gameObject.SetActive(false);
                arkhamEncounterPhase.gameObject.SetActive(true);
                otherWorldPhase.gameObject.SetActive(false);
                mythosPhase.gameObject.SetActive(false);
                break;

            case RuleMaster.eNowPhase.OtherWorldEncounter_Phase:
                maintainPhase.gameObject.SetActive(false);
                movePhase.gameObject.SetActive(false);
                arkhamEncounterPhase.gameObject.SetActive(false);
                otherWorldPhase.gameObject.SetActive(true);
                mythosPhase.gameObject.SetActive(false);
                break;

            case RuleMaster.eNowPhase.Mythos_Phase:
                maintainPhase.gameObject.SetActive(false);
                movePhase.gameObject.SetActive(false);
                arkhamEncounterPhase.gameObject.SetActive(false);
                otherWorldPhase.gameObject.SetActive(false);
                mythosPhase.gameObject.SetActive(true);
                break;
        }
    }

    public void OpenExceptionPhase(eOpenPhase _open)
    {
        switch(_open)
        {
            case eOpenPhase.MaintainPhase:
                maintainPhase.gameObject.SetActive(true);
                movePhase.gameObject.SetActive(false);
                arkhamEncounterPhase.gameObject.SetActive(false);
                otherWorldPhase.gameObject.SetActive(false);
                mythosPhase.gameObject.SetActive(false);
                break;

            case eOpenPhase.MovePhase:
                maintainPhase.gameObject.SetActive(false);
                movePhase.gameObject.SetActive(true);
                arkhamEncounterPhase.gameObject.SetActive(false);
                otherWorldPhase.gameObject.SetActive(false);
                mythosPhase.gameObject.SetActive(false);
                break;

            case eOpenPhase.ArkhamPhase:
                maintainPhase.gameObject.SetActive(false);
                movePhase.gameObject.SetActive(false);
                arkhamEncounterPhase.gameObject.SetActive(true);
                otherWorldPhase.gameObject.SetActive(false);
                mythosPhase.gameObject.SetActive(false);
                break;

            case eOpenPhase.OtherWorldPhase:
                maintainPhase.gameObject.SetActive(false);
                movePhase.gameObject.SetActive(false);
                arkhamEncounterPhase.gameObject.SetActive(false);
                otherWorldPhase.gameObject.SetActive(true);
                mythosPhase.gameObject.SetActive(false);
                break;

            case eOpenPhase.MythosPhase:
                maintainPhase.gameObject.SetActive(false);
                movePhase.gameObject.SetActive(false);
                arkhamEncounterPhase.gameObject.SetActive(false);
                otherWorldPhase.gameObject.SetActive(false);
                mythosPhase.gameObject.SetActive(true);
                break;
        }
    }
}
