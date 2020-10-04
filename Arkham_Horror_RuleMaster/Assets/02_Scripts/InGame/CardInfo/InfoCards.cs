using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using global_define;

public class InfoCards : MonoBehaviour
{
    public Image cardImage;
    public int cardNum;
    public Text titleTxt1;
    public Text explanationTxt1;
    public Text titleTxt2;
    public Text explanationTxt2;
    public Text titleTxt3;
    public Text explanationTxt3;

    public void ArkhamInit(int _cardNum)
    {
        cardNum = _cardNum;
        switch (GameMng.eLanguage)
        {
            case eLanguage.Korean:
                {
                    titleTxt1.text = _cardNum.GetPlaceTB().strHeadLine_1_Kor;
                    explanationTxt1.text = _cardNum.GetPlaceTB().strExplanation_1_Kor;

                    titleTxt2.text = _cardNum.GetPlaceTB().strHeadLine_2_Kor;
                    explanationTxt2.text = _cardNum.GetPlaceTB().strExplanation_2_Kor;

                    titleTxt3.text = _cardNum.GetPlaceTB().strHeadLine_3_Kor;
                    explanationTxt3.text = _cardNum.GetPlaceTB().strExplanation_3_Kor;
                    break;
                }
            case eLanguage.English:
                {
                    titleTxt1.text = _cardNum.GetPlaceTB().strHeadLine_1_Eng;
                    explanationTxt1.text = _cardNum.GetPlaceTB().strExplanation_1_Eng;

                    titleTxt2.text = _cardNum.GetPlaceTB().strHeadLine_2_Eng;
                    explanationTxt2.text = _cardNum.GetPlaceTB().strExplanation_2_Eng;

                    titleTxt3.text = _cardNum.GetPlaceTB().strHeadLine_3_Eng;
                    explanationTxt3.text = _cardNum.GetPlaceTB().strExplanation_3_Eng;
                    break;
                }
        }
        cardImage.sprite = DataMng.LoadArkhamCardImage(_cardNum);
    }

    public void OtherWorldInit(int _cardNum)
    {
        cardNum = _cardNum;

        switch (GameMng.eLanguage)
        {
            case eLanguage.Korean:
                {
                    titleTxt1.text = _cardNum.GetAbyssTB().strHeadLine_1_Kor;
                    explanationTxt1.text = _cardNum.GetAbyssTB().strExplanation_1_Kor;

                    titleTxt2.text = _cardNum.GetAbyssTB().strHeadLine_2_Kor;
                    explanationTxt2.text = _cardNum.GetAbyssTB().strExplanation_2_Kor;

                    titleTxt3.text = _cardNum.GetAbyssTB().strHeadLine_3_Kor;
                    explanationTxt3.text = _cardNum.GetAbyssTB().strExplanation_3_Kor;
                    break;
                }

            case eLanguage.English:
                {
                    titleTxt1.text = _cardNum.GetAbyssTB().strHeadLine_1_Eng;
                    explanationTxt1.text = _cardNum.GetAbyssTB().strExplanation_1_Eng;

                    titleTxt2.text = _cardNum.GetAbyssTB().strHeadLine_2_Eng;
                    explanationTxt2.text = _cardNum.GetAbyssTB().strExplanation_2_Eng;

                    titleTxt3.text = _cardNum.GetAbyssTB().strHeadLine_3_Eng;
                    explanationTxt3.text = _cardNum.GetAbyssTB().strExplanation_3_Eng;
                    break;
                }
        }

        cardImage.sprite = DataMng.LoadOtherWorldCardImage(_cardNum);
    }
}
