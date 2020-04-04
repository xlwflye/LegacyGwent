using System.Linq;
using System.Threading.Tasks;
using Alsein.Extensions;

namespace Cynthia.Card
{
	[CardEffectId("43003")]//巨魔魔
	public class Trollololo : CardEffect
	{//9点护甲。
		public Trollololo(GameCard card) : base(card){}
		public override async Task<int> CardPlayEffect(bool isSpying,bool isReveal)
		{
			await Card.Effect.Armor(9,Card);
			return 0;
		}
	}
}