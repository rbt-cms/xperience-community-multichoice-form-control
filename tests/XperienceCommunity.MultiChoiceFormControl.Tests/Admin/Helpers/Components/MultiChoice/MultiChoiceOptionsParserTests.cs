

using CMS.Core;

using Moq;

namespace XperienceCommunity.MultiChoiceFormControl.Admin.Helpers.Components.MultiChoice
{
    [TestFixture]
    public class MultiChoiceOptionsParserTests
    {
        private Mock<ILocalizationService> localizationServiceMock = null!; // Fixed CS8618 by initializing with null-forgiving operator  

        [SetUp]
        public void SetUp()
        {
            localizationServiceMock = new Mock<ILocalizationService>();
            localizationServiceMock.Setup(s => s.LocalizeString(It.IsAny<string>(), null, false, true))
       .Returns((string s, string? culture, bool encode, bool useDefaultCulture) => $"LOC_{s}");
        }

        [Test]
        public void ParseDataSourceToOptions_ParsesSingleOption()
        {
            // Arrange  
            string dataSource = "A|Alpha";
            string separator = "|";

            // Act  
            var result = MultiChoiceOptionsParser.ParseDataSourceToOptions(dataSource, separator, localizationServiceMock.Object).ToList();

            // Assert  
            Assert.That(result.Count, Is.EqualTo(1));
            Assert.That(result[0].Value, Is.EqualTo("A"));
            Assert.That(result[0].Text, Is.EqualTo("LOC_Alpha"));
        }

        [Test]
        public void ParseDataSourceToOptions_ParsesMultipleOptions()
        {
            // Arrange  
            string dataSource = "A|Alpha\nB|Beta";
            string separator = "|";

            // Act  
            var result = MultiChoiceOptionsParser.ParseDataSourceToOptions(dataSource, separator, localizationServiceMock.Object).ToList();

            // Assert  
            Assert.That(result.Count, Is.EqualTo(2));
            Assert.That(result[0].Value, Is.EqualTo("A"));
            Assert.That(result[0].Text, Is.EqualTo("LOC_Alpha"));
            Assert.That(result[1].Value, Is.EqualTo("B"));
            Assert.That(result[1].Text, Is.EqualTo("LOC_Beta"));
        }

        [Test]
        public void ParseDataSourceToOptions_EmptyDataSource_ReturnsEmpty()
        {
            // Arrange  
            string dataSource = "";
            string separator = "|";

            // Act  
            var result = MultiChoiceOptionsParser.ParseDataSourceToOptions(dataSource, separator, localizationServiceMock.Object);

            // Assert  
            Assert.That(result, Is.Empty);
        }

        [Test]
        public void ParseDataSourceToOptions_NullDataSource_ReturnsEmpty()
        {
            // Arrange  
            string? dataSource = null;
            string separator = "|";

            // Act  
            var result = MultiChoiceOptionsParser.ParseDataSourceToOptions(dataSource, separator, localizationServiceMock.Object);

            // Assert  
            Assert.That(result, Is.Empty);
        }

        [Test]
        public void ParseDataSourceToOptions_LocalizationServiceIsCalledForEachText()
        {
            // Arrange    
            string dataSource = "A|Alpha\nB|Beta";
            string separator = "|";

            // Act    
            MultiChoiceOptionsParser.ParseDataSourceToOptions(dataSource, separator, localizationServiceMock.Object).ToList();

            // Assert    
            var times = Times.Once;
            localizationServiceMock.Verify(s => s.LocalizeString("Alpha", null, false, true), times);
            localizationServiceMock.Verify(s => s.LocalizeString("Beta", null, false, true), times);
        }
    }
}

