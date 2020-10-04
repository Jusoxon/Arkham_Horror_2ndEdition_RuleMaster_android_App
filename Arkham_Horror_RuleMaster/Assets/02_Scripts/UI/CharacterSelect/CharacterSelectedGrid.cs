using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectedGrid : MonoBehaviour
{
    public CharacterSelect characterSelect;
    public CharacterSelectGrid characterGrid;
    public GameObject mainFrame;
    public GameObject subFrame;

    public List<CharacterSelectedContent> lSelectedCharacters;

    public void Init()
    {
        mainFrame.SetActive(true);
        subFrame.SetActive(false);

        for (int i = 0; i < lSelectedCharacters.Count; i++)
            lSelectedCharacters[i].gameObject.SetActive(false);
    }

    public void OnUpdate()
    {
        if (characterSelect.lSelectedCharacters.Count > 4)
            subFrame.SetActive(true);
        else
            subFrame.SetActive(false);

        for(int i = 0; i < characterSelect.lSelectedCharacters.Count; i++)
        {
            lSelectedCharacters[i].gameObject.SetActive(true);
            lSelectedCharacters[i].Init(characterSelect.lSelectedCharacters[i]);
            lSelectedCharacters[i].characterImg.sprite = DataMng.LoadCharacterImage(lSelectedCharacters[i].nID);
        }
        if(characterSelect.lSelectedCharacters.Count > 0 )
            characterSelect.startBtn.gameObject.SetActive(true);
        else
            characterSelect.startBtn.gameObject.SetActive(false);
    }
}
