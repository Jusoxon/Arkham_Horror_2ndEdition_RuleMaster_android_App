using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterContent : MonoBehaviour
{

    public Image characterImg;
    public Text characterNameTxt;

    public CharacterSelect characterSelect;
    
    public int nID;
    public string characterName;

    public void Init()
    {
        switch(GameMng.eLanguage)
        {
            case global_define.eLanguage.Korean:
                characterName = nID.GetCharacterTB().strName_Kor;
                break;
            case global_define.eLanguage.English:
                characterName = nID.GetCharacterTB().strName_Eng;
                break;
        }
        characterNameTxt.text = characterName;
    }

    public void OnClickCharacterBtn()
    {
        if(characterSelect.lSelectedCharacters.Count < 8)
        {
            characterSelect.lSelectedCharacters.Add(nID);
            GetComponent<Button>().interactable = false;
            characterSelect.selectedGrid.OnUpdate();
        }

    }
}
