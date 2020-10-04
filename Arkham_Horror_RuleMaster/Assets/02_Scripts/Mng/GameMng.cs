using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using global_define;


//어플 전반에 걸쳐서 관리하는 코드. 이펙트, 사운드조절, 화면회전 고정 등 포함
public static class GameMng
{
    public static int soundVolume = 5;
    public static int effectVolume = 5;
    public static eLanguage eLanguage;


    public static void Init()
    {
        CheckSystemLanguage();
        Debug.Log("Now Language is" + eLanguage);
    }

    static void CheckSystemLanguage()
    {
        switch (Application.systemLanguage)
        {
            case SystemLanguage.Korean:
                eLanguage = eLanguage.Korean;
                break;
            case SystemLanguage.English:
                eLanguage = eLanguage.English;
                break;
        }
    }




}
