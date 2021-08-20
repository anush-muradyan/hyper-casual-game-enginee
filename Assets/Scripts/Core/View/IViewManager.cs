using Core.AbstractFactory;
using Core.View.Factory;

namespace Core.View
{
    public interface IViewManager<TConfig> where TConfig:IFactoryConfig
    {
        void Startup();
        TConfig GetConfig();
    }
}