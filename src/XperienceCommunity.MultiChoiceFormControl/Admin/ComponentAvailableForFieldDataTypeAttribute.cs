namespace XperienceCommunity.MultiChoiceFormControl.Admin
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    internal class ComponentAvailableForFieldDataTypeAttribute(params string[] fieldDataTypes) : Attribute
    {
        public string[] FieldDataTypes { get; } = fieldDataTypes;
    }
}
