using System.Collections.Generic;

namespace GraphApplications.Core.Entities.GraphServiceBetaClient
{
    public class ApplicationRegistrationServices
    {
        public string DisplayName { get; set; }
        public IEnumerable<DelegatedPermission> DelegatedPermissions { get; set; }
        public IEnumerable<ApplicationPermission> ApplicationPermissions { get; set; }
    }
}
