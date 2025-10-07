

using CMS.Core;

using Moq;

using XperienceCommunity.MultiChoiceFormControl.MultiChoiceFormComponent;

namespace XperienceCommunity.MultiChoiceFormControl.Admin.Helpers.Components.MultiChoice
{
    public class TestProperties : MultiChoiceFormComponentProperties
    {
        public TestProperties() => OptionsValueSeparator = ";";
    }

    public class TestClientProperties : MultiChoiceFormComponentClientProperties { }

    public class TestMultiChoiceComponent : MultiChoiceComponentBase<TestProperties, TestClientProperties>
    {
        public TestMultiChoiceComponent(ILocalizationService localizationService, IMultiChoiceOptionsProviderActivator optionsProviderActivator)
            : base(localizationService, optionsProviderActivator) { }

        public new async Task<IEnumerable<MultiChoiceOptionItem>> GetOptions() => await base.GetOptions();

        public TestProperties SetProperties => Properties;

        public override string ClientComponentName => "TestMultiChoiceComponent";
    }

    [TestFixture]
    public class MultiChoiceComponentBaseTests
    {
        public Mock<ILocalizationService> LocalizationServiceMock = null!;
        public Mock<IMultiChoiceOptionsProviderActivator> OptionsProviderActivatorMock = null!;
        public Mock<IMultiChoiceOptionsProvider> OptionsProviderMock = null!;

        [SetUp]
        public void SetUp()
        {
            LocalizationServiceMock = new Mock<ILocalizationService>();

            OptionsProviderActivatorMock = new Mock<IMultiChoiceOptionsProviderActivator>();
            OptionsProviderMock = new Mock<IMultiChoiceOptionsProvider>();
        }
    }
}
