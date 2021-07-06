using System.IO;
using System.Text.Json;

namespace DB_Connection
{
    public class JsonType
    {
        public string Server { get; set; }
        public string Database { get; set; }
        public string Port { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
    }

    public class JsonWork
    {
        public JsonType GetJson()
        {
            var filename = "config.json";
            var jsonstring = File.ReadAllText(filename);
            var jsonCast = JsonSerializer.Deserialize<JsonType>(jsonstring);
            return jsonCast;
        }
    }
}