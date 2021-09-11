using System;
using System.Collections.Generic;
using Core.Data;
using Core.MVVM.Command;

namespace Core.MVVM.GameSelectorView
{
    public class LoadGameItemsCommand : ICommand<List<GameInfo>>
    {
        private Action<List<GameInfo>> executor;

        public LoadGameItemsCommand(Action<List<GameInfo>> executor)
        {
            this.executor = executor;
        }

        public void Execute(List<GameInfo> data)
        {
            executor?.Invoke(data);
        }

    }
}