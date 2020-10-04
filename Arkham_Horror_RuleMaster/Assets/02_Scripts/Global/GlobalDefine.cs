using System.IO;
using System.ComponentModel;

namespace global_define
{
    #region CLASS
    public static class DATAPath
    {
        public static readonly string ASSETBUNDLE_DB_ROOT;
        public static readonly string ASSETBUNDLE_CHARACTER_IMAGE_ROOT;
        public static readonly string ASSETBUNDLE_CARD_IMAGE_ROOT;
        public static readonly string ASSETBUNDLE_ICON_IMAGE_ROOT;

        static DATAPath()
        {
            ASSETBUNDLE_DB_ROOT = "AssetBundles/Android/db";
            ASSETBUNDLE_CHARACTER_IMAGE_ROOT = "AssetBundles/Android/characterimage";
            ASSETBUNDLE_CARD_IMAGE_ROOT = "AssetBundles/Android/cardimage";
            ASSETBUNDLE_ICON_IMAGE_ROOT = "AssetBundles/Android/iconimage";
        }
    }

    public static class ConstString
    {
        public static string IS_SUCCESS_KOR = "체크에 성공하셨습니까?";
        public static string IS_SUCCESS_ENG = "Was it successful?";

        public static string IS_SURE_KOR = "응하시겠습니까?";
        public static string IS_SURE_ENG = "Would you like to respond?";

        public static string IS_APPLY_KOR = "적용하셨습니까?";
        public static string IS_APPLY_ENG = "Did you apply?";
    }
    #endregion

    public enum eScene
    {
        None = -1,

        [Description("Title")]
        Title,

        [Description("Loading")]
        Loading,

        [Description("InGame")]
        InGame,

        [Description("Start")]
        Start,

        Max
    }

    public enum eLanguage
    {
        Korean,
        English
    }

    #region DATASETTING
    public enum eTable
    {
        CharacterDB,
        PlaceDB,
        OtherWorldDB,
        MythosDB,
        LanguageDB,

        Max
    }

    public enum eAbility
    {
        None = -1,

        NotExceptionAbility,
        DoublePlaceDraw,
        DoubleOtherWorldDraw,

    }
    //없어질 예정
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
    //사라질 예정
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
        Headline,
        Rumor,
        Environment_Urban,
        Environment_Weather,
        Environment_Mystic,

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
    //없어질 예정
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
    //없어질 예정 => 캐릭터가 어느 시공에 빨려들어갔는지 체크해서, 그걸 자동으로 맞춰주면 개꿀일거 같은데..?
    public enum eOtherWorld
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

}