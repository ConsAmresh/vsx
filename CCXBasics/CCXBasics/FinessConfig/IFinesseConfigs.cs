using System.Net;

namespace CCXBasics.cisco.FinessConfig
{
    public interface IFinesseConfigs
    {
        HttpStatusCode GetServerVersionInfo();
        void GetSystemConfig();
        void SendHTTPRequest();
        HttpStatusCode UpdateStatus(string status);
    }
}