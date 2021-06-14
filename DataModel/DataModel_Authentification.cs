using System;

namespace DataModel
{
    public class DataModel_Authentification
    {
        public int User_id;
        public string UserName;
        public Roles_of_user RolesOfUser;
        public string User_Status;

        DataModel_Authentification(int _userId ,string _userName, Roles_of_user _rolesOfUser, string _userStatus)
        {
            User_id = _userId;
            UserName = _userName;
            RolesOfUser = _rolesOfUser;
            User_Status = _userStatus;
        }
    }
}