namespace Core.AbstractFactory {
    public interface IFactory {
        public void Quit<T>(T item) where T : IFactory;
    }
}