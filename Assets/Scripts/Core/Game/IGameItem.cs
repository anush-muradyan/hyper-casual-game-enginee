using System;
using Core.Data;

namespace Core.Game {
    public interface IGameItem {
        event Action<GameInfo> OnSelected;
        void Setup(GameInfo gameInfo);
    }
}