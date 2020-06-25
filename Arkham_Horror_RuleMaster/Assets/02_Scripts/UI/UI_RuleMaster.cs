using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_RuleMaster : MonoBehaviour
{
    public List<GameObject> lUIPhase;

    public UI_CardInfo UI_CardInfo;

    public void OpenPhaseUI(int _num)
    {
        for(int i = 0; i < lUIPhase.Count; i++)
        {
            if (i == _num)
                lUIPhase[i].gameObject.SetActive(true);
            else
                lUIPhase[i].gameObject.SetActive(false);
        }
    }

    public void OpenMythosUI()
    {
        lUIPhase[4].gameObject.SetActive(true);
    }
    public void CloseMythosUI()
    {
        lUIPhase[4].gameObject.SetActive(false);
    }

    public void OpenAbyssUI()
    {
        lUIPhase[3].gameObject.SetActive(true);
    }
    public void CloseAbyssUI()
    {
        lUIPhase[3].gameObject.SetActive(false);
    }

    public void OpenPlaceUI()
    {
        lUIPhase[2].gameObject.SetActive(true);
    }
    public void ClosePlaceUI()
    {
        lUIPhase[2].gameObject.SetActive(false);
    }

    public void OpenPlaceDoubleUI()
    {
        UI_General.Ins.UI_RuleMaster.UI_CardInfo.UI_PlaceDoubleCard.gameObject.SetActive(true);
    }

    public void ClosePlaceDoubleUI()
    {
        UI_General.Ins.UI_RuleMaster.UI_CardInfo.UI_PlaceDoubleCard.gameObject.SetActive(false);
    }
}
