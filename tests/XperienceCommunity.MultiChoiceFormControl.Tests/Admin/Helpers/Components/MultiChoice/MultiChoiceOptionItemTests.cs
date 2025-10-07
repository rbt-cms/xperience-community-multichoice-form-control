

namespace XperienceCommunity.MultiChoiceFormControl.Admin.Helpers.Components.MultiChoice
{
    [TestFixture]
    public class MultiChoiceOptionItemTests
    {
        [Test]
        public void Value_SetAndGet_ReturnsExpectedValue()
        {
            // Arrange  
            var item = new MultiChoiceOptionItem
            {
                Value = "Option1"
            };

            // Assert  
            Assert.That(item.Value, Is.EqualTo("Option1"));
        }

        [Test]
        public void Text_SetAndGet_ReturnsExpectedText()
        {
            // Arrange  
            var item = new MultiChoiceOptionItem
            {
                Text = "Option Text"
            };

            // Assert  
            Assert.That(item.Text, Is.EqualTo("Option Text"));
        }

        [Test]
        public void Constructor_InitializesPropertiesToNull()
        {
            // Act  
            var item = new MultiChoiceOptionItem();

            // Assert  
            Assert.That(item.Value, Is.Null);
            Assert.That(item.Text, Is.Null);
        }

        [Test]
        public void Properties_CanBeSetToNull()
        {
            // Arrange  
            var item = new MultiChoiceOptionItem
            {
                Value = "Initial",
                Text = "Initial"
            };

            // Act  
            item.Value = null;
            item.Text = null;

            // Assert  
            Assert.That(item.Value, Is.Null);
            Assert.That(item.Text, Is.Null);
        }
    }
}
