using CMS.DataEngine;
using Kentico.Xperience.Admin.Base.Filters;

namespace XperienceCommunity.MultiChoiceFormControl.Admin
{
    public class ContainsTextConditionBuilder : IWhereConditionBuilder
    {
        public Task<IWhereCondition> Build(string columnName, object value)
        {
            if (string.IsNullOrEmpty(columnName))
            {
                throw new ArgumentException($"{nameof(columnName)} cannot be a null or an empty string.");
            }

            // Creates a new where condition
            var whereCondition = new WhereCondition();

            if (value is null || value is not string)
            {
                // Returns an empty condition if a valid value is not specified
                return Task.FromResult<IWhereCondition>(whereCondition);
            }

            // Adds a where condition returning only items that contain the value in the specified column
            whereCondition.WhereContains(columnName, (string)value);

            return Task.FromResult<IWhereCondition>(whereCondition);
        }
    }
}
