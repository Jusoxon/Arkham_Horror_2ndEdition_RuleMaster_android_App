using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using global_define;
using JetBrains.Annotations;
using System;
using System.Linq;


public enum eCheckPhase
{
    None,
    AbyssCheck,
    MythosCheck,
    PlaceCheck
}
public enum eNowPhase
{
    MaintainPhase,
    MovePhase,
    PlaceEncounterPhase,
    AbyssEncounterPhase,
    MythologyPhase,

    End
}
public class RuleMaster : MonoBehaviour
{
    #region SINGLETON
    static RuleMaster _instance = null;
    public static RuleMaster Ins
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType(typeof(RuleMaster)) as RuleMaster;
                if (_instance == null)
                {
                    _instance = new GameObject("RuleMaster", typeof(RuleMaster)).GetComponent<RuleMaster>();
                }
            }
            return _instance;
        }
    }
    #endregion

    #region INSPECTOR
    //현재 페이즈
    public eNowPhase nowPhase;
    public eCheckPhase checkPhase = eCheckPhase.None;

    //카드를 펼쳤을 때, 해당 카드의 ID를 받아오기 위한 용도.
    public int checkPlaceCardNum;
    public int checkAbyssCardNum;
    public int checkMythosCardNum;
    public int selectSectNum;
    public bool isCheckSectNum;

    public int activeRumorNum;              //현재 적용중인 소문
    public int activeEnvironmentCityNum;    //현재 적용중인 환경(도시)
    public int activeEnvironmentWeatherNum;    //현재 적용중인 환경(날씨)
    public int activeEnvironmentMisticNum;    //현재 적용중인 환경(신비)


    //덱들
    #region DECK
    public LinkedList<int> llOrangePlaceCards = new LinkedList<int>();
    public LinkedList<int> llWhitePlaceCards = new LinkedList<int>();
    public LinkedList<int> llBlackPlaceCards = new LinkedList<int>();
    public LinkedList<int> llGreenPlaceCards = new LinkedList<int>();
    public LinkedList<int> llPurplePlaceCards = new LinkedList<int>();
    public LinkedList<int> llYellowPlaceCards = new LinkedList<int>();
    public LinkedList<int> llBluePlaceCards = new LinkedList<int>();
    public LinkedList<int> llRedPlaceCards = new LinkedList<int>();
    public LinkedList<int> llBrownPlaceCards = new LinkedList<int>();
    public Queue<int> qAbyssCards = new Queue<int>();
    public Queue<int> qMythosCards = new Queue<int>();
    #endregion

    #endregion

    static int totalMythosCardCount = 67;
    static int totalAbyssCardCount = 49;
    static int totalPlaceCardCount = 63;

    private void Start()
    {
        Init();
        Debug.Log("start!!");
    }

    void Init()
    {
        nowPhase = eNowPhase.MaintainPhase;
        UI_General.Ins.UI_RuleMaster.OpenPhaseUI((int)nowPhase);

        RandomAbyssCardGenerate(totalAbyssCardCount);
        RandomMythosCardGenerate(totalMythosCardCount);
        RandomPlaceCardGenerate(totalPlaceCardCount);
    }
    void CheckNowPhase()
    {
        if (nowPhase >= eNowPhase.End)
            nowPhase = eNowPhase.MaintainPhase;
    }

    #region CardSetting
    public void RandomPlaceCardGenerate(int _endNum)
    {
        int[] generateResult = RandomShuffle(_endNum);
        for (int i = 0; i < _endNum; i++)
        {
            PlaceCardInit(generateResult[i]);
        }
    }

    public void RandomAbyssCardGenerate(int _endNum)
    {
        qAbyssCards.Clear();
        int[] generateResult = RandomShuffle(_endNum);

        for (int i = 0; i < _endNum; i++)
        {
            qAbyssCards.Enqueue(generateResult[i]);
        }
    }

    public void RandomMythosCardGenerate(int _endNum)
    {
        qMythosCards.Clear();
        int[] generateResult = RandomShuffle(_endNum);

        for (int i = 0; i < _endNum; i++)
        {
            qMythosCards.Enqueue(generateResult[i]);
        }

    }

    int[] RandomShuffle(int _endNum)
    {
        System.Random _rand = new System.Random((int)DateTime.Now.Ticks);
        int[] result = Enumerable.Range(1, _endNum).ToArray();
        int index, old;
        for (int i = 0; i < _endNum; i++)
        {
            index = _rand.Next(_endNum);
            old = result[i];
            result[i] = result[index];
            result[index] = old;
        }
        return result;
    }

    void PlaceCardInit(int _nID)
    {
        int check = _nID.GetPlaceTB().eColor;
        switch ((ePlaceColor)check)
        {
            case ePlaceColor.Orange:
                {
                    llOrangePlaceCards.AddLast(_nID);
                    break;
                }
            case ePlaceColor.White:
                {
                    llWhitePlaceCards.AddLast(_nID);
                    break;
                }
            case ePlaceColor.Black:
                {
                    llBlackPlaceCards.AddLast(_nID);
                    break;
                }
            case ePlaceColor.Green:
                {
                    llGreenPlaceCards.AddLast(_nID);
                    break;
                }
            case ePlaceColor.Purple:
                {
                    llPurplePlaceCards.AddLast(_nID);
                    break;
                }
            case ePlaceColor.Yellow:
                {
                    llYellowPlaceCards.AddLast(_nID);
                    break;
                }
            case ePlaceColor.Blue:
                {
                    llBluePlaceCards.AddLast(_nID);
                    break;
                }
            case ePlaceColor.Red:
                {
                    llRedPlaceCards.AddLast(_nID);
                    break;
                }
            case ePlaceColor.Brown:
                {
                    llBrownPlaceCards.AddLast(_nID);
                    break;
                }
        }
    }

    #endregion

    void OpenPlaceCard(int _color)
    {
        switch ((ePlaceColor)_color)
        {
            case ePlaceColor.Orange:
                {
                    llOrangePlaceCards.AddLast(llOrangePlaceCards.First.Value);
                    checkPlaceCardNum = llOrangePlaceCards.First.Value;
                    llOrangePlaceCards.RemoveFirst();
                    break;
                }
            case ePlaceColor.White:
                {
                    llWhitePlaceCards.AddLast(llWhitePlaceCards.First.Value);
                    checkPlaceCardNum = llWhitePlaceCards.First.Value;
                    llWhitePlaceCards.RemoveFirst();
                    break;
                }
            case ePlaceColor.Black:
                {
                    llBlackPlaceCards.AddLast(llBlackPlaceCards.First.Value);
                    checkPlaceCardNum = llBlackPlaceCards.First.Value;
                    llBlackPlaceCards.RemoveFirst();
                    break;
                }
            case ePlaceColor.Green:
                {
                    llGreenPlaceCards.AddLast(llGreenPlaceCards.First.Value);
                    checkPlaceCardNum = llGreenPlaceCards.First.Value;
                    llGreenPlaceCards.RemoveFirst();
                    break;
                }
            case ePlaceColor.Purple:
                {
                    llPurplePlaceCards.AddLast(llPurplePlaceCards.First.Value);
                    checkPlaceCardNum = llPurplePlaceCards.First.Value;
                    llPurplePlaceCards.RemoveFirst();
                    break;
                }
            case ePlaceColor.Yellow:
                {
                    llYellowPlaceCards.AddLast(llYellowPlaceCards.First.Value);
                    checkPlaceCardNum = llYellowPlaceCards.First.Value;
                    llYellowPlaceCards.RemoveFirst();
                    break;
                }
            case ePlaceColor.Blue:
                {
                    llBluePlaceCards.AddLast(llBluePlaceCards.First.Value);
                    checkPlaceCardNum = llBluePlaceCards.First.Value;
                    llBluePlaceCards.RemoveFirst();
                    break;
                }
            case ePlaceColor.Red:
                {
                    llRedPlaceCards.AddLast(llRedPlaceCards.First.Value);
                    checkPlaceCardNum = llRedPlaceCards.First.Value;
                    llRedPlaceCards.RemoveFirst();
                    break;
                }
            case ePlaceColor.Brown:
                {
                    llBrownPlaceCards.AddLast(llBrownPlaceCards.First.Value);
                    checkPlaceCardNum = llBrownPlaceCards.First.Value;
                    llBrownPlaceCards.RemoveFirst();
                    break;
                }
        }

        UI_General.Ins.UI_RuleMaster.UI_CardInfo.UI_CardInfoInit(nowPhase, checkPlaceCardNum);
    }


    //특별한 경우의 카드들이 있음... 그것들에 대한 예외처리를 위한 함수
    public void CheckExceptionCard()
    {
        switch(nowPhase)
        {
            //겁나 많이 있을 예정
            case eNowPhase.PlaceEncounterPhase:
                {
                    //check num and selectSect
                    switch (selectSectNum)
                    {
                        case 1:
                            {
                                if (checkPlaceCardNum == 6 || checkPlaceCardNum == 7)
                                {
                                    UI_General.Ins.UI_SystemMessage.MessageInit(eMessageCheck.IsSuccess);
                                }

                                //응할 것인지 말지에 대한 UI설계, 응한다면 검은동굴, 숲이 있는 장소카드 2장을 뽑고 둘 중 하나를 선택하도록 하는 함수,UI설계
                                else if (checkPlaceCardNum == 61 || checkPlaceCardNum == 62)
                                {
                                    UI_General.Ins.UI_SystemMessage.MessageInit(eMessageCheck.IsSure);
                                }

                                //응할지 말지 설계, 성공인지 실패인지에 대한 UI설계, 실패한다면 어비스카드 오픈
                                else if (checkPlaceCardNum == 63)
                                {
                                    UI_General.Ins.UI_SystemMessage.MessageInit(eMessageCheck.IsSure);
                                }
                                break;
                            }

                        case 2:
                            {
                                //성공이나 실패나 둘 다 다른세계 조우
                                if (checkPlaceCardNum == 36 || checkPlaceCardNum == 62)
                                {
                                    UI_General.Ins.UI_RuleMaster.OpenAbyssUI();
                                    UI_General.Ins.UI_RuleMaster.ClosePlaceUI();
                                    checkPhase = eCheckPhase.AbyssCheck;
                                    isCheckSectNum = true;
                                }

                                //실버 트와일 라이트가 있는 장소카드 2장을 뽑고 둘 중 하나를 선택하도록 하는 함수,UI설계
                                else if (checkPlaceCardNum == 63)
                                {
                                    //UI_General.Ins.UI_SystemMessage.MessageInit(eMessageCheck.IsSure);
                                }
                                break;
                            }

                        case 3:
                            {
                                if (checkPlaceCardNum == 14)
                                {
                                    UI_General.Ins.UI_SystemMessage.MessageInit(eMessageCheck.IsSuccess);
                                }

                                //아컴 조우 미래가 고정. 장소조우 카드한장을 뽑고, AddFirst(), RemoveLast()로 다시 고정, 이것을 UI상에서 확인할 수 있도록 구현필요, 구분 가능하도록 하는 것 또한 필요. 제일 마지막 부분이 난제.
                                else if (checkPlaceCardNum == 50)
                                {
                                    
                                    isCheckSectNum = true;
                                }
                                break;
                            }
                    }
                    break;
                }

            case eNowPhase.AbyssEncounterPhase:
                {
                    if (checkMythosCardNum == 1)
                        RandomAbyssCardGenerate(totalAbyssCardCount);
                    break;
                }

            case eNowPhase.MythologyPhase:
                {
                    if (checkMythosCardNum == 1)
                    {
                        RandomMythosCardGenerate(totalMythosCardCount);
                        activeRumorNum = 0;
                        activeEnvironmentCityNum = 0;
                        activeEnvironmentWeatherNum = 0;
                        activeEnvironmentMisticNum = 0;
                    }

                    else if ((eMythosCategory)checkMythosCardNum.GetMythologyTB().eID_Sub == eMythosCategory.Environment_City)
                        activeEnvironmentCityNum = checkMythosCardNum;

                    else if ((eMythosCategory)checkMythosCardNum.GetMythologyTB().eID_Sub == eMythosCategory.Environment_Weather)
                        activeEnvironmentWeatherNum = checkMythosCardNum;

                    else if ((eMythosCategory)checkMythosCardNum.GetMythologyTB().eID_Sub == eMythosCategory.Environment_Mistic)
                        activeEnvironmentMisticNum = checkMythosCardNum;

                    else if ((eMythosCategory)checkMythosCardNum.GetMythologyTB().eID_Sub == eMythosCategory.Rumor && activeRumorNum == 0)
                        activeRumorNum = checkMythosCardNum;

                    break;
                }
        }

        UI_General.Ins.UI_Alert.CheckAlertUI(activeRumorNum, activeEnvironmentCityNum, activeEnvironmentWeatherNum, activeEnvironmentMisticNum);
        selectSectNum = 0;
    }

    public void DoublePlace(ePlaceColor _color)
    {
        int _check = 0;
        switch ((ePlaceColor)_color)
        {
            case ePlaceColor.Orange:
                {
                    llOrangePlaceCards.AddLast(llOrangePlaceCards.First.Value);
                    _check = llOrangePlaceCards.First.Value;
                    llOrangePlaceCards.RemoveFirst();
                    break;
                }
            case ePlaceColor.White:
                {
                    llWhitePlaceCards.AddLast(llWhitePlaceCards.First.Value);
                    _check = llWhitePlaceCards.First.Value;
                    llWhitePlaceCards.RemoveFirst();
                    break;
                }
            case ePlaceColor.Black:
                {
                    llBlackPlaceCards.AddLast(llBlackPlaceCards.First.Value);
                    _check = llBlackPlaceCards.First.Value;
                    llBlackPlaceCards.RemoveFirst();
                    break;
                }
            case ePlaceColor.Green:
                {
                    llGreenPlaceCards.AddLast(llGreenPlaceCards.First.Value);
                    _check = llGreenPlaceCards.First.Value;
                    llGreenPlaceCards.RemoveFirst();
                    break;
                }
            case ePlaceColor.Purple:
                {
                    llPurplePlaceCards.AddLast(llPurplePlaceCards.First.Value);
                    _check = llPurplePlaceCards.First.Value;
                    llPurplePlaceCards.RemoveFirst();
                    break;
                }
            case ePlaceColor.Yellow:
                {
                    llYellowPlaceCards.AddLast(llYellowPlaceCards.First.Value);
                    _check = llYellowPlaceCards.First.Value;
                    llYellowPlaceCards.RemoveFirst();
                    break;
                }
            case ePlaceColor.Blue:
                {
                    llBluePlaceCards.AddLast(llBluePlaceCards.First.Value);
                    _check = llBluePlaceCards.First.Value;
                    llBluePlaceCards.RemoveFirst();
                    break;
                }
            case ePlaceColor.Red:
                {
                    llRedPlaceCards.AddLast(llRedPlaceCards.First.Value);
                    _check = llRedPlaceCards.First.Value;
                    llRedPlaceCards.RemoveFirst();
                    break;
                }
            case ePlaceColor.Brown:
                {
                    llBrownPlaceCards.AddLast(llBrownPlaceCards.First.Value);
                    _check = llBrownPlaceCards.First.Value;
                    llBrownPlaceCards.RemoveFirst();
                    break;
                }
        }

        UI_General.Ins.UI_RuleMaster.UI_CardInfo.UI_CardInfoInit(eNowPhase.PlaceEncounterPhase, _check);
    }
    //마우스 클릭 함수
    #region OnClickFunction
    public void OnClickNextPhase()
    {
        nowPhase++;
        CheckNowPhase();
        UI_General.Ins.UI_RuleMaster.OpenPhaseUI((int)nowPhase);
    }

    public void OnClickCardOpenBtn(int _color)
    {
        if(isCheckSectNum)
        {
            switch(checkPhase)
            {
                case eCheckPhase.AbyssCheck:
                    {
                        checkAbyssCardNum = qAbyssCards.Dequeue();
                        UI_General.Ins.UI_RuleMaster.UI_CardInfo.UI_CardInfoInit(eNowPhase.AbyssEncounterPhase, checkAbyssCardNum);
                        break;
                    }

                case eCheckPhase.MythosCheck:
                    {
                        checkMythosCardNum = qMythosCards.Dequeue();
                        UI_General.Ins.UI_RuleMaster.UI_CardInfo.UI_CardInfoInit(eNowPhase.MythologyPhase, checkMythosCardNum);
                        break;
                    }

                case eCheckPhase.PlaceCheck:
                    {

                        break;
                    }
            }
        }
        else
        {
            switch (nowPhase)
            {
                case eNowPhase.PlaceEncounterPhase:
                    {
                        OpenPlaceCard(_color);
                        break;
                    }

                case eNowPhase.AbyssEncounterPhase:
                    {
                        checkAbyssCardNum = qAbyssCards.Dequeue();
                        UI_General.Ins.UI_RuleMaster.UI_CardInfo.UI_CardInfoInit(nowPhase, checkAbyssCardNum);
                        break;
                    }

                case eNowPhase.MythologyPhase:
                    {
                        checkMythosCardNum = qMythosCards.Dequeue();
                        UI_General.Ins.UI_RuleMaster.UI_CardInfo.UI_CardInfoInit(nowPhase, checkMythosCardNum);
                        break;
                    }
            }
        }

    }

    #endregion
}
