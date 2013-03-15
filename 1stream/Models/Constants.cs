using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OneStream.Models
{
    public static class Constants
    {
        private const string _dateTimeFormat = "MM.dd.yyyy hh:mm:ss";
        public static string DateTimeFormat { get { return _dateTimeFormat; } }
    }

    public static class UserRole
    {
        private const string _admin = "Admin";
        private const string _user = "User";

        public static string Admin { get { return _admin; } }
        public static string User { get { return _user; } }
    }
}