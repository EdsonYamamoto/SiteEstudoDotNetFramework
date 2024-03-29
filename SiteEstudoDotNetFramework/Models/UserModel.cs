﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiteEstudoDotNetFramework.Models
{
    public class UserModel
    {
        public string username { get; set; }
        public string password { get; set; }
        public string userRoles { get; set; }

        public override string ToString()
        {
            return username + " " + userRoles;
        }
    }
}