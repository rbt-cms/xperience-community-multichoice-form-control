using CMS.Core;

using Kentico.Xperience.Admin.Base.Forms;

using XperienceCommunity.MultiChoiceFormControl.MultiChoiceFormComponent;

namespace XperienceCommunity.MultiChoiceFormControl.Admin.Helpers.Components.MultiChoice
{
    public abstract class MultiChoiceComponentBase<TProperties, TClientProperties> : FormComponent<TProperties, TClientProperties, string> where TProperties : MultiChoiceFormComponentProperties, new() where TClientProperties : MultiChoiceFormComponentClientProperties, new()
    {
        private readonly ILocalizationService localizationService;
        private readonly IMultiChoiceOptionsProviderActivator optionsProviderActivator;

        protected MultiChoiceComponentBase(ILocalizationService localizationService)
            : this(localizationService, Service.Resolve<IMultiChoiceOptionsProviderActivator>())
        {
        }

        protected MultiChoiceComponentBase(ILocalizationService localizationService, IMultiChoiceOptionsProviderActivator optionsProviderActivator)
        {
            this.localizationService = localizationService ?? throw new ArgumentNullException(nameof(localizationService));
            this.optionsProviderActivator = optionsProviderActivator ?? throw new ArgumentNullException(nameof(optionsProviderActivator));
        }

        /// <summary>
        /// Configure client properties to return to react component
        /// </summary>
        /// <param name="clientProperties"></param>
        /// <returns></returns>
        protected override async Task ConfigureClientProperties(TClientProperties clientProperties)
        {
            clientProperties.Placeholder = !string.IsNullOrEmpty(Properties.Placeholder) ? localizationService.LocalizeString(Properties.Placeholder) : localizationService.GetString("base.forms.dropdown.placeholder");
            clientProperties.Options = await GetOptions();
            clientProperties.OptionsValueSeparator = !string.IsNullOrEmpty(Properties.OptionsValueSeparator) ? localizationService.LocalizeString(Properties.OptionsValueSeparator) : ";";
            await base.ConfigureClientProperties(clientProperties);
        }

        /// <summary>
        /// Get Options for multichoice selector
        /// </summary>
        /// <returns></returns>
        protected async Task<IEnumerable<MultiChoiceOptionItem>> GetOptions()
        {
            if (Properties.DataProviderType != null)
            {
                var multiChoiceOptionsProvider = optionsProviderActivator.Activate(Properties.DataProviderType);
                if (multiChoiceOptionsProvider is IFieldEditorFormContextConsumer fieldEditorFormContextConsumer && FormContext is FieldEditorFormContext fieldEditorContext)
                {
                    fieldEditorFormContextConsumer.FieldEditorContext = fieldEditorContext;
                }

                return await multiChoiceOptionsProvider.GetOptionItems();
            }

            if (Properties.OptionsItems != null)
            {
                return (IEnumerable<MultiChoiceOptionItem>)Properties.OptionsItems;
            }

            return MultiChoiceOptionsParser.ParseDataSourceToOptions(Properties.Options, Properties.OptionsValueSeparator, localizationService);
        }
    }
}
