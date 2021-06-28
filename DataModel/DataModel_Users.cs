using System;

namespace DataModel
{
    public class Users
    {
    
        public int UserId { get; set; }
        public string UserName { get; set; }
        public TypeRole RolesOfUser { get; set; }
        public TypeStatus UserStatus { get; set; }

        public Users()
        {
            
        }
        
        public Users(int userId, string userName, TypeRole rolesOfUser, TypeStatus userStatus)
        {
            UserId = userId;
            UserName = userName;
            RolesOfUser = rolesOfUser;
            UserStatus = userStatus;
        }
    }
}