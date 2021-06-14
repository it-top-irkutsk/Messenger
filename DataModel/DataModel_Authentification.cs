using System;

namespace DataModel
{
    public class Authentification
    {
        public int User_id { get; set; }
        public string UserName { get; set; }
        public TypeRole RolesOfUser { get; set; }
        public string User_Status { get; set; }
    }
}