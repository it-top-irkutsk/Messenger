using System;

namespace DataModel
{
    public class ChatArchive
    {
        public int IdUser { get; set; }
        public int IdChat { get; set; }
        public DateTime DateTimeOfMessage { get; set; }
        public string ChatMessage { get; set; }
        
        public ChatArchive() {}
        public ChatArchive(int idUser, int idChat, DateTime dateTimeOfMessage, string chatMessage)
        {
            IdUser = idUser;
            IdChat = idChat;
            DateTimeOfMessage = dateTimeOfMessage;
            ChatMessage = chatMessage;
        }
    }
}