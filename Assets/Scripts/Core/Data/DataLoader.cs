using Core.Convertor;
using Core.Data.Game;
using UnityEngine;

namespace Core.Data
{
    public interface IDataLoader
    {
        GamesData LoadGameInfos();
    }

    public class DataLoader:IDataLoader
    {
        private readonly IConvertor convertor;
        private const string GAME_INFO_PATH = "Data/games";

        public DataLoader(IConvertor convertor)
        {
            this.convertor = convertor;
        }


        public GamesData LoadGameInfos()
        {
            var jsonAsset = Resources.Load<TextAsset>(GAME_INFO_PATH);
            if (jsonAsset == null)
            {
                Debug.LogError("Error loading game infos.");
                return null;
            }

            var data = convertor.Deserialize<GamesData>(jsonAsset.text);
            if (data == null)
            {
                Debug.LogError("Error parsing game infos.");
                return null;
            }

            return data;
        }
    }
}