using Microsoft.Owin.Security.OAuth;
using SiteEstudoDotNetFramework.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace SiteEstudoDotNetFramework
{
    public class BasicAuthentication : AuthorizationFilterAttribute
    {

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var authHeader = actionContext.Request.Headers.Authorization;

            if (authHeader != null)
            {
                var authenticationToken = actionContext.Request.Headers.Authorization.Parameter;
                var decodedAuthenticationToken = Encoding.UTF8.GetString(Convert.FromBase64String(authenticationToken));
                var usernamePasswordArray = decodedAuthenticationToken.Split(':');
                var userName = usernamePasswordArray[0];
                var password = usernamePasswordArray[1];

                bool isValid = userName == UncryptCredentials("username")
                            && password == UncryptCredentials("password");
                //bool isValid = true;

                if (isValid)
                {
                    var principal = new GenericPrincipal(new GenericIdentity(userName), null);
                    Thread.CurrentPrincipal = principal;

                    return;
                }
            }

            HandleUnathorized(actionContext);
        }

        private static void HandleUnathorized(HttpActionContext actionContext)
        {
            //actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            actionContext.Response.Headers.Add("WWW-Authenticate", "Basic Scheme='Data' location = 'http://localhost:");
        }

        private static string UncryptCredentials(string word)
        {
            //return AdvancedEncryptionStandard.Decrypta(word, "P@rl1W00p!", string.Empty, "MD5", 2, "16CHARSLONG12345", 256);
            return "";
        }
        
    }
    

    public class MyAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            using (UserRepository _repo = new UserRepository())
            {
                var user = _repo.ValidateUser(context.UserName, context.Password);
                if (user == null)
                {
                    context.SetError("invalid_grant", "Provided username and password is incorrect");
                    return;
                }
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);

                //identity.AddClaim(new Claim("Role", user.UserRoles));
                //identity.AddClaim(new Claim("Teste", user.UserName));
                //identity.AddClaim(new Claim("Email", user.UserEmailID));

                context.Validated(identity);
            }
        }
    }

}