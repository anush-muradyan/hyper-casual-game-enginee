using System;
using Core.MVVM.Home;
using Object = UnityEngine.Object;

namespace Core.MVVM.Command.Home
{
    public class RemoveCommand<TResource> : ICommand where TResource : Object {
        private readonly Action executor;

        public RemoveCommand( Action executor) {
            this.executor = executor;
        }
        
        public void Execute()
        {
            executor.Invoke();
        }
        
    }
}