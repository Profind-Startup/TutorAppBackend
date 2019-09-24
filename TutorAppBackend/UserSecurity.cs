using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TutorAppBackend.Models;

namespace TutorAppBackend
{
    public class UserSecurity
    {
        public static bool Login(string username, string password)
        {
            using (TutorAppBD entities = new TutorAppBD())
            {
                return entities.User.Any(user =>
                       user.username.Equals(username, StringComparison.OrdinalIgnoreCase)
                                          && user.password == password);
            }
        }
    }
}