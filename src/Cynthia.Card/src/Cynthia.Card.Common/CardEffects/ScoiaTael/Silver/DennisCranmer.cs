using System.Linq;
using System.Threading.Tasks;
using Alsein.Extensions;

namespace Cynthia.Card
{
	[CardEffectId("53005")]//丹尼斯·克莱默
	public class DennisCranmer : CardEffect
	{//使位于手牌、牌组和己方半场除自身外所有“矮人”单位获得1点强化。
		public DennisCranmer(GameCard card) : base(card){}
		public override async Task<int> CardPlayEffect(bool isSpying,bool isReveal)
		{
			var cards = Game.PlayersHandCard[PlayerIndex].Concat(Game.GetPlaceCards(PlayerIndex)).Concat(Game.PlayersDeck[PlayerIndex]).FilterCards(filter: x => x.HasAllCategorie(Categorie.Dwarf) && x != Card);

            foreach (var card in cards)
            {
                await card.Effect.Strengthen(1, Card);
            }
            return 0;
		}
	}
}