namespace Core.Game
{
    public struct GameInfo
    {
        public string Name { get; }
        public string Code { get; }

        public GameInfo(string name, string code)
        {
            Name = name;
            Code = code;
        }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Code)}: {Code}";
        }
    }
}