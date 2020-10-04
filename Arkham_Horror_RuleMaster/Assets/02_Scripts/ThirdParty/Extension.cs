using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.ComponentModel;
using global_define;

public static class ExtensionMethod
{
    public static string ToDesc(this System.Enum a_eEnumVal)
    {
        var da = (DescriptionAttribute[])(a_eEnumVal.GetType().GetField(a_eEnumVal.ToString())).GetCustomAttributes(typeof(DescriptionAttribute), false);
        return da.Length > 0 ? da[0].Description : a_eEnumVal.ToString();
    }

    public static GameObject Instantiate_Child(this GameObject a_objParent, GameObject a_objPrefab)
    {
        GameObject objChild = GameObject.Instantiate(a_objPrefab) as GameObject;

        if (objChild != null)
        {
            objChild.transform.parent = a_objParent.transform;
            objChild.transform.localPosition = Vector3.zero;
            objChild.transform.localRotation = Quaternion.identity;
            objChild.transform.localScale = Vector3.one;
            objChild.layer = a_objParent.layer;
            objChild.name = a_objPrefab.name;
        }

        return objChild;
    }

    public static CharacterDB GetCharacterTB(this int _nID)
    {
        return Table<int, CharacterDB>.GetTable(_nID);
    }

    public static PlaceDB GetPlaceTB(this int _nID)
    {
        return Table<int, PlaceDB>.GetTable(_nID);
    }

    public static OtherWorldDB GetAbyssTB(this int _nID)
    {
        return Table<int, OtherWorldDB>.GetTable(_nID);
    }

    public static MythosDB GetMythosTB(this int _nID)
    {
        return Table<int, MythosDB>.GetTable(_nID);
    }

    public static LanguageDB GetLanguageTB(this string _keyCode)
    {
        return Table<string, LanguageDB>.GetTable(_keyCode);
    }

}
