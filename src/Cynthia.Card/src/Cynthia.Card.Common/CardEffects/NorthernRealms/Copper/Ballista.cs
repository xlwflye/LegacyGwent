using System.Linq;
using System.Threading.Tasks;
using Alsein.Extensions;
using System.Collections.Generic;

namespace Cynthia.Card
{
    [CardEffectId("44017")]//弩炮
    public class Ballista : CardEffect
    {//对1个敌军单位和最多4个与它战力相同的其他敌军单位造成1点伤害。 驱动：再次触发此能力。
        public Ballista(GameCard card) : base(card) { }
        public override async Task<int> CardPlayEffect(bool isSpying, bool isReveal)
        {
            for (var i = 0; i < Card.GetCrewedCount() + 1; i++)
            {
                var selectList = await Game.GetSelectPlaceCards(Card, selectMode: SelectModeType.EnemyRow);

                if (!selectList.TrySingle(out var target))
                {
                    continue;
                }
                //获取所有敌方除了target以外的与target战力相同卡,从中随机取最多4个
                //take方法超过上限会发生什么？
                var enemycards = Game.GetAllCard(Card.PlayerIndex).Where(x => x.Status.CardRow.IsOnPlace() && x.PlayerIndex != Card.PlayerIndex && x != target && x.ToHealth().health == target.ToHealth().health).ToList();
                if (enemycards.Count() == 0)
                {
                    await target.Effect.Damage(1, Card);
                    continue;
                }
                int takenum = enemycards.Count() <= 4 ? enemycards.Count() : 4;

                var damagelist = enemycards.Take(takenum).Concat(new List<GameCard>() { target }).ToList();
                foreach (var card in damagelist)
                {
                    await card.Effect.Damage(1, Card);
                }
            }

            return 0;
        }
    }
}