using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace SiteEstudoDotNetFramework.Controllers
{
    public class TestController : ApiController
    {
        //This resource is For all types of role
        [System.Web.Http.Authorize(Roles = "SuperAdmin, Admin, User")]
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/test/resource1")]
        public IHttpActionResult GetResource1()
        {
            var identity = (ClaimsIdentity)User.Identity;
            return Ok("Hello: " + identity.Name);
        }
        //This resource is only For Admin and SuperAdmin role
        [System.Web.Http.Authorize(Roles = "SuperAdmin, Admin")]
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/test/resource2")]
        public IHttpActionResult GetResource2()
        {
            var identity = (ClaimsIdentity)User.Identity;
            var Email = identity.Claims
                      .FirstOrDefault(c => c.Type == "Email").Value;
            var UserName = identity.Name;

            return Ok("Hello " + UserName + ", Your Email ID is :" + Email);
        }
        //This resource is only For SuperAdmin role
        [System.Web.Http.Authorize(Roles = "SuperAdmin")]
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/test/resource3")]
        public IHttpActionResult GetResource3()
        {
            var identity = (ClaimsIdentity)User.Identity;
            var roles = identity.Claims
                        .Where(c => c.Type == ClaimTypes.Role)
                        .Select(c => c.Value);
            return Ok("Hello " + identity.Name + "Your Role(s) are: " + string.Join(",", roles.ToList()));
        }
    }

}