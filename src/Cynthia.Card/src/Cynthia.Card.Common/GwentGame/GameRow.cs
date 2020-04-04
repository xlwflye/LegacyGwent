using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cynthia.Card.Common.RowEffect;

namespace Cynthia.Card
{
    public class GameRow : IHasEffects
    {
        public EffectSet Effects { get; private set; }

        public RowStatus RowStatus { get => Effects.Count == 0 ? RowStatus.None : ((RowEffect)Effects.First()).StatusType; }

        public IList<GameCard> RowCards { get; private set; }

        public RowPosition RowPosition { get; private set; }

        public int PlayerIndex { get; private set; }

        public IGwentServerGame Game { get; private set; }

        public GameRow(IGwentServerGame game, IList<GameCard> rowCards, int playerIndex, RowPosition rowPosition)
        {
            Game = game;
            RowCards = rowCards;
            PlayerIndex = playerIndex;
            RowPosition = rowPosition;
            Effects = new EffectSet(this);
        }

        private async Task SetStatus(RowEffect effect)
        {
            effect.Row = this;//重要

            if (Effects.Count != 0)
            {
                Effects.Clear();
            }
            Effects.Add(effect);
            await Game.ShowWeatherApply(PlayerIndex, RowPosition, RowStatus);
            await Effects.RaiseEvent<SetStatusEffect>(new SetStatusEffect());
            await Game.SendEvent(new AfterWeatherApply(PlayerIndex, RowPosition, RowStatus));
        }

        public Task SetStatus<TRowEffect>() where TRowEffect : RowEffect, new()
        {
            var rowEffect = new TRowEffect();
            return SetStatus(rowEffect);
        }

        public Task SetStatus(RowStatus rowStatus)
        {
            var rowEffect = RowEffectFactory.Instance.GetRowEffectByRowStatus(rowStatus);
            return SetStatus(rowEffect);
        }


        // public async Task ApplyWeather(int playerIndex, int row, RowEffect status)
        // {
        //     // if (row < 0 || row > 2) return;
        //     // GameRowEffect[playerIndex][row].SetStatus(status);
        //     await ShowWeatherApply(playerIndex, row.IndexToMyRow(), status.StatusType);
        //     await SendEvent(new AfterWeatherApply(playerIndex, row.IndexToMyRow(), status.StatusType));
        // }
        // public async Task ApplyWeather(int playerIndex, RowPosition row, RowEffect status)
        // {
        //     if (!row.IsOnPlace()) return;
        //     if (row.IsMyRow()) await ApplyWeather(playerIndex, row.MyRowToIndex(), status);
        //     else await ApplyWeather(AnotherPlayer(playerIndex), row.Mirror().MyRowToIndex(), status);
        // }
    }
}