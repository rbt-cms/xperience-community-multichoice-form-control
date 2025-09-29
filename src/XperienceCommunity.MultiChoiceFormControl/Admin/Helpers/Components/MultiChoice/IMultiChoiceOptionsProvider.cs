namespace XperienceCommunity.MultiChoiceFormControl.Admin.Helpers.Components.MultiChoice
{
    public interface IMultiChoiceOptionsProvider
    {
        Task<IEnumerable<MultiChoiceOptionItem>> GetOptionItems();
    }
}
