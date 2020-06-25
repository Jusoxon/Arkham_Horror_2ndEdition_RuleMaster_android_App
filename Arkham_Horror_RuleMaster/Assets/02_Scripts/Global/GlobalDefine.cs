using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Globalization;

namespace global_define
{
    public static class Path
    {
        public static readonly string DIR_CONFIG_ROOT;
        public static readonly string DIR_GAMEOPTION_ROOT;
        public static string RESOURCES_CARD_PNG_ROOT = "/CardPNG/{0}";

        static Path()
        {
            DIR_CONFIG_ROOT = Directory.GetCurrentDirectory() + "/DB/{0}";
            DIR_GAMEOPTION_ROOT = Directory.GetCurrentDirectory() + "/GAMEOPTION/{0}";
        }
    }
    public static class TextMake
    {
        public static string IS_SUCCESS_TEXT = "체크에 성공하셨습니까?";
        public static string IS_SURE_TEXT = "응하시겠습니까?";
        public static string IS_CORRECT_ABYSS_TEXT = "해당 카드를 적용하셨습니까?";
    }

    //enum
    #region ENUM
    public enum eMonsterSymbol
    {
        Circle = 1,
        Slash,
        Triangle,
        Square,
        Rhombus,
        Star,
        Hexagon,
        Moon,
        TheCross,

        Max
    }

    public enum eAbyssColor
    {
        White,
        Green,
        Red,
        Yellow,
        Blue,

        Max
    }

    public enum eMythosCategory
    {
        Reset_Card,
        News,
        Rumor,
        Environment_City,
        Environment_Weather,
        Environment_Mistic,

    }

    public enum ePlaceColor
    {
        Orange = 1,
        White,
        Black,
        Green,
        Purple,
        Yellow,
        Blue,
        Red,
        Brown,

        Max
    }

    public enum ePlace
    {
        None,
        Antique_Shop = 1,       //골동품 상점
        NewsPaper,              //신문사
        Station,                //기차역

        Asylum,                 //정신병원
        Bank,                   //은행
        Square,                 //독립광장

        Streetside_Restaurant,  //히브의 가로변 식당
        Police,                 //경찰서
        Restaurant,             //벨마네 식당

        RivesidePier,           //강변 부두
        Noname_House,           //이름 붙지 않은 집
        Island,                 //방문하지 않은 섬

        Cave,                   //검은 동굴
        Variety_Store,          //잡화점
        Cemetery,               //공동 묘지

        University,             //대학 본부
        Library,                //도서관
        Science,                //과학관

        Silver_Twilight,        //실버 트와일라이트
        Silver_Twilight_Member, //회원공간
        Witch,                  //마녀의 집

        Hospital,               //세인트 메리 병원
        Forest,                 //숲
        Magic_Shop,             //예 올디 매직샵

        Archeology,             //고고학 연구학회
        Boarding_House,         //마의 하숙집
        Church,                 //남부 성당

        //거리
        North,                  //북부
        Downtown,               //번화가
        East,                   //동부
        Business,               //상업지구
        Riverside,              //강변
        UniversityStreet,       //미스캐토닉 대학의 거리
        FrenchHill,             //프랑스언덕
        Suburb,                 //외곽
        South                   //남부
    }

    public enum eAbyss
    {
        None,
        OtherWorld = 1,
        Abyss,
        CityOfGreatOne,
        Yugos,
        Celino,
        DreamLand,
        LangPlateau,
        Lelie
    }

    #endregion

    //Interface
    interface ICardInfoSetting
    {
        void CardInfoSetting(int _cardNum);
    }
}