using CMS.Core;

using XperienceCommunity.MultiChoiceFormControl.Admin.Helpers.Components.MultiChoice;

#pragma warning disable IDE0060, S2325, S927, S1006, S4136

namespace XperienceCommunity.MultiChoiceFormControl
{
    [SetUpFixture]
    public class KenticoTestBootstrap
    {
        [OneTimeSetUp]
        public void Init()
        {
            Service.Use<ILocalizationService>(new FakeLocalizationService());
            Service.Use<IMultiChoiceOptionsProviderActivator>(new FakeOptionsActivator());
            Service.Use<IMultiChoiceOptionsProvider>(new FakeOptionsProvider());

            Service.InitializeContainer();

            var loc = Service.Resolve<ILocalizationService>();
            Console.WriteLine($"KenticoTestBootstrap: {loc?.GetType().Name} registered successfully");
        }
    }

    public class FakeLocalizationService : ILocalizationService
    {
        public string GetString(string resourceKey) => resourceKey;

        public string GetString(string resourceKey, string culture) => resourceKey;

        public string GetString(string resourceKey, string culture, bool useDefaultCulture) => resourceKey;

        public string LocalizeString(string resourceKey, string culture, bool useDefaultCulture, bool encode) => resourceKey;

        public string LocalizeExpression(
            string expression,
            string culture,
            bool useDefaultCulture,
            Func<string, string, bool, string>? getString = null,
            bool encode = false
        ) => expression;

        public string GetString(string resourceKey, string culture, string defaultValue)
            => defaultValue ?? resourceKey;
    }

    public class FakeOptionsActivator : IMultiChoiceOptionsProviderActivator
    {
        public IMultiChoiceOptionsProvider Activate(Type dataProviderType)
            => new FakeOptionsProvider();
    }

    public class FakeOptionsProvider : IMultiChoiceOptionsProvider
    {
        public Task<IEnumerable<MultiChoiceOptionItem>> GetOptionsAsync()
            => Task.FromResult<IEnumerable<MultiChoiceOptionItem>>(new[]
            {
                new MultiChoiceOptionItem { Text = "Option 1", Value = "1" }
            });

        public Task<IEnumerable<MultiChoiceOptionItem>> GetOptionItems()
            => Task.FromResult<IEnumerable<MultiChoiceOptionItem>>(new[]
            {
                new MultiChoiceOptionItem { Text = "Option 1", Value = "1" }
            });
    }
}
#pragma warning disable IDE0060, S2325, S927, S1006, S4136
