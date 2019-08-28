using ConnectorWebHook.Models;

namespace ConnectorWebHook.BLL
{
    public interface IWebHookDelivery
    {
        string SendWebHookPayload(IWebHookPayload payload, bool addAtSymboleToType = true, bool addAtSymboleToContext = true);
    }
}