using CMS.Core;

using Moq;

using XperienceCommunity.MultiChoiceFormControl.Admin.Helpers.Components.MultiChoice;

namespace XperienceCommunity.MultiChoiceFormControl.Admin.UIFormComponents.MultiChoiceFormComponent
{
    [TestFixture]
    public class MultiChoiceFormComponentTests
    {
        private Mock<ILocalizationService> localizationServiceMock = null!;
        private Mock<IMultiChoiceOptionsProviderActivator> optionsProviderActivatorMock = null!;
        private Mock<IMultiChoiceOptionsProvider> optionsProviderMock = null!;

        [SetUp]
        public void SetUp()
        {
            localizationServiceMock = new Mock<ILocalizationService>();
            localizationServiceMock.Setup(x => x.LocalizeString(It.IsAny<string>(), null, false, true)).Returns((string s, string _, bool __, bool ___) => s);
            localizationServiceMock.Setup(x => x.GetString(It.IsAny<string>(), null, true)).Returns((string s, string _, bool __) => s);
            optionsProviderActivatorMock = new Mock<IMultiChoiceOptionsProviderActivator>();
            optionsProviderMock = new Mock<IMultiChoiceOptionsProvider>();
        }

        [Test]
        public void Constructor_SetsClientComponentName()
        {
            // Arrange & Act  
            var component = new MultiChoiceFormControl.MultiChoiceFormComponent.MultiChoiceFormComponent(localizationServiceMock.Object);

            // Assert  
            Assert.That(component.ClientComponentName, Is.EqualTo("@xperiencecommunity/multichoiceformcontrol/MultiChoice"));
        }


        [Test]
        public void Identifier_IsConstant() =>
            // Assert  
            Assert.That(MultiChoiceFormControl.MultiChoiceFormComponent.MultiChoiceFormComponent.IDENTIFIER, Is.EqualTo("XperienceCommunity.Multichoiceformcontrol.MultiChoice"));

        [Test]
        public async Task GetOptions_UsesDataProviderType_ReturnsProviderOptions()
        {
            // Arrange  
            var expectedOptions = new List<MultiChoiceOptionItem>
            {
                new() { Value = "A", Text = "Alpha" }
            };
            optionsProviderMock.Setup(x => x.GetOptionItems()).ReturnsAsync(expectedOptions);

            var providerType = typeof(FakeProvider);
            optionsProviderActivatorMock.Setup(x => x.Activate(providerType)).Returns(optionsProviderMock.Object);

            var component = new MultiChoiceFormControl.MultiChoiceFormComponent.MultiChoiceFormComponent(localizationServiceMock.Object, optionsProviderActivatorMock.Object);
            component.Properties.DataProviderType = providerType;

            // Act  
            var result = await component.GetOptions();

            // Assert  
            Assert.That(result, Is.EqualTo(expectedOptions));
        }

        [Test]
        public async Task GetOptions_UsesOptionsItems_ReturnsOptionsItems()
        {
            // Arrange  
            var optionsItems = new List<MultiChoiceOptionItem>
            {
                new() { Value = "B", Text = "Beta" }
            };
            var component = new MultiChoiceFormControl.MultiChoiceFormComponent.MultiChoiceFormComponent(localizationServiceMock.Object, optionsProviderActivatorMock.Object);
            //component.Properties.OptionsItems = optionsItems;

            // Act  
            var result = await component.GetOptions();

            // Assert  
            Assert.That(result, Is.EqualTo(optionsItems));
        }

        [Test]
        public async Task GetOptions_UsesOptionsString_ReturnsParsedOptions()
        {
            // Arrange  
            string optionsString = "C|Gamma";
            var component = new MultiChoiceFormControl.MultiChoiceFormComponent.MultiChoiceFormComponent(localizationServiceMock.Object, optionsProviderActivatorMock.Object);
            component.Properties.Options = optionsString;
            component.Properties.OptionsValueSeparator = "|";

            // Act  
            var result = await component.GetOptions();

            // Assert  
            var list = new List<MultiChoiceOptionItem>(result);
            Assert.That(list.Count, Is.EqualTo(1));
            Assert.That(list[0].Value, Is.EqualTo("C"));
            Assert.That(list[0].Text, Is.EqualTo("Gamma"));
        }

        private class FakeProvider : IMultiChoiceOptionsProvider
        {
            public Task<IEnumerable<MultiChoiceOptionItem>> GetOptionItems() =>
                Task.FromResult(Enumerable.Empty<MultiChoiceOptionItem>());
        }
    }
}
