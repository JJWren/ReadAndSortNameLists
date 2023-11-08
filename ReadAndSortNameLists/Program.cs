using ReadAndSortNameLists.Classes;

string DIRECTORY = "C:\\Users\\someUser\\someFolder";
string BASEFILENAME = "FirstAndLastNamesList";
string EXTENSION = ".txt";

List<Contact> contacts = FileReaderWriter.ConvertTxtFileOfNamesToContactList(
    DIRECTORY, $"{BASEFILENAME}{EXTENSION}");

Console.WriteLine("Creating file for contacts sorted by last name, ASC...");
FileReaderWriter.CreateTxtFileOfNamesFromContactList(
    Sorter.SortContactsByLastName(contacts),
    true,
    DIRECTORY,
    $"{BASEFILENAME}_SortedByLastName_ASC{EXTENSION}");


Console.WriteLine("Creating file for contacts sorted by last name, DESC...");
FileReaderWriter.CreateTxtFileOfNamesFromContactList(
    Sorter.SortContactsByLastName(contacts, Constants.DESC),
    true,
    DIRECTORY,
    $"{BASEFILENAME}_SortedByLastName_DESC{EXTENSION}");

Console.WriteLine("Creating file for contacts sorted by first name, ASC...");
FileReaderWriter.CreateTxtFileOfNamesFromContactList(
    Sorter.SortContactsByFirstName(contacts),
    false,
    DIRECTORY,
    $"{BASEFILENAME}_SortedByFirstName_ASC{EXTENSION}");


Console.WriteLine("Creating file for contacts sorted by first name, DESC...");
FileReaderWriter.CreateTxtFileOfNamesFromContactList(
    Sorter.SortContactsByLastName(contacts, Constants.DESC),
    false,
    DIRECTORY,
    $"{BASEFILENAME}_SortedByFirstName_DESC{EXTENSION}");
