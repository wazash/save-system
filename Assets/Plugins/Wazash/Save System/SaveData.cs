using Newtonsoft.Json;
using System.Collections.Generic;

namespace Wazash.Save
{
    /// <summary>
    /// Data container for saving and loading game data.
    /// </summary>
    [System.Serializable]
    public class SaveData
    {
        [JsonProperty]
        public Dictionary<string, object> data = new();
    }
}
