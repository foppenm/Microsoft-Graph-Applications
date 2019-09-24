using GraphApplications.Core.Entities.GraphServiceBetaClient;
using GraphApplications.Core.Entities.MicrosoftGraph.Applications;
using GraphApplications.Core.Entities.MicrosoftGraph.ServicePrinciples;
using GraphApplications.Core.Interfaces;
using Microsoft.Identity.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace GraphApplications.Infrastructure
{
    public class GraphServiceBetaClient : IGraphServiceBetaClient
    {
        private readonly string _tenantId;
        private readonly string _clientId;
        private readonly string _clientSecret;
        private string _accessToken;
        private const string _endpoint = "https://graph.microsoft.com/beta";

        public GraphServiceBetaClient(string tenantId, string clientId, string clientSecret)
        {
            _tenantId = tenantId;
            _clientId = clientId;
            _clientSecret = clientSecret;
        }

        public async Task Authenticate()
        {
            _accessToken = await GetToken(_tenantId, _clientId, _clientSecret);
        }

        public async Task<List<ApplicationRegistration>> GetApplications()
        {
            // Get Applications For Current Tenant
            var applicationsJson = await GetFromGraph("/applications");
            var applications = JsonConvert.DeserializeObject<GraphApplicationsResult>(applicationsJson).Applications;
            if (applications == null)
                throw new InvalidOperationException("No Applications Found in your tenant");

            var principleCache = new List<ServicePrinciple>();
            var applicationRegistrations = new List<ApplicationRegistration>();
            foreach (var app in applications)
            {
                var application = new ApplicationRegistration
                {
                    Id = app.AppId,
                    DisplayName = app.DisplayName
                };

                if (app.PasswordCredentials.Any())
                    application.Secrets = app.PasswordCredentials.Select(s => $"{s.DisplayName} - Expires on: {s.EndDateTime.ToString("MM-dd-yyyy")}").ToList();

                if (app.KeyCredentials.Any())
                    application.Certificates = app.KeyCredentials.Select(x => $"{x.CustomKeyIdentifier} - Expires on: {x.EndDateTime.ToString("MM-dd-yyyy")}").ToList();

                var ownersJson = await GetFromGraph($"/applications/{app.Id}/owners");
                var owners = JsonConvert.DeserializeObject<GraphOwnerResult>(ownersJson).Value;
                application.Owners = owners.Select(x => x.UserPrincipalName).ToList();

                foreach (var requiredAccess in app.RequiredResourceAccess)
                {
                    // Retrieve the service principle form cache or when not found from the graph api
                    ServicePrinciple currentPrinciple = null;
                    if (principleCache.Any(x => x.AppId == requiredAccess.ResourceAppId))
                    {
                        currentPrinciple = principleCache.First(x => x.AppId == requiredAccess.ResourceAppId);
                    }
                    else
                    {
                        var getServicePrinciple = $"/servicePrincipals?filter=appId eq '{requiredAccess.ResourceAppId}'";
                        var principleFromGraph = await GetFromGraph(getServicePrinciple);
                        currentPrinciple = JsonConvert.DeserializeObject<ServicePrinciplesGraphResult>(principleFromGraph).ServicePrinciples?.FirstOrDefault();

                        if (currentPrinciple == null)
                            continue;

                        principleCache.Add(currentPrinciple);
                    }

                    // Approles -> Application Permissions
                    // PermissionScopes -> Delegated Permissions

                    var applicationRegistrationServices = new ApplicationRegistrationServices
                    {
                        DisplayName = currentPrinciple.AppDisplayName,
                        DelegatedPermissions = currentPrinciple.PublishedPermissionScopes
                        .Where(x => requiredAccess.ResourceAccess.Any(r => r.Id == x.Id))
                        .Select(s => new DelegatedPermission
                        {
                            DisplayName = s.UserConsentDisplayName,
                            Id = s.Id,
                            Permission = s.Value
                        }),
                        ApplicationPermissions = currentPrinciple.AppRoles
                        .Where(x => requiredAccess.ResourceAccess.Any(r => r.Id == x.Id))
                        .Select(s => new ApplicationPermission
                        {
                            DisplayName = s.DisplayName,
                            Id = s.Id,
                            Permission = s.Value
                        })
                    };
                    application.Services.Add(applicationRegistrationServices);
                }
                applicationRegistrations.Add(application);
            }

            return applicationRegistrations;
        }

        private async Task<string> GetToken(
           string tenantId,
           string clientId,
           string clientSecret)
        {
            var ccab = ConfidentialClientApplicationBuilder
                .Create(clientId)
                .WithClientSecret(clientSecret)
                .WithTenantId(tenantId)
                .Build();

            var tokenResult = ccab.AcquireTokenForClient(new List<string> { "https://graph.microsoft.com/.default" });
            var token = await tokenResult.ExecuteAsync();
            return token.AccessToken;
        }

        private async Task<string> GetFromGraph(
            string action)
        {
            using (var request = new HttpRequestMessage(HttpMethod.Get, _endpoint + action))
            {
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken);

                using (var client = new HttpClient())
                using (var response = await client.SendAsync(request))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        return result;
                    }

                    return string.Empty;
                }
            }
        }
    }
}
