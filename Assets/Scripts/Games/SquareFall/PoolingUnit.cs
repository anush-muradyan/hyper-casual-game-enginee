using System;

namespace Games.SquareFall
{
    public abstract class PoolingUnit: Unit,IPoolingUnit
    {
        public Func<bool, bool> OnPooling { get; set; }
       
        public abstract bool OnPoolingFunction(bool arg0);

      
    }
}