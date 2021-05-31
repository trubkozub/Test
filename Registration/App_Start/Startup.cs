using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using Registration.Models;

[assembly: OwinStartup(typeof(AspNetIdentityApp.Startup))]

namespace AspNetIdentityApp
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
           
            app.CreatePerOwinContext<UserContext>(UserContext.Create);
            app.CreatePerOwinContext<UserManager>(UserManager.Create);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
            });
        }
    }
}