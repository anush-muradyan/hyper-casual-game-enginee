namespace Core.Convertor
{
    public interface IConvertor
    {
        string Serialize(object data);
        T Deserialize<T>(string data);
    }
}