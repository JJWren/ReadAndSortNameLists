# ReadAndSortNameLists
This program can read in text files to obtain a list of contact names, as well as write to a new file with the contact names sorted by first or last name.

## Sorter
The `Sorter` class is the primary interface for sorting the names. The names are each placed into a `Contact` class for easier identification of the parts of the names. Currently, it has two primary methods:
- Sorting by last name in ASC or DESC order (default is ASC):
    - `SortContactsByLastName(List<Contact> contacts)`
        - "Albreck, Alan Joe", "Smith, Alan Joseph", "Smith, John Wilkins", "Zimmerman, Alex Ott"
    - `SortContactsByLastName(List<Contact> contacts, Constants.DESC)`
        - "Zimmerman, Alex Ott", "Smith, John Wilkins", "Smith, Alan Joseph", "Albreck, Alan Joe"
- Sorting by first name in ASC or DESC order (default is ASC):
    - `SortContactsByFirstName(List<Contact> contacts)`
        - "Alan Joe Albreck", "Alan Joseph Smith", "Alex Ott Zimmerman", "John Wilkins Smith"

 ## FileReaderWriter
Currently, the `FileReaderWriter` class has two ways of interacting with text files:
- `ConvertTxtFileOfNamesToContactList(string directory, string fileName)`
    - Reads in a formatted text file and creates a Contact from each read line.
    - Formatted text file should follow the format of `firstName otherNames lastName` on each line:
        - Alan Joe Albreck
        - Alan Joseph Smith
        - Alex Ott Zimmerman
        - John Wilkins Smith
    - Names in the text file can be in any random order.
- `CreateTxtFileOfNamesFromContactList(List<Contact> contacts, bool listLastNameFirst, string directory, string fileName)`
    - If the directory and/or file does no exist, it will create it.
    - If the file already exists, it will append it with ` - Copy (x)` with x being an increasing value if a copy already exists.
    - The output of the names will follow the same format as a text file being read in.
    - Names in the text file will be in the order that the `List<Contact>` is given to it in.
 
## Example Input and Output Files
See the `Sample` folder for example input and output files.

## Shoutout and Thanks To
I utilized [this website](https://www.name-generator.org.uk/quick/) for creating a quick list of 100 random names for my sample file. It was extremely quick and easy to use and has great options for producing desired output -- male names, female names, both types, and an option for choosing how many you would like to generate! I highly recommend this site for it's ease of use and great options.

## Future Plans:
- Create a method that reads in a txt file, then outputs the names into the same or new file immediately without having to call the first two methods seperately in `Program.cs`.
- Create similar methods for an excel file.
- Create similar methods for a csv file.
- Create similar methods that allow a choice of file input and file output types.
- Add more error checking and validations.
