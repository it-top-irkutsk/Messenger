namespace DataModel
{
    public class UsersInChat
    {
        public int IdUser { get; set; }
        public int IdChat { get; set; }
        
        public UsersInChat(){}
        public UsersInChat(int idUser, int idChat)
        {
            IdUser = idUser;
            IdChat = idChat;
        }
    }
}