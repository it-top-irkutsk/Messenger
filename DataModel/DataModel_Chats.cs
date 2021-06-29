namespace DataModel
{
    public class ChatsList
    {
        public int IdChat { get; set; }
        public string ChatName { get; set; }
        public bool ChatStatus { get; set; }
        
        public ChatsList(){}

        public ChatsList(int idChat, string chatName, bool chatStatus)
        {
            IdChat = idChat;
            ChatName = chatName;
            ChatStatus = chatStatus;
        }
    }
}