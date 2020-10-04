using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerTurnPassBB : MonoBehaviour
{
    public Image characterImg;
    public Text characterName;
    
    public void OnUpdate(int _nID)
    {
        this.gameObject.SetActive(true);
        StartCoroutine(Blink());
        characterImg.sprite = DataMng.LoadCharacterScaleImage(_nID);
        characterName.text = _nID.GetCharacterTB().strName_Kor;

    }

    IEnumerator Blink()
    {
        yield return new WaitForSeconds(1);
        this.gameObject.SetActive(false);
    }

}
