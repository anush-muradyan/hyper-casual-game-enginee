namespace Games.SquareFall
{
    public class BonusItem : PoolingUnit
    {
        private void Awake()
        {
            OnPooling = OnPoolingFunction;
        }

        public override bool OnPoolingFunction(bool addScore)
        {
            addScore = true;
            return addScore;
        }
    }
}
