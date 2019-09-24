namespace GraphApplications.Core.Interfaces
{
    public interface ICachingService
    {
        string Get(string key);
        void Store(string key, string value);
    }
}
