using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Web.WebPages.OAuth;
using _1stream.Models;

namespace _1stream
{
    public static class AuthConfig
    {
        public static void RegisterAuth()
        {
            // To let users of this site log in using their accounts from other sites such as Microsoft, Facebook, and Twitter,
            // you must update this site. For more information visit http://go.microsoft.com/fwlink/?LinkID=252166

            OAuthWebSecurity.RegisterMicrosoftClient(
                clientId: "test",
                clientSecret: "test");

            OAuthWebSecurity.RegisterTwitterClient(
                consumerKey: "test",
                consumerSecret: "test");

            OAuthWebSecurity.RegisterFacebookClient(
                appId: "test",
                appSecret: "test");

            OAuthWebSecurity.RegisterGoogleClient();
        }
    }
}
