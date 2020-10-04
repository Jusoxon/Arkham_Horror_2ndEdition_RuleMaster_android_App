using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    #region INSPECTOR
    public TitleUI titleUI;
    public Image logo;

    public GameObject mainBtns;
    public GameObject subBtns;

    public Button loadBtn;      //세이브데이터 존재시 Interactable = true;
    #endregion

    //메인메뉴
    public void OnClickNewGameBtn()
    {
        titleUI.StartNewGame();
    }

    public void OnClickLoadGameBtn()
    {

    }

    public void OnClickMoreBtn()
    {
        mainBtns.SetActive(false);
        subBtns.SetActive(true);
    }

    public void OnClickQuitBtn()
    {
        Debug.Log("Application Quit");
        Application.Quit();
    }

    //서브메뉴
    public void OnClickMainMenuBtn()
    {
        mainBtns.SetActive(true);
        subBtns.SetActive(false);
    }

    public void OnClickExpensionBtn()
    {

    }

    public void OnClickSettiingBtn()
    {
        titleUI.OpenSetting();
    }

    public void OnClickDevInfoBtn()
    {
        titleUI.OpenDevInfo();
    }
}
