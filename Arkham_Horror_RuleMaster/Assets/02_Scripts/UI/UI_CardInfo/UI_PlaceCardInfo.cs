using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using global_define;

public class UI_PlaceCardInfo : MonoBehaviour, ICardInfoSetting
{
    public Text headline1;
    public Text explanation1;
    public Text headline2;
    public Text explanation2;
    public Text headline3;
    public Text explanation3;

    public void CardInfoSetting(int _cardNum)
    {
        headline1.text = _cardNum.GetPlaceTB().strHeadLine_1;
        explanation1.text = _cardNum.GetPlaceTB().strExplanation_1;
        headline2.text = _cardNum.GetPlaceTB().strHeadLine_2;
        explanation2.text = _cardNum.GetPlaceTB().strExplanation_2;
        headline3.text = _cardNum.GetPlaceTB().strHeadLine_3;
        explanation3.text = _cardNum.GetPlaceTB().strExplanation_3;
    }
}
