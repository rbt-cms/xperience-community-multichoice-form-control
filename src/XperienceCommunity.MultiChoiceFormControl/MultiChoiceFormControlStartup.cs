using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using XperienceCommunity.MultiChoiceFormControl.Admin.Helpers.Components.MultiChoice;

namespace XperienceCommunity.MultiChoiceFormControl
{
    public static class MultiChoiceFormControlStartup
    {
        public static IServiceCollection AddAppAdminAuthentication(this IServiceCollection services, IConfiguration config) =>
      services.AddTransient<IMultiChoiceOptionsProviderActivator, MultiChoiceOptionsProviderActivator>();
    }
}
