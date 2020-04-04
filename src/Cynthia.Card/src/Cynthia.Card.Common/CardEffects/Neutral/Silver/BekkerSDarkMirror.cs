using System.Linq;
using System.Threading.Tasks;
using Alsein.Extensions;

namespace Cynthia.Card
{
    [CardEffectId("13026")]//贝克尔的黑暗之镜
    public class BekkerSDarkMirror : CardEffect
    {//对场上最强的单位造成最多10点伤害（无视护甲），并使场上最弱的单位获得相同数值的增益。
        public BekkerSDarkMirror(GameCard card) : base(card) { }
        public override async Task<int> CardUseEffect()
        {
            var list = Game.GetPlaceCards(PlayerIndex).ToList();
            if (list.Count() <= 0) return 0;
            //穿透伤害
            var damageCard = list.WhereAllHighest().Mess(RNG).First();
            var boostCard = list.WhereAllLowest().Mess(RNG).First();
            await damageCard.Effect.Damage(10, Card, BulletType.RedLight, true);
            await boostCard.Effect.Boost(10, Card);
            return 0;
        }
    }
}