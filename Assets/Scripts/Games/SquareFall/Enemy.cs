namespace Games.SquareFall
{
    public class Enemy : PoolingUnit
    {
        private void Awake()
        {
            OnPooling = OnPoolingFunction;
        }

        public override bool  OnPoolingFunction(bool canPlay)
        {
            canPlay = false;
            return canPlay;
        }
    }
}
