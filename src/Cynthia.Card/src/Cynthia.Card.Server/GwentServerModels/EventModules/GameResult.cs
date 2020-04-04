using System;

namespace Cynthia.Card.Server
{
    public class GameResult : ModelBase
    {
        public DateTime Time { get; set; }
        public string RedPlayerName { get; set; }
        public string BluePlayerName { get; set; }
        public string RedDeckName { get; set; }
        public string BlueDeckName { get; set; }

        public GameStatus RedPlayerGameResultStatus { get; set; }
        public string RedLeaderId { get; set; }
        public string BlueLeaderId { get; set; }

        public int RedWinCount { get; set; }
        public int BlueWinCount { get; set; }

        public int ValidCount { get; set; }
        public int[] RedScore { get; set; }
        public int[] BlueScore { get; set; }
    }
}