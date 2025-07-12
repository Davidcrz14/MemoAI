using System;

namespace MemoAI
{
    public static class GoogleConfig
    {
        // Credenciales de Google Cloud Console
        public static string ClientId = "98414032327-p59mj53uoirim7fk6k13imk1ms8ds8s7.apps.googleusercontent.com";
        public static string ClientSecret = "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";
        public static string RedirectUri = "urn:ietf:wg:oauth:2.0:oob";

        // Scopes necesarios para Gmail
        public static string[] Scopes = {
            "https://www.googleapis.com/auth/gmail.readonly",
            "https://www.googleapis.com/auth/gmail.send",
            "https://www.googleapis.com/auth/gmail.modify"
        };

        public static string GetAuthUrl()
        {
            var scopeString = string.Join(" ", Scopes);
            return $"https://accounts.google.com/o/oauth2/auth?" +
                   $"client_id={ClientId}&" +
                   $"redirect_uri={RedirectUri}&" +
                   $"scope={Uri.EscapeDataString(scopeString)}&" +
                   $"response_type=code&" +
                   $"access_type=offline&" +
                   $"prompt=consent";
        }
    }
}
