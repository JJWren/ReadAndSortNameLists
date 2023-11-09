using ReadAndSortNameLists.Classes;

// You need to set your own base directory.
string DIRECTORY = "C:\\Users\\someUser\\Sample";
string BASEFILENAME = "FirstAndLastNamesList";
string EXTENSION = ".txt";

List<Contact> contacts = FileReaderWriter.ConvertTxtFileOfNamesToContactList(
    DIRECTORY, $"{BASEFILENAME}{EXTENSION}");

Console.WriteLine("Creating file for contacts sorted by last name, ASC...");
FileReaderWriter.CreateTxtFileOfNamesFromContactList(
    Sorter.SortContactsByLastName(contacts),
    true,
    Path.Combine(DIRECTORY, $"{BASEFILENAME}_SortedByLastName_ASC{EXTENSION}"),
    $"{BASEFILENAME}_SortedByLastName_ASC");


Console.WriteLine("Creating file for contacts sorted by last name, DESC...");
FileReaderWriter.CreateTxtFileOfNamesFromContactList(
    Sorter.SortContactsByLastName(contacts, Constants.DESC),
    true,
    Path.Combine(DIRECTORY, $"{BASEFILENAME}_SortedByLastName_DESC{EXTENSION}"),
    $"{BASEFILENAME}_SortedByLastName_DESC");

Console.WriteLine("Creating file for contacts sorted by first name, ASC...");
FileReaderWriter.CreateTxtFileOfNamesFromContactList(
    Sorter.SortContactsByFirstName(contacts),
    false,
    Path.Combine(DIRECTORY, $"{BASEFILENAME}_SortedByFirstName_ASC{EXTENSION}"),
    $"{BASEFILENAME}_SortedByFirstName_ASC");


Console.WriteLine("Creating file for contacts sorted by first name, DESC...");
FileReaderWriter.CreateTxtFileOfNamesFromContactList(
    Sorter.SortContactsByLastName(contacts, Constants.DESC),
    false,
    Path.Combine(DIRECTORY, $"{BASEFILENAME}_SortedByFirstName_DESC{EXTENSION}"),
    $"{BASEFILENAME}_SortedByFirstName_DESC");
