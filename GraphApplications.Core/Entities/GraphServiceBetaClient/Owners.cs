using Newtonsoft.Json;
using System.Collections.Generic;

namespace GraphApplications.Core.Entities.GraphServiceBetaClient
{
    public class Owner
    {

        [JsonProperty("@odata.type")]
        public string OdataType { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("userPrincipalName")]
        public string UserPrincipalName { get; set; }
    }

    public class GraphOwnerResult
    {

        [JsonProperty("@odata.context")]
        public string OdataContext { get; set; }

        [JsonProperty("value")]
        public IList<Owner> Value { get; set; }
    }
}
