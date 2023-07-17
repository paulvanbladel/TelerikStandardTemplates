using Telerik.Blazor.Services;
using TelerikDashboard.Shared.Resources;

namespace TelerikDashboard.Shared.Services
{
    public class ResxLocalizer : ITelerikStringLocalizer
    {
        public string this[string name]
        {
            get
            {
                return GetStringFromResource(name);
            }
        }

        public string GetStringFromResource(string key)
        {
            return TelerikMessages.ResourceManager.GetString(key, TelerikMessages.Culture);
        }
    }
}
