using RandomChallenges.Classes.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadAndSortNameLists.Classes
{
    internal class Contact
    {
        internal string? FirstName { get; set; } = string.Empty;
        internal string? LastName { get; set; } = string.Empty;
        internal string? OtherNames { get; set; } = string.Empty;

        internal string GetFullName()
        {
            return (OtherNames != null)
                ? $"{FirstName} {OtherNames} {LastName}"
                : $"{FirstName} {LastName}";
        }

        internal string GetFullNameLastNameFirst()
        {
            return (OtherNames != null)
                ? $"{LastName}, {FirstName} {OtherNames}"
                : $"{LastName}, {FirstName}";
        }
    }
}
