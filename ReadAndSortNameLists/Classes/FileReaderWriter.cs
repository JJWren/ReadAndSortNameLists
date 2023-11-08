using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadAndSortNameLists.Classes
{
    internal class FileReaderWriter
    {
        internal static List<Contact> ConvertTxtFileOfNamesToContactList(string directory, string fileName)
        {
            string fullPath = Path.Combine(directory, fileName);
            List<Contact> contacts = new ();

            if (!File.Exists(fullPath))
            {
                return contacts;
            }

            string[] file = File.ReadAllLines(fullPath);
            foreach (string line in file)
            {
                string[] nameSplit = line.Split(" ");

                Contact contact = new()
                {
                    FirstName = nameSplit.First(),
                    LastName = nameSplit.Last(),
                    OtherNames = string.Join(" ", nameSplit.Skip(1).SkipLast(1).ToArray())
                };

                contacts.Add(contact);
            }

            return contacts;
        }

        internal static void CreateTxtFileOfNamesFromContactList(List<Contact> contacts, bool listLastNameFirst, string directory, string fileName)
        {
            string fullPath = CheckIfDirectoryAndFileExistAndCombinePath(directory, fileName);

            List<string> names = new();
            foreach (Contact contact in contacts)
            {
                if (listLastNameFirst)
                    names.Add(contact.GetFullNameLastNameFirst());
                else
                    names.Add(contact.GetFullName());
            }

            File.WriteAllLines(fullPath, names);
        }

        private static string CheckIfDirectoryAndFileExistAndCombinePath(string directory, string fileName)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            string path = Path.Combine(directory, fileName);

            if (File.Exists($"{directory}\\{fileName}"))
            {
                fileName = GenerateNewFileName(directory, fileName);
                path = Path.Combine(directory, fileName);
            }

            return path;
        }

        private static string GenerateNewFileName(string directory, string fileName)
        {
            int i = 1;
            while (File.Exists($"{directory}\\{fileName}"))
            {
                fileName += $" - Copy({i})";
                i++;
            }

            return fileName;
        }
    }
}
