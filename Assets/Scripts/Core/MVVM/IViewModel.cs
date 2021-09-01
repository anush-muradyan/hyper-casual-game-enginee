namespace Core.MVVM
{
    public delegate void PropertyChangeDelegate(string propertyName, object obj);

    public interface IViewModel
    {
    }

    public interface IViewModel<TModel> : IViewModel where TModel : IModel
    {
        TModel Model { get; set; }
        void Init();
    }

    public interface INotifyPropertyChange
    {
        event PropertyChangeDelegate OnPropertyChange;
        void PropertyChange(string propertyName, object value);
    }

    public interface IModel : INotifyPropertyChange
    {
        void ForceUpdate();
    }
}