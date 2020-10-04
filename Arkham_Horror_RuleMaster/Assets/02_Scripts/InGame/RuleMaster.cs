using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using global_define;

public class RuleMaster : MonoBehaviour
{
    #region ENUMS
    public enum eNowPhase
    {
        Maintain_Phase,
        Move_Phase,
        ArkhamEncounter_Phase,
        OtherWorldEncounter_Phase,
        Mythos_Phase,

        End
    }
    #endregion
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

    const int totalArkhamEncounterCardCount = 63;
    const int totalOtherWorldEncounterCardCount = 49;
    const int totalMythosCardCount = 67;

    eNowPhase nowPhase;

    public bool isOtherModeCheck;        //아컴조우단계에서 다른세계조우를 처리해야하는 경우

    //아컴조우, 다른세계조우시 해당 카드를 클릭함으로 우선 이 리스트에 정보가 담기는 방식
    public List<int> lArkhamCard = new List<int>();
    public List<int> lOtherWorldCard = new List<int>();
    public int nowMythosCard;

    #region DECK
    //아컴 조우카드
    public LinkedList<int> llOrangePlaceCards = new LinkedList<int>();
    public LinkedList<int> llWhitePlaceCards = new LinkedList<int>();
    public LinkedList<int> llBlackPlaceCards = new LinkedList<int>();
    public LinkedList<int> llGreenPlaceCards = new LinkedList<int>();
    public LinkedList<int> llPurplePlaceCards = new LinkedList<int>();
    public LinkedList<int> llYellowPlaceCards = new LinkedList<int>();
    public LinkedList<int> llBluePlaceCards = new LinkedList<int>();
    public LinkedList<int> llRedPlaceCards = new LinkedList<int>();
    public LinkedList<int> llBrownPlaceCards = new LinkedList<int>();
    //다른세계조우카드
    public LinkedList<int> llOtherWorldCards = new LinkedList<int>();
    //신화 카드
    public LinkedList<int> llMythosCards = new LinkedList<int>();
    #endregion

    //최초 1회만 호출
    public void Init()
    {
        ShuffleArkhamEncounterDeck();
        ShuffleOtherWorldDeck();
        ShuffleMythosDeck();
    }

    public eNowPhase CheckNowPhase()
    {
        return nowPhase;
    }

    public void NextPhase()
    {
        nowPhase++;
        if (nowPhase >= eNowPhase.End)
            nowPhase = eNowPhase.Maintain_Phase;
    }

    #region CARD DRAW
    public void ArkhamEncounterCardDraw(int _nowPlayer, int _card, int _count = 0)
    {
        ePlaceColor check = (ePlaceColor)_card;

        int drawCardCount = _count;

        lArkhamCard.Clear();

        switch(check)
        {
            case ePlaceColor.Orange:
                {
                    if (_nowPlayer.GetCharacterTB().nAbility == (int)eAbility.DoublePlaceDraw)
                    {
                        drawCardCount += 2;
                        DrawCard(llOrangePlaceCards, lArkhamCard, drawCardCount);
                    }
                    else
                    {
                        drawCardCount += 1;
                        DrawCard(llOrangePlaceCards, lArkhamCard, drawCardCount);
                    }
                    break;
                }

            case ePlaceColor.White:
                {
                    if (_nowPlayer.GetCharacterTB().nAbility == (int)eAbility.DoublePlaceDraw)
                    {
                        drawCardCount += 2;
                        DrawCard(llWhitePlaceCards, lArkhamCard, drawCardCount);
                    }
                    else
                    {
                        drawCardCount += 1;
                        DrawCard(llWhitePlaceCards, lArkhamCard, drawCardCount);
                    }
                    break;
                }

            case ePlaceColor.Black:
                {
                    if (_nowPlayer.GetCharacterTB().nAbility == (int)eAbility.DoublePlaceDraw)
                    {
                        drawCardCount += 2;
                        DrawCard(llBlackPlaceCards, lArkhamCard, drawCardCount);
                    }
                    else
                    {
                        drawCardCount += 1;
                        DrawCard(llBlackPlaceCards, lArkhamCard, drawCardCount);
                    }
                    break;
                }

            case ePlaceColor.Green:
                {
                    if (_nowPlayer.GetCharacterTB().nAbility == (int)eAbility.DoublePlaceDraw)
                    {
                        drawCardCount += 2;
                        DrawCard(llGreenPlaceCards, lArkhamCard, drawCardCount);
                    }
                    else
                    {
                        drawCardCount += 1;
                        DrawCard(llGreenPlaceCards, lArkhamCard, drawCardCount);
                    }
                    break;
                }

            case ePlaceColor.Purple:
                {
                    if (_nowPlayer.GetCharacterTB().nAbility == (int)eAbility.DoublePlaceDraw)
                    {
                        drawCardCount += 2;
                        DrawCard(llPurplePlaceCards, lArkhamCard, drawCardCount);
                    }
                    else
                    {
                        drawCardCount += 1;
                        DrawCard(llPurplePlaceCards, lArkhamCard, drawCardCount);
                    }
                    break;
                }

            case ePlaceColor.Yellow:
                {
                    if (_nowPlayer.GetCharacterTB().nAbility == (int)eAbility.DoublePlaceDraw)
                    {
                        drawCardCount += 2;
                        DrawCard(llYellowPlaceCards, lArkhamCard, drawCardCount);
                    }
                    else
                    {
                        drawCardCount += 1;
                        DrawCard(llYellowPlaceCards, lArkhamCard, drawCardCount);
                    }
                    break;
                }

            case ePlaceColor.Blue:
                {
                    if (_nowPlayer.GetCharacterTB().nAbility == (int)eAbility.DoublePlaceDraw)
                    {
                        drawCardCount += 2;
                        DrawCard(llBluePlaceCards, lArkhamCard, drawCardCount);
                    }
                    else
                    {
                        drawCardCount += 1;
                        DrawCard(llBluePlaceCards, lArkhamCard, drawCardCount);
                    }
                    break;
                }

            case ePlaceColor.Red:
                {
                    if (_nowPlayer.GetCharacterTB().nAbility == (int)eAbility.DoublePlaceDraw)
                    {
                        drawCardCount += 2;
                        DrawCard(llRedPlaceCards, lArkhamCard, drawCardCount);
                    }
                    else
                    {
                        drawCardCount += 1;
                        DrawCard(llRedPlaceCards, lArkhamCard, drawCardCount);
                    }
                    break;
                }

            case ePlaceColor.Brown:
                {
                    if (_nowPlayer.GetCharacterTB().nAbility == (int)eAbility.DoublePlaceDraw)
                    {
                        drawCardCount += 2;
                        DrawCard(llBrownPlaceCards, lArkhamCard, drawCardCount);
                    }
                    else
                    {
                        drawCardCount += 1;
                        DrawCard(llBrownPlaceCards, lArkhamCard, drawCardCount);
                    }
                    break;
                }
        }
    }

    public void OtherWorldEncounterCardDraw(int _nowPlayer, int _drawCount = 0)
    {
        int drawCount = _drawCount;
        lOtherWorldCard.Clear();

        if (_nowPlayer.GetCharacterTB().nAbility == (int)eAbility.DoubleOtherWorldDraw)
        {
            drawCount += 2;
            DrawCard(llOtherWorldCards, lOtherWorldCard, drawCount);
        }
        else
        {
            drawCount += 1;
            DrawCard(llOtherWorldCards, lOtherWorldCard, drawCount);
        }
    }

    public void MythosEncounterCardDraw()
    {
        int cardNum = llMythosCards.First.Value;

        if(cardNum == 1 && nowPhase == eNowPhase.Mythos_Phase)
        {
            nowMythosCard = cardNum;
            ShuffleMythosDeck();
        }
        else
        {
            nowMythosCard = cardNum;
            llMythosCards.RemoveFirst();
            llMythosCards.AddLast(cardNum);
        }
    }

    void DrawCard(LinkedList<int> _llCheck, List<int> _lGetCard, int _count)
    {
        for(int i = 0; i < _count; i++)
        {
            int cardNum = _llCheck.First.Value;
            if (cardNum == 1 && nowPhase == eNowPhase.OtherWorldEncounter_Phase)
            {
                _lGetCard.Add(cardNum);
                ShuffleOtherWorldDeck();
            }
            else
            {
                _llCheck.RemoveFirst();
                _llCheck.AddLast(cardNum);

                _lGetCard.Add(cardNum);
            }
        }
    }

    #endregion

    //    //장소
    //    //6-1 : 강제 - 실패시 - 신화카드 뽑고, 다시 장소카드 뽑기                          = 성공하셨습니까 창 -> NoBtn -> MythosOpen
    //    //7-1 : 강제 - 실패시 - 어비스 색깔 카드 조우 끝                                   = 성공하셨습니까 창 -> NoBtn -> OtherWorldOpen
    //    //36-2 : 강제 - 드림랜드 색깔 카드 조우 끝                                         = OtherWorldOpen
    //    //61-1 : 응할지 여부 - 응할시 - 검은동굴로 이동 및 2장뽑기 (대럴은 3장)            = 응하시겠습니까 창 -> YesBtn -> llPurple Draw(~~,1)          해결완
    //    //62-1 : 응할지 여부 - 응할시 - 숲으로 이동 및 2장뽑기 (대럴은 3장)                = 응하시겠습니까 창 -> YesBtn -> llRed Draw(~~,1)           해결완
    //    //62-2 : 강제 - 성공시 드림랜드 카드 조우 : 실패시 어비스 카드 조우                = OtherWorldOpen
    //    //63-1 : 응할지 여부 - 성공실패여부 - 실패시 - 드림랜드 색깔 카드 조우 끝          = 응하시겠습니까 창 -> YesBtn -> 성공하셨습니까 창 -> NoBtn -> OtherWorldOpen
    //    //63-2 : 응할지 여부 - 응할시 - 실버트와일라잇으로 이동 및 2장뽑기 (대럴은 3장)    = 응하시겠습니까 창 -> YesBtn -> llBlue Draw(~~,1)        해결완
    //
    //    //다른세계
    //    //5-1 : 강제 - 성공시 한칸씩 앞으로                                                = dOther~~~[nowplayer] -= 1


    public void ArkhamExceptionCard(int _cardNum, int _secNum)
    {
        switch(_cardNum)
        {
            case 6:
            case 7:
                {
                    if (_secNum == 1)
                    {
                        UI_General.Ins.systemAlert.OpenSysAlert(SystemAlert.eOpenSystemMode.IsSuccesses, _cardNum, _secNum);
                    }
                    break;
                }
            case 36:
                {
                    if (_secNum == 2)
                    {
                        //여기서 바로 드림랜드 오픈해야함
                        UI_General.Ins.ui_RulePhase.OpenExceptionPhase(UI_RulePhase.eOpenPhase.OtherWorldPhase);
                    }
                    break;
                }
            case 61:
                {
                    if (_secNum == 1)
                    {
                        UI_General.Ins.systemAlert.OpenSysAlert(SystemAlert.eOpenSystemMode.SureApply, _cardNum, _secNum);
                    }
                    break;
                }
            case 62:
                {
                    if (_secNum == 1)
                    {
                        UI_General.Ins.systemAlert.OpenSysAlert(SystemAlert.eOpenSystemMode.SureApply, _cardNum, _secNum);
                    }
                    else if (_secNum == 2)
                    {
                        //바로 다른세계조우 오픈
                        UI_General.Ins.ui_RulePhase.OpenExceptionPhase(UI_RulePhase.eOpenPhase.OtherWorldPhase);
                    }
                    break;
                }
            case 63:
                {
                    if (_secNum == 1)
                    {
                        UI_General.Ins.systemAlert.OpenSysAlert(SystemAlert.eOpenSystemMode.SureApply, _cardNum, _secNum);
                    }
                    else if (_secNum == 2)
                    {
                        UI_General.Ins.systemAlert.OpenSysAlert(SystemAlert.eOpenSystemMode.SureApply, _cardNum, _secNum);
                    }
                    break;
                }
        }
    }

    #region DECK SETTING
    void ShuffleArkhamEncounterDeck()
    {
        int[] generateResult = RandomShuffle(totalArkhamEncounterCardCount);
        for (int i = 0; i < totalArkhamEncounterCardCount; i++)
        {
            ArkhamEncounterSetting(generateResult[i]);
        }
    }

    public void ShuffleOtherWorldDeck()
    {
        llOtherWorldCards.Clear();

        int[] generateResult = RandomShuffle(totalOtherWorldEncounterCardCount);
        for(int i = 0; i < totalOtherWorldEncounterCardCount; i++)
        {
            llOtherWorldCards.AddLast(generateResult[i]);
        }
    }

    public void ShuffleMythosDeck()
    {
        llMythosCards.Clear();

        int[] generateResult = RandomShuffle(totalMythosCardCount);
        for (int i = 0; i < totalMythosCardCount; i++)
        {
            llMythosCards.AddLast(generateResult[i]);
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

    void ArkhamEncounterSetting(int _nID)
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


}
