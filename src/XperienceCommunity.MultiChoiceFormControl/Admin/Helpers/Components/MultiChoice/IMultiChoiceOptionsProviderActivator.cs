using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace XperienceCommunity.MultiChoiceFormControl.Admin.Helpers.Components.MultiChoice
{
    public interface IMultiChoiceOptionsProviderActivator
    {
        IMultiChoiceOptionsProvider Activate(Type dataProviderType);
    }

    public class MultiChoiceOptionsProviderActivator(IHttpContextAccessor httpContextAccessor) : IMultiChoiceOptionsProviderActivator
    {

        private readonly IHttpContextAccessor httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));

        public IMultiChoiceOptionsProvider Activate(Type optionsProviderType)
        {
            if (optionsProviderType == null)
            {
                throw new ArgumentNullException("optionsProviderType");
            }
            if (!optionsProviderType.IsAssignableTo(typeof(IMultiChoiceOptionsProvider)))
            {
                throw new InvalidOperationException($"The class {optionsProviderType.Name} does not implement the {"IMultiChoiceOptionsProvider"} interface.");
            }
            return (IMultiChoiceOptionsProvider)ActivatorUtilities.CreateInstance(httpContextAccessor.HttpContext.RequestServices, optionsProviderType);
        }
    }
}
