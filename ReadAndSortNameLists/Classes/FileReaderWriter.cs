using RandomChallenges.Classes.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

            if (File.Exists(path))
            {
                fileName = AppendFileNumberIfFileExists(path);
                path = Path.Combine(directory, fileName);
            }

            return path;
        }

        private static string AppendFileNumberIfFileExists(string filePath, string extension = "")
        {
            string directory = Path.GetDirectoryName(filePath)!;
            string fileName = Path.GetFileNameWithoutExtension(filePath);
            extension = (extension == string.Empty)
                ? Path.GetExtension(filePath)
                : extension;
            int fileNumber = 0;
            Regex r = new (@"\(([0-9]+)\)$");
            Match match = r.Match(fileName);
            string addSpace = " ";

            if (match.Success)
            {
                addSpace = string.Empty;
                string numStr = match.Groups[1].Captures[0].Value;
                fileNumber = int.Parse(numStr);
                fileName = fileName.Replace($"({numStr})", "");
            }

            do
            {
                fileNumber++;
                fileName = Path.Combine(
                    directory,
                    $"{fileName}{addSpace}({fileNumber}){extension}");
            }
            while (match.Success);

            return fileName;
        }
    }
}
