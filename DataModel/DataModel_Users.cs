﻿using System;

namespace DataModel
{
    public class Users
    {
        public int User_id { get; set; }
        public string UserName { get; set; }
        public TypeRole RolesOfUser { get; set; }
        public TypeStatus User_Status { get; set; }
    }
}