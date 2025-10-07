using CMS.Core;

namespace XperienceCommunity.MultiChoiceFormControl.Admin.Helpers.Components.MultiChoice
{
    public static class MultiChoiceOptionsParser
    {
        //
        // Summary:
        //     Parses given dataSource by System.Environment.NewLine and given separator.
        public static IEnumerable<MultiChoiceOptionItem> ParseDataSourceToOptions(string dataSource, string separator, ILocalizationService localizationService) => KeyValueOptionsParser.ParseDataSource(dataSource, separator, (value, text) => new MultiChoiceOptionItem
        {
            Value = value,
            Text = localizationService.LocalizeString(text)
        });
    }
}
