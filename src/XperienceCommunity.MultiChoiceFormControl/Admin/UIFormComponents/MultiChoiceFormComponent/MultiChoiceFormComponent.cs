using CMS.Core;
using Kentico.Xperience.Admin.Base.FormAnnotations;
using Kentico.Xperience.Admin.Base.Forms;

using XperienceCommunity.MultiChoiceFormControl.Admin;
using XperienceCommunity.MultiChoiceFormControl.Admin.Helpers.Components.MultiChoice;
using XperienceCommunity.MultiChoiceFormControl.MultiChoiceFormComponent;

[assembly: RegisterFormComponent(MultiChoiceFormComponent.IDENTIFIER, typeof(MultiChoiceFormComponent), "Multi Choice selector")]
namespace XperienceCommunity.MultiChoiceFormControl.MultiChoiceFormComponent
{
    [ComponentAttribute(typeof(MultiChoicComponentAttribute))]
    [ComponentAvailableForFieldDataType(["text"])]
    public class MultiChoiceFormComponent : MultiChoiceComponentBase<MultiChoiceFormComponentProperties, MultiChoiceFormComponentClientProperties>
    {
        public const string IDENTIFIER = "XperienceCommunity.Multichoiceformcontrol.MultiChoice";
        public override string ClientComponentName => "@xperiencecommunity/multichoiceformcontrol/MultiChoice";
        public MultiChoiceFormComponent(ILocalizationService localizationService) : base(localizationService)
        {
        }

        internal MultiChoiceFormComponent(ILocalizationService localizationService, IMultiChoiceOptionsProviderActivator optionsProviderActivator)
        : base(localizationService, optionsProviderActivator)
        {
        }
    }

    /// <summary>
    /// Define Client properties class
    /// </summary>
    public class MultiChoiceFormComponentClientProperties : FormComponentClientProperties<string>
    {
        public IEnumerable<MultiChoiceOptionItem> Options { get; set; }
        public string Placeholder { get; set; }
        public string OptionsValueSeparator { get; set; }
    }

    /// <summary>
    /// Define Component properties
    /// </summary>
    public class MultiChoiceFormComponentProperties : FormComponentProperties
    {
        public Type DataProviderType { get; set; }
        [TextAreaComponent(Label = "{$base.forms.dropdown.options.label$}", ExplanationText = "{$base.forms.dropdown.options.explanation$}")]
        public string Options { get; set; }

        [TextInputComponent(Label = "{$base.forms.dropdown.optionsvalueseparator.label$}", ExplanationText = "{$base.forms.dropdown.optionsvalueseparator.explanation$}")]
        [RequiredValidationRule]
        public string OptionsValueSeparator { get; set; } = ";";
        internal IEnumerable<DropDownOptionItem> OptionsItems { get; set; }
        [TextInputComponent(Label = "{$base.forms.dropdown.placeholder.label$}", Tooltip = "{$base.forms.dropdown.placeholder.tooltip$}")]
        public string Placeholder { get; set; }
    }

    /// <summary>
    /// Define Component Attribute
    /// </summary>
    public class MultiChoicComponentAttribute : FormComponentAttribute
    {
        public Type DataProviderType { get; set; }
        public string Options { get; set; }
        public string OptionsValueSeparator { get; set; } = ";";
        public string Placeholder { get; set; }
    }
}
