using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public enum eLanguage
{
    Korean,
    English,

    Max
}
//주로 게임설정 등을 조작하고, 저장/불러오기 하도록 한다.
public class GameMng : MonoBehaviour
{
    #region SINGLETON
    static GameMng _instance = null;
    public static GameMng Ins
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType(typeof(GameMng)) as GameMng;
                if (_instance == null)
                {
                    _instance = new GameObject("GameMng", typeof(GameMng)).GetComponent<GameMng>();
                }
            }
            return _instance;
        }
    }
    public void Awake()
    {
        DontDestroyOnLoad(this);
    }
    #endregion

    [Range(0,100)]
    public int musicVolume = 50;
    public bool isMusicMute = false;

    [Range(0,100)]
    public int soundVolume = 50;
    public bool isSoundMute = false;

    public eLanguage language = eLanguage.Korean;
    int languageNum = 0;

    private void Start()
    {
        LoadGameMng();
        //풀어주면 데이터 받기 시작
        DataMng.Ins.LoadAllData();
    }

    public void OnClickLanguage()
    {
        language++;
        if (language >= eLanguage.Max)
            language = eLanguage.Korean;

        language = (eLanguage)languageNum;
    }

    //기본 설정 저장용.
    public void SaveGameMng()
    {

    }
    public void LoadGameMng()
    {

    }
}
