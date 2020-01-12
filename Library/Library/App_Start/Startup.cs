using Microsoft.Owin;
using Owin;
using Library.Models;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity;

[assembly: OwinStartup(typeof(Library.Startup))]

namespace Library
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //app.UseCookieAuthentication(new CookieAuthenticationOptions
            //{
            //    AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
            //    LoginPath = new PathString("/Account/Login"),
            //});
        }
    }
}