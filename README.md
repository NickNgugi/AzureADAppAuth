# AzureADAppAuth
Sample Azure AD Authentication for .NET MVC app
Adopted from Sahil Malik's Pluralsight course: https://app.pluralsight.com/library/courses/azure-active-directory-developers/table-of-contents

### General Config 
Application URL:
https://localhost:44341/

### Nuget Packages:
Microsoft.Owin.Security.ActiveDirectory v3.0.1
-Microsoft.Owin (>= 3.1.0)
-Microsoft.Owin.Security (>= 3.1.0)
-Microsoft.Owin.Security.Jwt (>= 3.1.0)
-Microsoft.Owin.Security.OAuth (>= 3.1.0)
-Owin (>= 1.0.0)
-System.IdentityModel.Tokens.Jwt (>= 4.0.0)
Microsoft.Owin.Security.OpenIdConnect v3.0.1
-Microsoft.IdentityModel.Protocol.Extensions v1.0.0
Microsoft.Owin.Host.SystemWeb v3.0.1
Microsoft.Owin.Security.Cookies v3.0.1

### Setup
1. Create a bolierplate .NET 4.5 MVC app
2. Install Nuget packages above
3. In web.config settup Azure AD coordinates:
> <add key="iad:ClientId" value="" /> <!--ApplicationId-->
> <add key="iad:AADInstance" value="http://login.microsoftonline.com/{0}" />
> <add key="iad:Tenant" value="" />
> <add key="iad:PostLogoutRedirectUri" value="https://localhost:44341" />
