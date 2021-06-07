using System;
using System.Text.Json;

namespace Message_Types
{
    public enum TypesMsg
    {
        Connection,
        Disconnection,
        Text,
        Welcome,
        Bye
    }

    public class Msg
    {
        public DateTime Date { get; set; }
        public TypesMsg Type { get; set; }
        public string NameChat { get; set; }
        public string SenderName { get; set; }
        public string Message { get; set; }

        public Msg()
        {
        }

        public Msg(DateTime date, TypesMsg type, string nameChat, string senderName, string message)
        {
            Type = type;
            Date = date;
            NameChat = nameChat;
            SenderName = senderName;
            Message = message;
        }
        
    }
}
