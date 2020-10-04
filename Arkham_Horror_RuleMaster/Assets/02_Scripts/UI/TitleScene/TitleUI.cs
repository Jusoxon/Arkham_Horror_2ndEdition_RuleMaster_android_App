using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleUI : MonoBehaviour
{

    #region INSPECTOR
    public MainMenu mainMenu;
    public CharacterSelect characterSelect;
    public SettingMenu settingMenu;
    public DeveloperInfo developerInfo;
    #endregion

    private void Start()
    {
        OpenMainMenu();
    }

    public void StartNewGame()
    {
        mainMenu.gameObject.SetActive(false);
        characterSelect.gameObject.SetActive(true);
        settingMenu.gameObject.SetActive(false);
        developerInfo.gameObject.SetActive(false);

        characterSelect.Init();
    }

    public void LoadGame()
    {

    }

    public void OpenMainMenu()
    {
        mainMenu.gameObject.SetActive(true);
        characterSelect.gameObject.SetActive(false);
        settingMenu.gameObject.SetActive(false);
        developerInfo.gameObject.SetActive(false);
    }

    public void OpenSetting()
    {
        mainMenu.gameObject.SetActive(false);
        characterSelect.gameObject.SetActive(false);
        settingMenu.gameObject.SetActive(true);
        developerInfo.gameObject.SetActive(false);
    }

    public void OpenDevInfo()
    {
        mainMenu.gameObject.SetActive(false);
        characterSelect.gameObject.SetActive(false);
        settingMenu.gameObject.SetActive(false);
        developerInfo.gameObject.SetActive(true);
    }
}
