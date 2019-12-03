using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace SiteEstudoDotNetFramework.Controllers
{
    public class LoginController : ApiController
    {
        // GET: Login
        [System.Web.Http.HttpPost]
        public string Login (string login, string password)
        {
            /*
            string authorityUri = "https://login.windows.net/common/oauth2/authorize";
            AuthenticationContext authContext = new AuthenticationContext(authorityUri);

            AuthenticationResult token = authContext.AcquireToken(resourceUri, clientId, new Uri(redirectUri), PromptBehavior.RefreshSession);
            if (string.IsNullOrEmpty(Settings.ClientId) || string.IsNullOrEmpty(Settings.ClientSecret))
            {
                return "Please set your client ID and client secret in the Web.config file";
            }
            var authContext = new AuthenticationContext(config);

            authContext.login()

            var authContext = new AuthenticationContext(Settings.AzureADAuthority);

            // Generate the parameterized URL for Azure login.
            Uri authUri = await authContext.GetAuthorizationRequestUrlAsync(
                Settings.O365UnifiedAPIResource,
                Settings.ClientId,
                loginRedirectUri,
                UserIdentifier.AnyUser,
                null);

            // Redirect the browser to the login page, then come back to the Authorize method below.
            return Redirect(authUri.ToString());
            */
            return login +" "+password;
        }

    }
}