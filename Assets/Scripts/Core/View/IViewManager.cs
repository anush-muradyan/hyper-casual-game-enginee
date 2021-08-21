using Core.AbstractFactory;

namespace Core.View
{
    public interface IViewManager<TConfig> where TConfig:IFactoryConfig
    {
        void Startup();
        TConfig GetConfig();
    }
}