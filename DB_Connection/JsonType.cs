using System.IO;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace DB_Connection
{
    public class JsonType
    {
        public string DataSource { get; set; }
        public string Catalog { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
    }
}