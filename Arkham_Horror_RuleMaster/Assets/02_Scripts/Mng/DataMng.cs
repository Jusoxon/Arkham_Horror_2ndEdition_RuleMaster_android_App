using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using global_define;
using LitJson;

#region CONFIG DB
public class ConfigDB
{
    public int nID;
    public float fValue;
}
#endregion
#region CHARACTER DB
public class CharacterDB
{
    public int nID;
    public string strName_Kor;
    public string strName_Eng;
    public int nAbility;
    public string strAbility;
    public string strImgName;
    public string strScaleImgName;
}
#endregion
#region ARKHAM DB
public class PlaceDB
{
    public int nID;
    public int eColor;
    public int nSubID1;
    public string strHeadLine_1_Kor;
    public string strHeadLine_1_Eng;
    public string strExplanation_1_Kor;
    public string strExplanation_1_Eng;

    public int nSubID2;
    public string strHeadLine_2_Kor;
    public string strHeadLine_2_Eng;
    public string strExplanation_2_Kor;
    public string strExplanation_2_Eng;

    public int nSubID3;
    public string strHeadLine_3_Kor;
    public string strHeadLine_3_Eng;
    public string strExplanation_3_Kor;
    public string strExplanation_3_Eng;

    public string strCardImg;
}
#endregion
#region OtherWorld DB
public class OtherWorldDB
{
    public int nID;
    public int eColor;
    public int nSubID1;
    public string strHeadLine_1_Kor;
    public string strHeadLine_1_Eng;
    public string strExplanation_1_Kor;
    public string strExplanation_1_Eng;
    public int nSubID2;
    public string strHeadLine_2_Kor;
    public string strHeadLine_2_Eng;
    public string strExplanation_2_Kor;
    public string strExplanation_2_Eng;
    public int nSubID3;
    public string strHeadLine_3_Kor;
    public string strHeadLine_3_Eng;
    public string strExplanation_3_Kor;
    public string strExplanation_3_Eng;
    public string strCardImg;
}
#endregion
#region MYTHOS DB
public class MythosDB
{
    public int nID;
    public string strName_Kor;
    public string strName_Eng;
    public int eCategoryID;
    public string strCategory_Kor;
    public string strCategory_Eng;
    public int eActivation;
    public string strActivation_Kor;
    public string strActivation_Eng;
    public int[] eClose;
    public string[] strClose_Kor;
    public string[] strClose_Eng;
    public int eProviso;        //필요없을것으로 예상
    public string strProviso_Kor;
    public string strProviso_Eng;
    public int eDoor;           //역시 필요없을것으로 예상
    public string strDoorName_Kor;
    public string strDoorName_Eng;
    public string strIconImg;
    public string strMonsterMoveImg;
    public string strExplanation_Kor;
    public string strExplanation_Eng;
    public string strCardImg;
}
#endregion
#region LANGUAGE DB
public class LanguageDB
{
    public string strKeyCode;
    public string Korea;
    public string English;
}
#endregion

//모든 DB파일, 어셋번들 읽어들이는 클래스.
public static class DataMng
{
    static AssetBundle dataBundles;
    static AssetBundle characterImgBundles;
    static AssetBundle cardImgBundles;
    static AssetBundle iconBundles;

    public static void Init()
    {
        LoadDataBundles();
        LoadCharacterImageBundles();
        LoadCardImageBundles();
        LoadIconImageBundles();

        LoadAllData();
    }

    public static Sprite LoadCharacterImage(int _nID)
    {
        return characterImgBundles.LoadAsset<Sprite>(_nID.GetCharacterTB().strImgName);
    }

    public static Sprite LoadCharacterScaleImage(int _nID)
    {
        return characterImgBundles.LoadAsset<Sprite>(_nID.GetCharacterTB().strScaleImgName);
    }

    public static Sprite LoadArkhamCardImage(int _nID)  //갑자기 안되는 중
    {
        return cardImgBundles.LoadAsset<Sprite>(_nID.GetPlaceTB().strCardImg);
    }

    public static Sprite LoadOtherWorldCardImage(int _nID)  //갑자기 안되는 중
    {
        return cardImgBundles.LoadAsset<Sprite>(_nID.GetAbyssTB().strCardImg);
    }

    public static Sprite LoadMythosCardImage(int _nID)
    {
        return cardImgBundles.LoadAsset<Sprite>(_nID.GetMythosTB().strCardImg);
    }

    public static Sprite LoadMythosGateImage(int _nID)
    {
        return iconBundles.LoadAsset<Sprite>(_nID.GetMythosTB().strIconImg);
    }

    public static Sprite LoadMythosMonsterMoveImage(int _nID)
    {
        return iconBundles.LoadAsset<Sprite>(_nID.GetMythosTB().strMonsterMoveImg);
    }



    //private

    static void LoadDataBundles()
    {
        dataBundles = AssetBundle.LoadFromFile(global_define.DATAPath.ASSETBUNDLE_DB_ROOT);
        Debug.Log(dataBundles == null ? "DATA Bundle Load Fail" : "DATA Bundle Load Success");
    }

    static void LoadCharacterImageBundles()
    {
        characterImgBundles = AssetBundle.LoadFromFile(global_define.DATAPath.ASSETBUNDLE_CHARACTER_IMAGE_ROOT);
        Debug.Log(characterImgBundles == null ? "CharacterImg Bundle Load Fail" : "CharacterImg Bundle Load Success");
    }

    static void LoadCardImageBundles()
    {
        cardImgBundles = AssetBundle.LoadFromFile(global_define.DATAPath.ASSETBUNDLE_CARD_IMAGE_ROOT);
        Debug.Log(cardImgBundles == null ? "CardImg Bundle Load Fail" : "CardImg Bundle Load Success");
    }

    static void LoadIconImageBundles()
    {
        iconBundles = AssetBundle.LoadFromFile(global_define.DATAPath.ASSETBUNDLE_ICON_IMAGE_ROOT);
        Debug.Log(iconBundles == null ? "IconImg Bundle Load Fail" : "IconImg Bundle Load Success");
    }

    static void LoadAllData()
    {
        for (int i = 0; i < (int)eTable.Max; i++)
        {
            LoadAssetTable((eTable)i);
        }
    }

    static void LoadAssetTable(eTable _eTable)
    {
        string assetName = "";

        switch (_eTable)
        {
            case eTable.CharacterDB:
                assetName = "CharacterDB";
                var assetCharacter = dataBundles.LoadAsset(assetName).ToString();

                List<CharacterDB> lCharacters = new List<CharacterDB>();
                lCharacters = JsonMapper.ToObject<List<CharacterDB>>(assetCharacter);

                for (int i = 0; i < lCharacters.Count; i++)
                    Table<int, CharacterDB>.SetTable(lCharacters[i].nID, lCharacters[i]);

                break;

            case eTable.PlaceDB:
                assetName = "PlaceDB";
                var assetPlace = dataBundles.LoadAsset(assetName).ToString();

                List<PlaceDB> lPlaces = new List<PlaceDB>();
                lPlaces = JsonMapper.ToObject<List<PlaceDB>>(assetPlace);

                for (int i = 0; i < lPlaces.Count; i++)
                    Table<int, PlaceDB>.SetTable(lPlaces[i].nID, lPlaces[i]);

                break;

            case eTable.OtherWorldDB:
                assetName = "OtherWorldDB";
                var assetOtherWorld = dataBundles.LoadAsset(assetName).ToString();

                List<OtherWorldDB> lOtherWorlds = new List<OtherWorldDB>();
                lOtherWorlds = JsonMapper.ToObject<List<OtherWorldDB>>(assetOtherWorld);

                for (int i = 0; i < lOtherWorlds.Count; i++)
                    Table<int, OtherWorldDB>.SetTable(lOtherWorlds[i].nID, lOtherWorlds[i]);

                break;

            case eTable.MythosDB:       
                assetName = "MythosDB";
                var assetMythos = dataBundles.LoadAsset(assetName).ToString();

                List<MythosDB> lMythos = new List<MythosDB>();

                lMythos = JsonMapper.ToObject<List<MythosDB>>(assetMythos);

                for (int i = 0; i < lMythos.Count; i++)
                    Table<int, MythosDB>.SetTable(lMythos[i].nID, lMythos[i]);

                break;

            case eTable.LanguageDB:
                assetName = "LanguageDB";
                var assetLanguage = dataBundles.LoadAsset(assetName).ToString();

                List<LanguageDB> lLanguage = new List<LanguageDB>();

                lLanguage = JsonMapper.ToObject<List<LanguageDB>>(assetLanguage);

                for (int i = 0; i < lLanguage.Count; i++)
                    Table<string, LanguageDB>.SetTable(lLanguage[i].strKeyCode, lLanguage[i]);

                break;
        }
    }
}
