using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CMS.Core;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using XperienceCommunity.MultiChoiceFormControl.Admin.Helpers.Components.MultiChoice;

namespace XperienceCommunity.MultiChoiceFormControl
{
    [SetUpFixture]
    public class KenticoTestBootstrap
    {
        [OneTimeSetUp]
        public void Init()
        {
            // ✅ Register fake services directly in Kentico's static container
            Service.Use<ILocalizationService>(new FakeLocalizationService());
            Service.Use<IMultiChoiceOptionsProviderActivator>(new FakeOptionsActivator());
            Service.Use<IMultiChoiceOptionsProvider>(new FakeOptionsProvider());

            // ✅ Initialize container state
            Service.InitializeContainer();

            // Optional sanity check
            var loc = Service.Resolve<ILocalizationService>();
            Console.WriteLine($"KenticoTestBootstrap: {loc?.GetType().Name} registered successfully");
        }
    }

    // ---- FAKES ----
    public class FakeLocalizationService : ILocalizationService
    {
        public string GetString(string resourceKey) => resourceKey;
        public string GetString(string resourceKey, string culture) => resourceKey;
        public string GetString(string resourceKey, string culture, bool useDefaultCulture = false) => resourceKey;
        public string GetString(string resourceKey, string culture, string defaultValue) => defaultValue ?? resourceKey;

        public string LocalizeString(string resourceKey, string culture, bool useDefaultCulture, bool logMissing)
            => resourceKey;

        public string LocalizeExpression(
            string expression,
            string culture,
            bool useDefaultCulture,
            Func<string, string, bool, string> stringLocalizer,
            bool logMissing)
            => expression;
    }

    public class FakeOptionsActivator : IMultiChoiceOptionsProviderActivator
    {
        public IMultiChoiceOptionsProvider Activate(Type dataProviderType)
            => new FakeOptionsProvider();
    }

    public class FakeOptionsProvider : IMultiChoiceOptionsProvider
    {
        public Task<IEnumerable<MultiChoiceOptionItem>> GetOptionsAsync()
            => Task.FromResult<IEnumerable<MultiChoiceOptionItem>>(new List<MultiChoiceOptionItem>
            {
            new MultiChoiceOptionItem { Text = "Option 1", Value = "1" }
            });

        public Task<IEnumerable<MultiChoiceOptionItem>> GetOptionItems()
            => Task.FromResult<IEnumerable<MultiChoiceOptionItem>>(new List<MultiChoiceOptionItem>
            {
            new MultiChoiceOptionItem { Text = "Option 1", Value = "1" }
            });
    }

}
