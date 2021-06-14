using System;

namespace DataModel
{
    public class DataModel_Authentification
    {
        public string UserName;
        public Roles_of_user RolesOfUser;
        public string User_Status;

        DataModel_Authentification(string _userName, Roles_of_user _rolesOfUser, string _userStatus)
        {
            UserName = _userName;
            RolesOfUser = _rolesOfUser;
            User_Status = _userStatus;
        }
    }
}