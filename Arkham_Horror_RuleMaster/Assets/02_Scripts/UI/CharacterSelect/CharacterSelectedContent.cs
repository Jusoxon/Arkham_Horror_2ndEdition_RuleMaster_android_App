using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectedContent : MonoBehaviour
{
    public Image characterImg;
    public int nID;

    public void Init(int _nID)
    {
        nID = _nID;

    }
}
