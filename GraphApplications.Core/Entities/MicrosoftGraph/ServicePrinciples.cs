using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace GraphApplications.Core.Entities.MicrosoftGraph.ServicePrinciples
{
    public class Api
    {

        [JsonProperty("resourceSpecificApplicationPermissions")]
        public IList<object> ResourceSpecificApplicationPermissions { get; set; }
    }

    public class Info
    {

        [JsonProperty("termsOfServiceUrl")]
        public object TermsOfServiceUrl { get; set; }

        [JsonProperty("supportUrl")]
        public object SupportUrl { get; set; }

        [JsonProperty("privacyStatementUrl")]
        public object PrivacyStatementUrl { get; set; }

        [JsonProperty("marketingUrl")]
        public object MarketingUrl { get; set; }

        [JsonProperty("logoUrl")]
        public object LogoUrl { get; set; }
    }

    public class PublishedPermissionScope
    {

        [JsonProperty("adminConsentDescription")]
        public string AdminConsentDescription { get; set; }

        [JsonProperty("adminConsentDisplayName")]
        public string AdminConsentDisplayName { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("isEnabled")]
        public bool IsEnabled { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("userConsentDescription")]
        public string UserConsentDescription { get; set; }

        [JsonProperty("userConsentDisplayName")]
        public string UserConsentDisplayName { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }

    public class AppRole
    {

        [JsonProperty("allowedMemberTypes")]
        public IList<string> AllowedMemberTypes { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("isEnabled")]
        public bool IsEnabled { get; set; }

        [JsonProperty("origin")]
        public string Origin { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }

    public class KeyCredential
    {

        [JsonProperty("customKeyIdentifier")]
        public string CustomKeyIdentifier { get; set; }

        [JsonProperty("endDateTime")]
        public DateTime EndDateTime { get; set; }

        [JsonProperty("keyId")]
        public string KeyId { get; set; }

        [JsonProperty("startDateTime")]
        public DateTime StartDateTime { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("usage")]
        public string Usage { get; set; }

        [JsonProperty("key")]
        public object Key { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }
    }

    public class ServicePrinciple
    {

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("deletedDateTime")]
        public object DeletedDateTime { get; set; }

        [JsonProperty("accountEnabled")]
        public bool AccountEnabled { get; set; }

        [JsonProperty("api")]
        public Api Api { get; set; }

        [JsonProperty("appDisplayName")]
        public string AppDisplayName { get; set; }

        [JsonProperty("appId")]
        public string AppId { get; set; }

        [JsonProperty("applicationTemplateId")]
        public object ApplicationTemplateId { get; set; }

        [JsonProperty("appOwnerOrganizationId")]
        public string AppOwnerOrganizationId { get; set; }

        [JsonProperty("appRoleAssignmentRequired")]
        public bool AppRoleAssignmentRequired { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("errorUrl")]
        public object ErrorUrl { get; set; }

        [JsonProperty("homepage")]
        public string Homepage { get; set; }

        [JsonProperty("info")]
        public Info Info { get; set; }

        [JsonProperty("logoutUrl")]
        public string LogoutUrl { get; set; }

        [JsonProperty("notificationEmailAddresses")]
        public IList<object> NotificationEmailAddresses { get; set; }

        [JsonProperty("publishedPermissionScopes")]
        public IList<PublishedPermissionScope> PublishedPermissionScopes { get; set; }

        [JsonProperty("preferredSingleSignOnMode")]
        public object PreferredSingleSignOnMode { get; set; }

        [JsonProperty("preferredTokenSigningKeyEndDateTime")]
        public object PreferredTokenSigningKeyEndDateTime { get; set; }

        [JsonProperty("preferredTokenSigningKeyThumbprint")]
        public object PreferredTokenSigningKeyThumbprint { get; set; }

        [JsonProperty("publisherName")]
        public string PublisherName { get; set; }

        [JsonProperty("replyUrls")]
        public IList<string> ReplyUrls { get; set; }

        [JsonProperty("samlMetadataUrl")]
        public object SamlMetadataUrl { get; set; }

        [JsonProperty("samlSingleSignOnSettings")]
        public object SamlSingleSignOnSettings { get; set; }

        [JsonProperty("servicePrincipalNames")]
        public IList<string> ServicePrincipalNames { get; set; }

        [JsonProperty("signInAudience")]
        public string SignInAudience { get; set; }

        [JsonProperty("tags")]
        public IList<string> Tags { get; set; }

        [JsonProperty("addIns")]
        public IList<object> AddIns { get; set; }

        [JsonProperty("appRoles")]
        public IList<AppRole> AppRoles { get; set; }

        [JsonProperty("keyCredentials")]
        public IList<KeyCredential> KeyCredentials { get; set; }

        [JsonProperty("passwordCredentials")]
        public IList<object> PasswordCredentials { get; set; }
    }

    public class ServicePrinciplesGraphResult
    {

        [JsonProperty("@odata.context")]
        public string OdataContext { get; set; }

        [JsonProperty("@odata.nextLink")]
        public string OdataNextLink { get; set; }

        [JsonProperty("value")]
        public IList<ServicePrinciple> ServicePrinciples { get; set; }
    }


}
