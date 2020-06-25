using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using global_define;
using System.Text;

public enum eMythosCardInfoSequence
{
    Avtive,
    Close,
    Proviso,
    Door
}
public class UI_MythosCardInfo : MonoBehaviour, ICardInfoSetting
{
    #region INSPECTOR
    public Text headLineTxt;
    public Text subLineTxt;
    public Text explanationTxt;
    public Text activeTxt;
    public Text closeTxt;
    public Text provisoTxt;
    public Text doorTxt;
    public Image doorImg;

    public List<Image> lWhiteMonsterMove;
    public List<Image> lBlackMonsterMove;


    #endregion

    public void CardInfoSetting(int _cardNum)
    {
        //텍스트 세팅
        headLineTxt.text = _cardNum.GetMythologyTB().strName_Kor;
        subLineTxt.text = ((eMythosCategory)_cardNum.GetMythologyTB().eID_Sub).ToString();
        explanationTxt.text = _cardNum.GetMythologyTB().strExplanation;
        activeTxt.text = ArrayToString(eMythosCardInfoSequence.Avtive, _cardNum);
        closeTxt.text = ArrayToString(eMythosCardInfoSequence.Close, _cardNum);
        provisoTxt.text = ArrayToString(eMythosCardInfoSequence.Proviso, _cardNum);
        doorTxt.text = ArrayToString(eMythosCardInfoSequence.Door, _cardNum);

        //이미지는 아직 이미지파일도 없고, 데이터베이스 안에 넣어놓지 않아서 현재는 미구현
    }

    string ArrayToString(eMythosCardInfoSequence _s, int _cardNum)
    {
        StringBuilder result = new StringBuilder();

        switch(_s)
        {
            case eMythosCardInfoSequence.Avtive:
                {
                    result.Append("활성화 지역 : ");
                    for(int i = 0; i < _cardNum.GetMythologyTB().eActivation.Length; i++)
                    {
                        result.Append(((ePlace)_cardNum.GetMythologyTB().eActivation[i]).ToString());
                        if(i != _cardNum.GetMythologyTB().eActivation.Length - 1)
                            result.Append(", ");
                    }
                    break;
                }
            case eMythosCardInfoSequence.Close:
                {
                    result.Append("폐쇄 지역 : ");
                    for (int i = 0; i < _cardNum.GetMythologyTB().eClose.Length; i++)
                    {
                        result.Append(((ePlace)_cardNum.GetMythologyTB().eClose[i]).ToString());
                        if (i != _cardNum.GetMythologyTB().eClose.Length - 1)
                            result.Append(", ");
                    }
                    break;
                }
            case eMythosCardInfoSequence.Proviso:
                {
                    result.Append("단서 마커 : ");
                    for (int i = 0; i < _cardNum.GetMythologyTB().eProviso.Length; i++)
                    {
                        result.Append(((ePlace)_cardNum.GetMythologyTB().eProviso[i]).ToString());
                        if (i != _cardNum.GetMythologyTB().eProviso.Length - 1)
                            result.Append(", ");
                    }
                    break;
                }
            case eMythosCardInfoSequence.Door:
                {
                    result.Append("차원문 : ");
                    for (int i = 0; i < _cardNum.GetMythologyTB().eDoor.Length; i++)
                    {
                        result.Append(((ePlace)_cardNum.GetMythologyTB().eDoor[i]).ToString());
                        if (i != _cardNum.GetMythologyTB().eDoor.Length - 1)
                            result.Append(", ");
                    }
                    break;
                }
        }

        return result.ToString();
    }
}
