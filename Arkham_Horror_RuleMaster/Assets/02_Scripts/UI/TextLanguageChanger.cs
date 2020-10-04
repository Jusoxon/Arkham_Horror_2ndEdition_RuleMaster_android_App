using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using global_define;

public class TextLanguageChanger : MonoBehaviour
{
    Text txt;
    public string keyCode;

    private void Awake()
    {
        txt = GetComponent<Text>();
    }
    private void Start()
    {
        Setup(GameMng.eLanguage);
    }

    public void OnEnable()
    {
        Setup(GameMng.eLanguage);
    }

    void Setup(eLanguage _eLanguage)
    {
        switch(_eLanguage)
        {
            case eLanguage.Korean:
                txt.text = keyCode.GetLanguageTB().Korea;
                break;
            case eLanguage.English:
                txt.text = keyCode.GetLanguageTB().English;
                break;
        }
        
    }
}
