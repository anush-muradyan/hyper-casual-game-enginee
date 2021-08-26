using System;

namespace Games.SquareFall
{
    public interface IPoolingUnit
    {
        public Func<bool, bool> OnPooling { get; set; }  
    }
}