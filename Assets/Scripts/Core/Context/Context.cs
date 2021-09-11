using IFactory = Core.AbstractFactory.IFactory;

namespace Core.Context {
    public class Context {
        private IFactory factory;

        public IFactory Factory {
            get => factory;
            set {
                if (value == null)
                    return;
                factory.Quit(factory);
                factory = value;
            }
        }

    }
}