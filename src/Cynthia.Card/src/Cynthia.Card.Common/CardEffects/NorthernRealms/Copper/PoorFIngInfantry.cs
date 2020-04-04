using System.Linq;
using System.Threading.Tasks;
using Alsein.Extensions;

namespace Cynthia.Card
{
    [CardEffectId("44020")]//可怜的步兵
    public class PoorFIngInfantry : CardEffect
    {//在左右两侧分别生成“左侧翼步兵”和“右侧翼步兵”。
        public PoorFIngInfantry(GameCard card) : base(card) { }
        public override async Task<int> CardPlayEffect(bool isSpying, bool isReveal)
        {
            await Game.CreateCard(CardId.LeftFlankInfantry, PlayerIndex, Card.GetLocation());
            await Game.CreateCard(CardId.RightFlankInfantry, PlayerIndex, Card.GetLocation() + 1);

            return 0;
        }
    }
}