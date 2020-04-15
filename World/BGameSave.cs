using BEngine2D.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace BEngine2D.World
{
    public class BGameSave
    {
        public List<BEntity> Entities { get; set; }

        public BGameSave()
        {
            Entities = new List<BEntity>();
        }

        public void Save(string world)
        {
            string path = Path.Combine("Content/Saves", world + ".ws");
            File.WriteAllText(path, ToJson());
        }

        public static BGameSave Load(string world)
        {
            string path = Path.Combine("Content/Saves", world + ".ws");
            return JsonConvert.DeserializeObject<BGameSave>(File.ReadAllText(path));
        }

        public string ToJson() => JsonConvert.SerializeObject(this, Formatting.Indented);
    }
}
