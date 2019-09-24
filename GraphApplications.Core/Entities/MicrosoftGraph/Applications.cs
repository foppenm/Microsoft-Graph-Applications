using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace GraphApplications.Core.Entities.MicrosoftGraph.Applications
{
    public class Oauth2PermissionScopes
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

    public class Api
    {

        [JsonProperty("requestedAccessTokenVersion")]
        public int? RequestedAccessTokenVersion { get; set; }

        [JsonProperty("acceptMappedClaims")]
        public object AcceptMappedClaims { get; set; }

        [JsonProperty("knownClientApplications")]
        public IList<object> KnownClientApplications { get; set; }

        [JsonProperty("oauth2PermissionScopes")]
        public IList<Oauth2PermissionScopes> Oauth2PermissionScopes { get; set; }

        [JsonProperty("preAuthorizedApplications")]
        public IList<object> PreAuthorizedApplications { get; set; }
    }

    public class PublicClient
    {

        [JsonProperty("redirectUris")]
        public IList<string> RedirectUris { get; set; }
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

    public class ParentalControlSettings
    {

        [JsonProperty("countriesBlockedForMinors")]
        public IList<object> CountriesBlockedForMinors { get; set; }

        [JsonProperty("legalAgeGroupRule")]
        public string LegalAgeGroupRule { get; set; }
    }

    public class PasswordCredential
    {

        [JsonProperty("customKeyIdentifier")]
        public string CustomKeyIdentifier { get; set; }

        [JsonProperty("endDateTime")]
        public DateTime EndDateTime { get; set; }

        [JsonProperty("keyId")]
        public string KeyId { get; set; }

        [JsonProperty("startDateTime")]
        public DateTime StartDateTime { get; set; }

        [JsonProperty("secretText")]
        public object SecretText { get; set; }

        [JsonProperty("hint")]
        public string Hint { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }
    }

    public class ResourceAccess
    {

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public class RequiredResourceAccess
    {

        [JsonProperty("resourceAppId")]
        public string ResourceAppId { get; set; }

        [JsonProperty("resourceAccess")]
        public IList<ResourceAccess> ResourceAccess { get; set; }
    }

    public class ImplicitGrantSettings
    {

        [JsonProperty("enableIdTokenIssuance")]
        public bool EnableIdTokenIssuance { get; set; }

        [JsonProperty("enableAccessTokenIssuance")]
        public bool EnableAccessTokenIssuance { get; set; }
    }

    public class Web
    {

        [JsonProperty("redirectUris")]
        public IList<string> RedirectUris { get; set; }

        [JsonProperty("homePageUrl")]
        public string HomePageUrl { get; set; }

        [JsonProperty("logoutUrl")]
        public object LogoutUrl { get; set; }

        [JsonProperty("implicitGrantSettings")]
        public ImplicitGrantSettings ImplicitGrantSettings { get; set; }
    }

    public class Certificate
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

    public class GraphApplication
    {

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("deletedDateTime")]
        public object DeletedDateTime { get; set; }

        [JsonProperty("isFallbackPublicClient")]
        public bool? IsFallbackPublicClient { get; set; }

        [JsonProperty("appId")]
        public string AppId { get; set; }

        [JsonProperty("applicationTemplateId")]
        public object ApplicationTemplateId { get; set; }

        [JsonProperty("identifierUris")]
        public IList<string> IdentifierUris { get; set; }

        [JsonProperty("createdDateTime")]
        public DateTime CreatedDateTime { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("isDeviceOnlyAuthSupported")]
        public object IsDeviceOnlyAuthSupported { get; set; }

        [JsonProperty("groupMembershipClaims")]
        public object GroupMembershipClaims { get; set; }

        [JsonProperty("optionalClaims")]
        public object OptionalClaims { get; set; }

        [JsonProperty("orgRestrictions")]
        public IList<object> OrgRestrictions { get; set; }

        [JsonProperty("publisherDomain")]
        public string PublisherDomain { get; set; }

        [JsonProperty("signInAudience")]
        public string SignInAudience { get; set; }

        [JsonProperty("tags")]
        public IList<string> Tags { get; set; }

        [JsonProperty("tokenEncryptionKeyId")]
        public object TokenEncryptionKeyId { get; set; }

        [JsonProperty("api")]
        public Api Api { get; set; }

        [JsonProperty("appRoles")]
        public IList<object> AppRoles { get; set; }

        [JsonProperty("publicClient")]
        public PublicClient PublicClient { get; set; }

        [JsonProperty("info")]
        public Info Info { get; set; }

        [JsonProperty("keyCredentials")]
        public IList<Certificate> KeyCredentials { get; set; }

        [JsonProperty("parentalControlSettings")]
        public ParentalControlSettings ParentalControlSettings { get; set; }

        [JsonProperty("passwordCredentials")]
        public IList<PasswordCredential> PasswordCredentials { get; set; }

        [JsonProperty("requiredResourceAccess")]
        public IList<RequiredResourceAccess> RequiredResourceAccess { get; set; }

        [JsonProperty("web")]
        public Web Web { get; set; }
    }

    public class GraphApplicationsResult
    {

        [JsonProperty("@odata.context")]
        public string OdataContext { get; set; }

        [JsonProperty("value")]
        public IList<GraphApplication> Applications { get; set; }
    }
}
