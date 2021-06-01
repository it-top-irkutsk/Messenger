using System;

namespace Message_Types
{
    public enum TypesMsg
    {
        Connection,Text
    }
    public class Msg
    {
        public TypesMsg Type;
        public string SenderName;
        public DateTime Date;
        public string NameChat;
        public string Message;
    }
    
}
