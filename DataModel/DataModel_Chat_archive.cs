using System;

namespace DataModel
{
    public class DataModel_Chat_archive
    {
        public DateTime DateTime_of_message ;
        public string Username;
        public string Chat_Name;
        public bool Chat_Status;
        public string Chat_message;

        DataModel_Chat_archive(DateTime _dateTime_of_message, string _username, string _chatName, bool _chatStatus,
            string _chatMessage)
        {
            DateTime_of_message = _dateTime_of_message;
            Username = _username;
            Chat_Name = _chatName;
            Chat_Status = _chatStatus;
            Chat_message = _chatMessage;
        }
    }
}