namespace XperienceCommunity.MultiChoiceFormControl.Admin.Helpers.Components.MultiChoice
{
    internal static class KeyValueOptionsParser
    {
        //
        // Summary:
        //     Describes a function to create an item.
        //
        // Parameters:
        //   value:
        //     The value of the item.
        //
        //   text:
        //     The display text of the item.
        internal delegate T ItemActivator<out T>(string value, string text);

        //
        // Summary:
        //     Parses given dataSource by System.Environment.NewLine and given separator.
        internal static IEnumerable<T> ParseDataSource<T>(string dataSource, string separator, ItemActivator<T> activator)
        {
            string[] array = (dataSource ?? string.Empty).Trim().Split(new string[3]
            {
            Environment.NewLine,
            "\r\n",
            "\n"
            }, StringSplitOptions.RemoveEmptyEntries);
            string[] array2 = array;
            for (int i = 0; i < array2.Length; i++)
            {
                string[] array3 = array2[i].Trim().Split([separator], StringSplitOptions.None);
                if (array3.Length != 0)
                {
                    if (array3.Length == 1)
                    {
                        yield return activator(array3[0], array3[0]);
                        continue;
                    }
                    string value = array3[0];
                    string text = array3[1];
                    yield return activator(value, text);
                }
            }
        }
    }
}
