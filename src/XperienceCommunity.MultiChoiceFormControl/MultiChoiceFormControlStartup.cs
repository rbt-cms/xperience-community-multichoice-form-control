
using Microsoft.Extensions.DependencyInjection;

using XperienceCommunity.MultiChoiceFormControl.Admin.Helpers.Components.MultiChoice;

namespace XperienceCommunity.MultiChoiceFormControl
{
    public static class MultiChoiceFormControlStartup
    {
        public static IServiceCollection AddAppAdminAuthentication(this IServiceCollection services) =>
      services.AddTransient<IMultiChoiceOptionsProviderActivator, MultiChoiceOptionsProviderActivator>();
    }
}
