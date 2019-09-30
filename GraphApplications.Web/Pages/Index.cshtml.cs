using GraphApplications.Core.Entities.GraphServiceBetaClient;
using GraphApplications.Core.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphApplications.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IGraphServiceBetaClient _graphServiceBetaClient;
        public List<ApplicationRegistration> Applications;
        public int NumberOfApplications;
        public int AppsWithoutSecretsOrCertificates;

        public IndexModel(ILogger<IndexModel> logger, IGraphServiceBetaClient graphServiceBetaClient)
        {
            _logger = logger;
            _graphServiceBetaClient = graphServiceBetaClient;
        }

        public async Task OnGet()
        {
            Applications = await _graphServiceBetaClient.GetApplications();
            NumberOfApplications = Applications.Count();
            AppsWithoutSecretsOrCertificates = Applications.Where(a =>
                !a.Certificates.Any()
                && !a.Secrets.Any()
                && a.Services.Any(s =>
                    s.ApplicationPermissions.Any())).Count();
        }
    }
}
