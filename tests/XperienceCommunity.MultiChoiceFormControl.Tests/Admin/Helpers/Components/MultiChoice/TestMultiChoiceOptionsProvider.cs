

namespace XperienceCommunity.MultiChoiceFormControl.Admin.Helpers.Components.MultiChoice
{
    public class TestMultiChoiceOptionsProvider : IMultiChoiceOptionsProvider
    {
        public Task<IEnumerable<MultiChoiceOptionItem>> GetOptionItems()
        {
            var items = new List<MultiChoiceOptionItem>
                   {
                       new() { Value = "A", Text = "Alpha" },
                       new() { Value = "B", Text = "Beta" }
                   };
            return Task.FromResult<IEnumerable<MultiChoiceOptionItem>>(items);
        }
    }

    [TestFixture]
    public class MultiChoiceOptionsProviderTests
    {
        [Test]
        public async Task GetOptionItems_ReturnsExpectedItems()
        {
            // Arrange
            var provider = new TestMultiChoiceOptionsProvider();

            // Act
            var items = await provider.GetOptionItems();

            // Assert
            Assert.That(items, Is.Not.Null);
            var itemList = new List<MultiChoiceOptionItem>(items);
            Assert.That(itemList.Count, Is.EqualTo(2));
            Assert.That(itemList[0].Value, Is.EqualTo("A"));
            Assert.That(itemList[0].Text, Is.EqualTo("Alpha"));
            Assert.That(itemList[1].Value, Is.EqualTo("B"));
            Assert.That(itemList[1].Text, Is.EqualTo("Beta"));
        }

        [Test]
        public async Task GetOptionItems_CanReturnEmptyList()
        {
            // Arrange
            var provider = new EmptyMultiChoiceOptionsProvider();

            // Act
            var items = await provider.GetOptionItems();

            // Assert
            Assert.That(items, Is.Empty);
        }

        private class EmptyMultiChoiceOptionsProvider : IMultiChoiceOptionsProvider
        {
            public Task<IEnumerable<MultiChoiceOptionItem>> GetOptionItems() => Task.FromResult(Enumerable.Empty<MultiChoiceOptionItem>());
        }
    }
}
