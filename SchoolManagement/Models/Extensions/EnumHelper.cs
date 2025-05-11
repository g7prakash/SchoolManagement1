using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace SchoolManagement.Models.Extensions
{
    public static class EnumHelper
    {
        public static List<SelectListItem> GetSelectListFromEnum<T>() where T : Enum
        {
            return Enum.GetValues(typeof(T)).Cast<T>().Select(e => new SelectListItem
            {
                Value = e.ToString(), // This will be "InProgress", etc.
                Text = e.ToString()//GetDisplayName() // "In Progress" using Display attribute
            }).ToList();
        }

        public static string GetDisplayName(this Enum enumValue)
        {
            return enumValue.GetType()
                .GetMember(enumValue.ToString())
                .First()
                .GetCustomAttribute<DisplayAttribute>()?.Name
                ?? enumValue.ToString();
        }
    }
}
