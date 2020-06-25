using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using global_define;
using LitJson;

#region DB
public class ConfigDB
{
    int nID;
    float fIfValueD;
}
public class PlaceDB
{
    public int nID;
    public int eColor;
    public int nSubID1;
    public string strHeadLine_1;
    public string strExplanation_1;
    public int nSubID2;
    public string strHeadLine_2;
    public string strExplanation_2;
    public int nSubID3;
    public string strHeadLine_3;
    public string strExplanation_3;
}
public class AbyssDB
{
    public int nID;
    public int eColor;
    public int nSubID1;
    public string strHeadLine_1;
    public string strExplanation_1;
    public int nSubID2;
    public string strHeadLine_2;
    public string strExplanation_2;
    public int nSubID3;
    public string strHeadLine_3;
    public string strExplanation_3;
}
public class MythologyDB
{
    public int nID;
    public string strName_Kor;
    public int eID_Sub;
    public int[] eActivation;
    public int[] eClose;
    public int[] eProviso;
    public int[] eDoor;
    public int[] eMonsterMove_White;
    public int[] eMonsterMove_Black;
    public string strExplanation;
}

#endregion

public enum eTable
{
    PlaceDB,
    AbyssDB,
    MythologyDB,

    Max
}
public class DataMng : MonoBehaviour
{
    #region SINGLETON
    static DataMng _instance = null;
    public static DataMng Ins
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType(typeof(DataMng)) as DataMng;
                if (_instance == null)
                {
                    _instance = new GameObject("DataMng", typeof(DataMng)).GetComponent<DataMng>();
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

    public void LoadAllData()
    {
        for(int i = 0; i < (int)eTable.Max; i++)
        {
            LoadTable((eTable)i);
        }
    }

    void LoadTable(eTable _eTable)
    {
        string JsonString = "";
        
        switch (_eTable)
        {
            case eTable.PlaceDB:
                List<PlaceDB> lPlaces = new List<PlaceDB>();
                JsonString = File.ReadAllText(string.Format(global_define.Path.DIR_CONFIG_ROOT, "PlaceDB.Json"));
                lPlaces = JsonMapper.ToObject<List<PlaceDB>>(JsonString);
                for (int i = 0; i < lPlaces.Count; i++)
                {
                    Table<int, PlaceDB>.SetTable(lPlaces[i].nID, lPlaces[i]);
                }
                break;

            case eTable.AbyssDB:
                List<AbyssDB> lAbyss = new List<AbyssDB>();
                JsonString = File.ReadAllText(string.Format(global_define.Path.DIR_CONFIG_ROOT, "AbyssDB.Json"));
                lAbyss = JsonMapper.ToObject<List<AbyssDB>>(JsonString);
                for (int i = 0; i < lAbyss.Count; i++)
                {
                    Table<int, AbyssDB>.SetTable(lAbyss[i].nID, lAbyss[i]);
                }
                break;

            case eTable.MythologyDB:
                List<MythologyDB> lMythologys = new List<MythologyDB>();
                JsonString = File.ReadAllText(string.Format(global_define.Path.DIR_CONFIG_ROOT, "MythologyDB.Json"));
                lMythologys = JsonMapper.ToObject<List<MythologyDB>>(JsonString);
                for (int i = 0; i < lMythologys.Count; i++)
                {
                    Table<int, MythologyDB>.SetTable(lMythologys[i].nID, lMythologys[i]);
                }
                break;
        }
    
    }

}