using System;

namespace Message_Types
{
    enum TypesMsg
    {
        ConDiscon,Text
    }
    public class Allmsg
    {
      protected string Name;
      protected DateTime Date;
      protected string Chat;
    }

    public class ConDiscon : Allmsg
    {
        public bool choice;
    }

    public class Text : Allmsg
    {
        public string msg;
    }
}
