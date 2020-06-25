using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using global_define;

public class UI_PlaceDoubleCard : MonoBehaviour
{
    public int plcaeCardNum1;
    public int plcaeCardNum2;
    bool isCheckCard1;
    bool isCheckCard2;
    public ePlaceColor ecolor;

    public void OnClickCard1()
    {
        isCheckCard1 = true;
        if(!isCheckCard1)
        {
            RuleMaster.Ins.DoublePlace(ecolor);
        }
        
    }

    public void OnClickCard2()
    {
        isCheckCard2 = true;
        if (!isCheckCard2)
        {
            RuleMaster.Ins.DoublePlace(ecolor);
        }
    }
}
