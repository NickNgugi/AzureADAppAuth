using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using Owin;
using System.Configuration;
using System.Globalization;
using System.Threading.Tasks;

[assembly:OwinStartup(typeof(WebUI.App_Start.Startup))]
namespace WebUI.App_Start
{
    public class Startup
    {
        private static string clientId = ConfigurationManager.AppSettings["iad:ClientId"];
        private static string aadInstance = ConfigurationManager.AppSettings["iad:AADInstance"];
        private static string tenant = ConfigurationManager.AppSettings["iad:Tenant"];
        private static string postLogoutRedirectUri = ConfigurationManager.AppSettings["iad:PostLogoutRedirectUri"];

        string authority = string.Format(CultureInfo.InvariantCulture, aadInstance, tenant);

        public void Configuration(IAppBuilder app)
        {
            app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);
            app.UseCookieAuthentication(new CookieAuthenticationOptions());
            app.UseOpenIdConnectAuthentication(
                new OpenIdConnectAuthenticationOptions
                {
                    ClientId = clientId,
                    Authority = authority,
                    PostLogoutRedirectUri = postLogoutRedirectUri,
                    Notifications = new OpenIdConnectAuthenticationNotifications
                    {
                        AuthenticationFailed = context =>
                        {
                            context.HandleResponse();
                            context.Response.Redirect("Error/message=" + context.Exception.Message);
                            return Task.FromResult(0);
                        }
                    }
                });
        }
    }
}