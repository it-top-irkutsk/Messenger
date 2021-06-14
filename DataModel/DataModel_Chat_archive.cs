using System;

namespace DataModel
{
    public class Chat_archive
    {
        public int id_User { get; set; }
        public int id_Chat { get; set; }
        public DateTime DateTime_of_message { get; set; }
        public string Chat_message { get; set; }
    }
}