using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameOption : MonoBehaviour
{
    public Image optionPanel;

    bool isOpenOptionPanel;

    public void OnClickOptionBtn()
    {
        isOpenOptionPanel = !isOpenOptionPanel;
        if (isOpenOptionPanel)
            optionPanel.gameObject.SetActive(true);
        else
            optionPanel.gameObject.SetActive(false);
    }

    public void OnClickSaveBtn()
    {

    }

    public void OnClickGiveUpBtn()
    {
        UI_General.Ins.systemAlert.OpenSysAlert(SystemAlert.eOpenSystemMode.BackToTitle,0,0);
    }

    public void OnClickOptionPanelBtn()
    {
        UI_General.Ins.optionPanel.gameObject.SetActive(true);
    }
}
