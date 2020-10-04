using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_General : MonoBehaviour
{
    #region SINGLETON
    static UI_General _instance = null;
    public static UI_General Ins
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType(typeof(UI_General)) as UI_General;
                if (_instance == null)
                {
                    _instance = new GameObject("UI_General", typeof(UI_General)).GetComponent<UI_General>();
                }
            }
            return _instance;
        }
    }
    #endregion

    public enum eCardInfo
    {
        Arkham,
        OtherWorld,
        Mythos
    }
    public UI_RulePhase ui_RulePhase;
    public UI_CardInfo ui_CardInfo;
    public OptionPanel optionPanel;
    public GameObject nextPhaseBtn;

    public SystemAlert systemAlert;

    void Start()
    {
        ui_RulePhase.gameObject.SetActive(true);
        ui_CardInfo.gameObject.SetActive(false);
        optionPanel.gameObject.SetActive(false);
        systemAlert.gameObject.SetActive(false);
        nextPhaseBtn.SetActive(true);

        ui_RulePhase.Init();
    }

    public void OpenCardInfo(eCardInfo _mode)
    {
        switch(_mode)
        {
            case eCardInfo.Arkham:
                {
                    ui_CardInfo.arkhamCard.gameObject.SetActive(true);
                    ui_CardInfo.otherWorldCard.gameObject.SetActive(false);
                    ui_CardInfo.mythosCard.gameObject.SetActive(false);
                    break;
                }

            case eCardInfo.OtherWorld:
                {
                    ui_CardInfo.arkhamCard.gameObject.SetActive(false);
                    ui_CardInfo.otherWorldCard.gameObject.SetActive(true);
                    ui_CardInfo.mythosCard.gameObject.SetActive(false);
                    break;
                }

            case eCardInfo.Mythos:
                {
                    ui_CardInfo.arkhamCard.gameObject.SetActive(false);
                    ui_CardInfo.otherWorldCard.gameObject.SetActive(false);
                    ui_CardInfo.mythosCard.gameObject.SetActive(true);
                    break;
                }
        }

        ui_RulePhase.gameObject.SetActive(false);
        ui_CardInfo.gameObject.SetActive(true);
        optionPanel.gameObject.SetActive(false);
        nextPhaseBtn.SetActive(false);
        systemAlert.gameObject.SetActive(false);
    }

    public void OpenPhase()
    {
        ui_RulePhase.gameObject.SetActive(true);
        ui_CardInfo.gameObject.SetActive(false);
        optionPanel.gameObject.SetActive(false);
        systemAlert.gameObject.SetActive(false);
        nextPhaseBtn.SetActive(true);
        ui_RulePhase.OpenNowPhase();
    }

    public void OpenSystemAlert()
    {
        systemAlert.gameObject.SetActive(true);
    }

}
