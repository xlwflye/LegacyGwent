namespace Cynthia.Card
{
    public class CardStatus
    {
        public CardStatus(string statusId)
        {
            CardId = statusId;
            CardInfo = GwentMap.CardMap[statusId];
        }

        public CardStatus(string statusId, Faction deckFaction, RowPosition position) : this(statusId)
        {
            this.DeckFaction = deckFaction;
            CardRow = position;
        }

        public CardStatus()
        {
            IsCardBack = true;
            Conceal = true;
        }

        public CardStatus(Faction deckFaction) : this()
        {
            this.DeckFaction = deckFaction;
        }

        private Categorie[] _categories;
        private HideTag[] _hideTags;
        private string _name;
        private string _info;
        private int? _strength;
        private CardType? _type;
        private bool? _isDoomed;
        private bool? _isCountDown;
        private int? _countDown;
        private string _cardArtId;
        private Group? _group;
        private Faction? _faction;
        private int? _crewCount;
        private bool? _isConcealCard;
        public GwentCard CardInfo { get; set; }
        public string CardId { get; set; }
        public string CardArtsId { get => _cardArtId ?? CardInfo.CardArtsId; set => _cardArtId = value; }
        public Group Group { get => _group ?? CardInfo.Group; set => _group = value; }
        public RowPosition CardRow { get; set; }
        public bool IsDoomed { get => _isDoomed ?? CardInfo.IsDoomed; set => _isDoomed = value; }//是否佚亡
        public CardType Type { get => _type ?? CardInfo.CardType; set => _type = value; }//法术还是单位
        //---------------------------------------------------------------
        //卡牌状态
        public bool IsReveal { get; set; } = false;//是否被揭示 | 手牌
        public bool IsShield { get; set; } = false;//是否昆恩 | 手牌,场地
        public bool IsSpying { get; set; } = false;//是否间谍 | 场地
        public bool IsResilience { get; set; } = false;//是否坚韧 | 场地
        public int Armor { get; set; } = 0;//护甲 | 场地
        public int Strength { get => _strength ?? CardInfo.Strength; set => _strength = value; }//战力 | 手牌,场地,墓地
        public int CrewCount { get => _crewCount ?? CardInfo.CrewCount; set => _crewCount = value; }
        public int HealthStatus { get; set; } = 0;//增益减益 | 手牌,场地
        public bool IsLock { get; set; } = false;//是否锁定 | 场地,墓地
        public bool Conceal { get; set; } = false;//是否盖牌 | 场地
        public bool IsImmue { get; set; } = false;//是否免疫 | 场地
        //-----------------------------------------------------------------
        //显示相关
        public bool IsConcealCard { get => _isConcealCard ?? CardInfo.IsConcealCard; set => _isConcealCard = value; }
        public bool IsCardBack { get; set; } = false;
        public Faction DeckFaction { get; set; } = Faction.Monsters;
        public Faction Faction { get => _faction ?? CardInfo.Faction; set => _faction = value; }
        public string Name { get => _name ?? CardInfo.Name; set => _name = value; }
        public string Info { get => _info ?? CardInfo.Info; set => _info = value; }
        public Categorie[] Categories { get => _categories ?? CardInfo.Categories; set => _categories = value; }
        public HideTag[] HideTags { get => _hideTags ?? CardInfo.HideTags ?? new HideTag[] { }; set => _hideTags = value; }
        //-----------------------------------------------------------------
        public int Countdown { get => _countDown ?? CardInfo.Countdown; set => _countDown = value; }
        public bool IsCountdown { get => _isCountDown ?? CardInfo.IsCountdown; set => _isCountDown = value; }
    }
}