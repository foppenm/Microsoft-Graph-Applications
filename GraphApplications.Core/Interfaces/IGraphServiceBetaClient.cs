using GraphApplications.Core.Entities.GraphServiceBetaClient;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphApplications.Core.Interfaces
{
    public interface IGraphServiceBetaClient
    {
        Task Authenticate();
        Task<List<ApplicationRegistration>> GetApplications();
    }
}
