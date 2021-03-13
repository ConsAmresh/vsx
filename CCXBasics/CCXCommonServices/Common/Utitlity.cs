using System;
using System.Net;
using System.Text;

namespace CCXCommonServices.Common
{
    public class Utility
    {
        public static NetworkCredential GetCredentials(string auth)
        {
            string encodedUsernamePassword = string.Empty;
            if (auth != null && auth.StartsWith("Basic"))
            {
                encodedUsernamePassword = auth.Substring("Basic ".Length).Trim();
            }
            else
            {
                encodedUsernamePassword = auth;
            }
            Encoding encoding = Encoding.GetEncoding("iso-8859-1");
            string usernamePassword = encoding.GetString(Convert.FromBase64String(encodedUsernamePassword));
            int seperatorIndex = usernamePassword.IndexOf(':');
            var username = usernamePassword.Substring(0, seperatorIndex).Trim();
            var password = usernamePassword.Substring(seperatorIndex + 1).Trim();
            return new NetworkCredential(username, password);
        }
    }
}
