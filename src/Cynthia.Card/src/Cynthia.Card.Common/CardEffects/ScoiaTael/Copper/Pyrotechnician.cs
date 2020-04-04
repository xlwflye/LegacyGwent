using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alsein.Extensions;

namespace Cynthia.Card
{
    [CardEffectId("54019")] //烟火技师
    public class Pyrotechnician : CardEffect
    {
        //对对方每排的1个随即单位造成3点伤害。
        public Pyrotechnician(GameCard card) : base(card)
        {
        }

        public override async Task<int> CardPlayEffect(bool isSpying, bool isReveal)
        {
            var list = new List<GameCard>();
            list.Add(RandomChooseCard(RowPosition.EnemyRow1));
            list.Add(RandomChooseCard(RowPosition.EnemyRow2));
            list.Add(RandomChooseCard(RowPosition.EnemyRow3));
            foreach (var it in list)
            {
                if (it != null) await it.Effect.Damage(damage, Card);
            }

            return 0;
        }

        private const int damage = 3;

        private GameCard RandomChooseCard(RowPosition position)
        {
            var row = Game.RowToList(Card.PlayerIndex, position).IgnoreConcealAndDead();
            return !row.Any() ? null : row.Mess(RNG).First();
        }
    }
}