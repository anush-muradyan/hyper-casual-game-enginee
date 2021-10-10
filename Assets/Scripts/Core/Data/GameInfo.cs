namespace Core.Data
{
    public class GameInfo
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string PrefabName { get; set; }
        public string ImageUrl { get; set; }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Title)}: {Title}, {nameof(PrefabName)}: {PrefabName}, {nameof(ImageUrl)}: {ImageUrl}";
        }
    }
}