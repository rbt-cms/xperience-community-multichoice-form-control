using Kentico.Xperience.Admin.Base.Forms;

namespace XperienceCommunity.MultiChoiceFormControl.Admin
{
    public class FieldEditorFormContext : IFormContext
    {
        public IList<FormFieldDescriptor> FormFields { get; init; }

        public string CurrentFieldName { get; init; }

        public string CurrentFieldTypeFullName { get; init; }
    }

    public record FormFieldDescriptor
    {
        public string FieldName { get; init; }

        public Type FieldType { get; init; }

        public string FieldDataType { get; init; }

        public bool IsVisible { get; set; }

        public FormFieldDescriptor(string fieldName, Type fieldType, string fieldDataType, bool isVisible)
        {
            FieldName = fieldName;
            FieldType = Nullable.GetUnderlyingType(fieldType) ?? fieldType;
            FieldDataType = fieldDataType;
            IsVisible = isVisible;
        }
    }
}
