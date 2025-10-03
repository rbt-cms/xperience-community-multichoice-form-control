namespace XperienceCommunity.MultiChoiceFormControl.Admin.Helpers.Components.MultiChoice
{
    public interface IMultiChoiceOptionsProvider
    {
        public Task<IEnumerable<MultiChoiceOptionItem>> GetOptionItems();
    }
}
