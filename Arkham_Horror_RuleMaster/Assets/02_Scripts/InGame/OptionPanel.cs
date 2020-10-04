using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using global_define;

public class OptionPanel : MonoBehaviour
{
    public Slider soundSlider;
    public Slider effectSlider;

    public TextLanguageChanger soundTxt;
    public TextLanguageChanger effectTxt;
    public TextLanguageChanger languageTxt;
    public TextLanguageChanger languageBtnTxt;
    public TextLanguageChanger applyTxt;

    public void OnClickApplyBtn()
    {
        this.gameObject.SetActive(false);
    }

    public void OnClickLanguageBtn()
    {
        GameMng.eLanguage += 1;
        if ((int)GameMng.eLanguage > 1)
            GameMng.eLanguage = eLanguage.Korean;

        soundTxt.OnEnable();
        effectTxt.OnEnable();
        languageTxt.OnEnable();
        languageBtnTxt.OnEnable();
        applyTxt.OnEnable();

        Debug.Log("Now Language : " + GameMng.eLanguage);
    }
}
