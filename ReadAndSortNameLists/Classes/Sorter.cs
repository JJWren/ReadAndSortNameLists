using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadAndSortNameLists.Classes
{
    internal static class Sorter
    {
        public static List<Contact> SortContactsByLastName(List<Contact> contacts, string sortBy = "ASC")
        {
            if (contacts == null)
            {
                return new List<Contact>();
            }

            return (sortBy.ToUpper() == "ASC")
                ? contacts.OrderBy(c => c.LastName)
                    .ThenBy(c => c.FirstName)
                    .ThenBy(c => c.OtherNames).ToList()
                : contacts.OrderByDescending(c => c.LastName)
                    .ThenByDescending(c => c.FirstName)
                    .ThenByDescending(c => c.OtherNames).ToList();
        }

        public static List<Contact> SortContactsByFirstName(List<Contact> contacts, string sortBy = "ASC")
        {
            if (contacts == null)
            {
                return new List<Contact>();
            }

            return (sortBy.ToUpper() == "ASC")
                ? contacts.OrderBy(c => c.GetFullName()).ToList()
                : contacts.OrderByDescending(c => c.GetFullName()).ToList();
        }
    }
}
