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

        internal static void CreateTxtFileOfNamesFromContactList(
            List<Contact> contacts,
            bool listLastNameFirst,
            string filePath,
            string desiredFileName)
        {
            filePath = CreateValidPathIfDoesNotExist(filePath, desiredFileName, ".txt");

            List<string> names = new();
            foreach (Contact contact in contacts)
            {
                if (listLastNameFirst)
                    names.Add(contact.GetFullNameLastNameFirst());
                else
                    names.Add(contact.GetFullName());
            }

            File.WriteAllLines(filePath, names);
        }

        private static string CreateValidPathIfDoesNotExist(string filePath, string desiredFileName, string desiredExtension)
        {
            string directory;
            if (Path.GetDirectoryName(filePath) == string.Empty)
            {
                directory = Directory.CreateDirectory(filePath).FullName;
            }
            else
            {
                directory = Path.GetDirectoryName(filePath)!;
            }

            string fileName = (Path.GetFileNameWithoutExtension(filePath) == string.Empty)
                ? desiredFileName
                : Path.GetFileNameWithoutExtension(filePath);
            string extension = (Path.GetExtension(filePath) == string.Empty)
                ? desiredExtension
                : Path.GetExtension(filePath);
            string fullPath = Path.Combine(directory, $"{fileName}{extension}");

            return AppendFileNumberIfFileExists(fullPath);
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
                filePath = Path.Combine(
                    directory,
                    $"{fileName}{addSpace}({fileNumber}){extension}");
            }
            while (File.Exists(filePath));

            return filePath;
        }
    }
}
