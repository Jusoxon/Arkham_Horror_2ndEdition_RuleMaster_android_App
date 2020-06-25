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

    #region INSPECTOR
    public UI_RuleMaster UI_RuleMaster;
    public UI_Alert UI_Alert;
    public UI_AlertInfo UI_AlertInfo;
    public UI_SystemMessage UI_SystemMessage;
    public UI_Help UI_Help;
    public UI_GameOption UI_GameOption;
    #endregion

    private void Start()
    {
        UI_RuleMaster.gameObject.SetActive(true);
        UI_Alert.gameObject.SetActive(false);
        UI_AlertInfo.gameObject.SetActive(false);
        UI_SystemMessage.gameObject.SetActive(false);
        UI_Help.gameObject.SetActive(false);
        UI_GameOption.gameObject.SetActive(false);
    }
}
