using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Alert : MonoBehaviour
{
    public Text alertRumorTxt;
    public Text alertEnvironmentCityTxt;
    public Text alertEnvironmentWeatherTxt;
    public Text alertEnvironmentMisticTxt;

    public void CheckAlertUI(int _rumor, int _enCity, int _enWeather, int _enMistic)
    {
        if (_rumor == 0 && _enCity == 0 && _enWeather == 0 && _enMistic == 0)
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            this.gameObject.SetActive(true);

            if (_rumor != 0)
                alertRumorTxt.gameObject.SetActive(true);
            else
                alertRumorTxt.gameObject.SetActive(false);

            if (_enCity != 0)
                alertEnvironmentCityTxt.gameObject.SetActive(true);
            else
                alertEnvironmentCityTxt.gameObject.SetActive(false);

            if (_enWeather != 0)
                alertEnvironmentWeatherTxt.gameObject.SetActive(true);
            else
                alertEnvironmentWeatherTxt.gameObject.SetActive(false);

            if (_enMistic != 0)
                alertEnvironmentMisticTxt.gameObject.SetActive(true);
            else
                alertEnvironmentMisticTxt.gameObject.SetActive(false);
        }

    }

    public void OnClickAlert()
    {
        this.gameObject.SetActive(false);
        UI_General.Ins.UI_AlertInfo.gameObject.SetActive(true);
        UI_General.Ins.UI_AlertInfo.CheckAlertInfoUI();
    }
}
