using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_AlertInfo : MonoBehaviour
{
    public Image BB;
    public Image rumorCard;
    public Image environmentCityCard;
    public Image environmentWeatherCard;
    public Image environmentMisticCard;

    public GameObject isClearAlert;

    public void CheckAlertInfoUI()
    {
        isClearAlert.gameObject.SetActive(false);

        if (RuleMaster.Ins.activeRumorNum != 0)
            rumorCard.gameObject.SetActive(true);
        else
            rumorCard.gameObject.SetActive(false);

        if (RuleMaster.Ins.activeEnvironmentCityNum != 0)
            environmentCityCard.gameObject.SetActive(true);
        else
            environmentCityCard.gameObject.SetActive(false);

        if (RuleMaster.Ins.activeEnvironmentWeatherNum != 0)
            environmentWeatherCard.gameObject.SetActive(true);
        else
            environmentWeatherCard.gameObject.SetActive(false);

        if (RuleMaster.Ins.activeEnvironmentMisticNum != 0)
            environmentMisticCard.gameObject.SetActive(true);
        else
            environmentMisticCard.gameObject.SetActive(false);
    }

    public void OnClickRumorCard()
    {
        isClearAlert.gameObject.SetActive(true);
    }

    public void OnClickSuccessBtn()
    {
        RuleMaster.Ins.activeRumorNum = 0;
        rumorCard.gameObject.SetActive(false);
        isClearAlert.gameObject.SetActive(false);
    }

    public void OnClickFailBtn()
    {
        RuleMaster.Ins.activeRumorNum = 0;
        rumorCard.gameObject.SetActive(false);
        isClearAlert.gameObject.SetActive(false);
    }

    public void OnClickMaintainBtn()
    {
        isClearAlert.gameObject.SetActive(false);
    }

    public void OnClickEscapeAlertInfoBtn()
    {
        this.gameObject.SetActive(false);
        UI_General.Ins.UI_Alert.CheckAlertUI(RuleMaster.Ins.activeRumorNum, RuleMaster.Ins.activeEnvironmentCityNum, RuleMaster.Ins.activeEnvironmentWeatherNum, RuleMaster.Ins.activeEnvironmentMisticNum);
        UI_General.Ins.UI_Alert.gameObject.SetActive(true);
    }
}
