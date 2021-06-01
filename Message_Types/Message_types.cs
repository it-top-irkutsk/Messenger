using System;

namespace Message_Types
{
    enum TypesMsg
    {
        Connection,Text
    }
    public class Msg
    {
        public Enum Type;
        public string Name;
        public DateTime Date;
        public string Chat;
    }
    
}
