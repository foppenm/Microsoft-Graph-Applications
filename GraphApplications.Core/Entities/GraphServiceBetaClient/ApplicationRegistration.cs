using System.Collections.Generic;

namespace GraphApplications.Core.Entities.GraphServiceBetaClient
{
    public class ApplicationRegistration
    {
        public string DisplayName { get; set; }
        public List<ApplicationRegistrationServices> Services { get; set; } = new List<ApplicationRegistrationServices>();
        public List<string> Secrets { get; set; } = new List<string>();
        public List<string> Owners { get; set; } = new List<string>();
        public string Id { get; set; }
        public List<string> Certificates { get; set; } = new List<string>();
    }
}
