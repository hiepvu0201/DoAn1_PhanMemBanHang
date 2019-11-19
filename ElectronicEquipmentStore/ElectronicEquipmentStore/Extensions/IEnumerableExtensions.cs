using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicEquipmentStore.Extensions
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<SelectListItem> ToSelectListItemProductGroup<T>(this IEnumerable<T> items, string selectdValue)
        {
            return from item in items
                   select new SelectListItem
                   {
                       Text = item.GetPropertyValue("tenNSP"),
                       Value = item.GetPropertyValue("maNSP"),
                       Selected = item.GetPropertyValue("maNSP").Equals(selectdValue)
                   };
        }
        public static IEnumerable<SelectListItem> ToSelectListItemCategory<T>(this IEnumerable<T> items, string selectdValue)
        {
            return from item in items
                   select new SelectListItem
                   {
                       Text = item.GetPropertyValue("tenDM"),
                       Value = item.GetPropertyValue("maDM"),
                       Selected = item.GetPropertyValue("maDM").Equals(selectdValue)
                   };
        }
    }
}
