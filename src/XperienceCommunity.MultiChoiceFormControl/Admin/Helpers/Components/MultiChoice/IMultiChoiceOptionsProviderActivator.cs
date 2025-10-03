using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace XperienceCommunity.MultiChoiceFormControl.Admin.Helpers.Components.MultiChoice
{
    public interface IMultiChoiceOptionsProviderActivator
    {
        public IMultiChoiceOptionsProvider Activate(Type dataProviderType);
    }

    public class MultiChoiceOptionsProviderActivator(IHttpContextAccessor httpContextAccessor) : IMultiChoiceOptionsProviderActivator
    {

        private readonly IHttpContextAccessor httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));

        public IMultiChoiceOptionsProvider Activate(Type dataProviderType)
        {
            ArgumentNullException.ThrowIfNull(dataProviderType);
            if (!dataProviderType.IsAssignableTo(typeof(IMultiChoiceOptionsProvider)))
            {
                throw new InvalidOperationException($"The class {dataProviderType.Name} does not implement the {"IMultiChoiceOptionsProvider"} interface.");
            }
            return (IMultiChoiceOptionsProvider)ActivatorUtilities.CreateInstance(httpContextAccessor.HttpContext.RequestServices, dataProviderType);
        }
    }
}
