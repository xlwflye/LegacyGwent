using System.Linq;
using System.Threading.Tasks;
using Alsein.Extensions;

namespace Cynthia.Card
{
    [CardEffectId("24028")]//小雾妖
    public class Foglet : CardEffect, IHandlesEvent<AfterWeatherApply>
    {//每当在对方半场降下“蔽日浓雾”，便召唤1张同名牌至己方同排。
        public Foglet(GameCard card) : base(card) { }
        public async Task HandleEvent(AfterWeatherApply @event)
        {
            if (@event.Type == RowStatus.ImpenetrableFog && @event.PlayerIndex == AnotherPlayer)

            {
                //列出所有可以打出卡
                var list = Game.PlayersDeck[Card.PlayerIndex].Where(x => x.Status.CardId == Card.Status.CardId);
                if (list.Count() == 0)
                {
                    return;
                }
                //只召唤最后一个，召唤到同排最右侧
                if (Card == list.Last())
                {
                    await Card.Effect.Summon(new CardLocation(@event.Row, int.MaxValue), Card);
                }
            }
            return;
        }
    }
}