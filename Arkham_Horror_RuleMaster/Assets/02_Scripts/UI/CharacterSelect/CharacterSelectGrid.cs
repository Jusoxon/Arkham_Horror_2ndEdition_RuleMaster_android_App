using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectGrid : MonoBehaviour
{
    public CharacterSelectedGrid characterSelected;
    public List<CharacterContent> lContents;

    public void Init()
    {

        for(int i = 0; i < lContents.Count; i++)
        {
            lContents[i].nID = i + 1;
            lContents[i].Init();
            lContents[i].characterImg.sprite = DataMng.LoadCharacterImage(lContents[i].nID);
            lContents[i].GetComponent<Button>().interactable = true;
        }
    }

}
