using System;
using System.Text.Json;

namespace Message_Types
{
    public class Msg
    {
        public TypesMsg Type { get; set; }
        public int IdChat { get; set; }
        public DateTime Date { get; set; }
        public string SenderName { get; set; }
        public string Message { get; set; }

        public Msg() { }

        public Msg(int idChat,DateTime date, TypesMsg type, string senderName, string message)
        {
            Type = type;
            IdChat = idChat;
            Date = date;
            SenderName = senderName;
            Message = message;
        } 
    }
}
