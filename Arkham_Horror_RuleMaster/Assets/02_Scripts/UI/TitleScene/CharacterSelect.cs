using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using global_define;

public class CharacterSelect : MonoBehaviour
{
    public TitleUI titleUI;
    public CharacterSelectGrid characterGrid;
    public CharacterSelectedGrid selectedGrid;

    public Button startBtn;

    public List<int> lSelectedCharacters;

    public void Init()
    {
        characterGrid.gameObject.SetActive(true);
        selectedGrid.gameObject.SetActive(true);

        characterGrid.Init();
        selectedGrid.Init();

        lSelectedCharacters.Clear();
        startBtn.gameObject.SetActive(false);
    }

    public void OnClickGameStart()
    {
        for(int i = 0; i < lSelectedCharacters.Count; i++)
        {
            PlayersMng.AddPlayers(lSelectedCharacters[i]);
        }
        
        Debug.Log("Start!");

        SceneMng.ChangeScene(eScene.InGame);
    }

    public void OnClickBackBtn()
    {
        titleUI.OpenMainMenu();
        this.gameObject.SetActive(false);
    }
}
