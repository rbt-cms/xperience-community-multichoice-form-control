

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
        private Mock<ILocalizationService> localizationServiceMock = null!;
        private Mock<IMultiChoiceOptionsProviderActivator> optionsProviderActivatorMock = null!;
        private Mock<IMultiChoiceOptionsProvider> optionsProviderMock = null!;

        [SetUp]
        public void SetUp()
        {
            localizationServiceMock = new Mock<ILocalizationService>();
            //localizationServiceMock.Setup(x => x.LocalizeString(It.IsAny<string>(), It.IsAny<string>() ?? string.Empty))
            //    .Returns((string s, string arg) => s);
            //localizationServiceMock.Setup(x => x.GetString(It.IsAny<string>(), It.IsAny<string>() ?? string.Empty))
            //    .Returns((string s, string arg) => s);

            optionsProviderActivatorMock = new Mock<IMultiChoiceOptionsProviderActivator>();
            optionsProviderMock = new Mock<IMultiChoiceOptionsProvider>();
        }
    }
}
