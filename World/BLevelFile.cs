
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Globalization;

namespace BEngine2D.World
{
    public partial class BLevelFile
    {
        [JsonProperty("compressionlevel")]
        public int Compressionlevel { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }

        [JsonProperty("infinite")]
        public bool Infinite { get; set; }

        [JsonProperty("layers")]
        public Layer[] Layers { get; set; }

        [JsonProperty("nextlayerid")]
        public long Nextlayerid { get; set; }

        [JsonProperty("nextobjectid")]
        public long Nextobjectid { get; set; }

        [JsonProperty("orientation")]
        public string Orientation { get; set; }

        [JsonProperty("renderorder")]
        public string Renderorder { get; set; }

        [JsonProperty("tiledversion")]
        public string Tiledversion { get; set; }

        [JsonProperty("tileheight")]
        public long Tileheight { get; set; }

        [JsonProperty("tilesets")]
        public Tileset[] Tilesets { get; set; }

        [JsonProperty("tilewidth")]
        public long Tilewidth { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("version")]
        public double Version { get; set; }

        [JsonProperty("width")]
        public int Width { get; set; }
    }

    public partial class Layer
    {
        [JsonProperty("data")]
        public int[] Data { get; set; }

        [JsonProperty("height")]
        public long Height { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("opacity")]
        public long Opacity { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("visible")]
        public bool Visible { get; set; }

        [JsonProperty("width")]
        public long Width { get; set; }

        [JsonProperty("x")]
        public long X { get; set; }

        [JsonProperty("y")]
        public long Y { get; set; }
    }

    public partial class Tileset
    {
        [JsonProperty("firstgid")]
        public long Firstgid { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }
    }

    public partial class BLevelFile
    {
        public static BLevelFile FromJson(string json) => JsonConvert.DeserializeObject<BLevelFile>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this BLevelFile self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
