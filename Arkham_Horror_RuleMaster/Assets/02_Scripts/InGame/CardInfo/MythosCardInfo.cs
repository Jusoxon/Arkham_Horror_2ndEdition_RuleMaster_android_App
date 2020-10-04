using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class MythosCardInfo : MonoBehaviour
{
    public Text titleTxt;
    public Text categoryTxt;
    public Text explanationTxt;
    public Text moreTxt;

    public Image gateImg;
    public Text gateTxt;

    public Image monsterMoveImg;

    public int cardNum;

    public void SettingText(int _cardNum)
    {
        cardNum = _cardNum;

        switch(GameMng.eLanguage)
        {
            case global_define.eLanguage.Korean:
                titleTxt.text = _cardNum.GetMythosTB().strName_Kor;
                categoryTxt.text = _cardNum.GetMythosTB().strCategory_Kor;
                explanationTxt.text = _cardNum.GetMythosTB().strExplanation_Kor;
                moreTxt.text = MoreTextMake(_cardNum);

                gateImg.sprite = DataMng.LoadMythosGateImage(_cardNum);
                gateTxt.text = _cardNum.GetMythosTB().strDoorName_Kor;

                monsterMoveImg.sprite = DataMng.LoadMythosMonsterMoveImage(_cardNum);
                break;

            case global_define.eLanguage.English:
                titleTxt.text = _cardNum.GetMythosTB().strName_Eng;
                categoryTxt.text = _cardNum.GetMythosTB().strCategory_Eng;
                explanationTxt.text = _cardNum.GetMythosTB().strExplanation_Eng;
                moreTxt.text = MoreTextMake(_cardNum);

                gateImg.sprite = DataMng.LoadMythosGateImage(_cardNum);
                gateTxt.text = _cardNum.GetMythosTB().strDoorName_Eng;

                monsterMoveImg.sprite = DataMng.LoadMythosMonsterMoveImage(_cardNum);
                break;
        }
    }

    string MoreTextMake(int _cardNum)
    {
        StringBuilder result = new StringBuilder();

        if(_cardNum.GetMythosTB().eActivation != 0)
        {
            switch(GameMng.eLanguage)
            {
                case global_define.eLanguage.Korean:
                    {
                        result.Append("활성화 표시:\n");
                        result.Append(_cardNum.GetMythosTB().strActivation_Kor).Append("\n\n");
                        break;
                    }

                case global_define.eLanguage.English:
                    {
                        result.Append("Activity At:\n");
                        result.Append(_cardNum.GetMythosTB().strActivation_Eng).Append("\n\n");
                        break;
                    }
            }
        }

        if (_cardNum.GetMythosTB().eClose[0] != 0)
        {
            switch (GameMng.eLanguage)
            {
                case global_define.eLanguage.Korean:
                    {
                        result.Append("폐쇄 :\n");
                        for (int i = 0; i < _cardNum.GetMythosTB().eClose.Length; i++)
                            result.Append(_cardNum.GetMythosTB().strClose_Kor[i]).Append(", ");
                        break;
                    }

                case global_define.eLanguage.English:
                    {
                        result.Append("Close :\n");
                        for (int i = 0; i < _cardNum.GetMythosTB().eClose.Length; i++)
                            result.Append(_cardNum.GetMythosTB().strClose_Eng[i]).Append(", ");
                        break;
                    }
            }
        }

        if (_cardNum.GetMythosTB().eProviso != 0)
        {
            switch (GameMng.eLanguage)
            {
                case global_define.eLanguage.Korean:
                    {
                        result.Append("단서 출현:\n");
                        result.Append(_cardNum.GetMythosTB().strProviso_Kor).Append("\n\n");
                        break;
                    }

                case global_define.eLanguage.English:
                    {
                        result.Append("Clue Appears At:\n");
                        result.Append(_cardNum.GetMythosTB().strProviso_Eng).Append("\n\n");
                        break;
                    }
            }
        }

        return result.ToString();
    }
}
