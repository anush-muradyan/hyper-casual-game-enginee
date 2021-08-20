using System;

namespace Core.Game
{
    public interface IGameItem
    {
        event Action<GameInfo> OnSelected;
        void Setup(GameInfo gameInfo);
    }
}