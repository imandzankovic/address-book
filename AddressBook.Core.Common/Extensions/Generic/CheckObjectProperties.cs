
namespace AddressBook.Core.Common.Extensions.Generic
{
    public static class CheckObjectProperties
    {
        public static object CheckUpdateObject(object originalObj, object updateObj)
        {
            foreach (var property in updateObj.GetType().GetProperties())
            {

                if (property.GetValue(updateObj, null) == null || property.GetValue(updateObj, null).Equals(0))
                {
                    property.SetValue(updateObj, originalObj.GetType().GetProperty(property.Name)
                    .GetValue(originalObj, null));
                }

            }

            return updateObj;
        }
    }
}
