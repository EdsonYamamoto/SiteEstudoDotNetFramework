using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiteEstudoDotNetFramework.Repository
{
    public class UserRepository : IDisposable
    {
        // SECURITY_DBEntities it is your context class
        //SECURITY_DBEntities context = new SECURITY_DBEntities();

        //This method is used to check and validate the user credentials
        public Models.UserModel ValidateUser(string username, string password)
        {
            /*
            return context.UserMasters.FirstOrDefault(user =>
            user.UserName.Equals(username, StringComparison.OrdinalIgnoreCase)
            && user.UserPassword == password);
            */
            return new Models.UserModel {username="Terry", password="1234" };

        }

        public void Dispose()
        {
            //context.Dispose();
        }
    }
}