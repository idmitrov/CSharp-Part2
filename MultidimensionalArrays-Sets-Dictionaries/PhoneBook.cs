/*
    Write a program that receives some info from the console about people and their phone numbers.
    You are free to choose the manner in which the data is entered;
    each entry should have just one name and one number (both of them strings). 
    After filling this simple phonebook, upon receiving the command "search",
    your program should be able to perform a search of a contact by name
    and print her details in format "{name} -> {number}". 
    In case the contact isn't found, print "Contact {name} does not exist."
    
    Example:   INPUT                   OUTPUT
               
                Nakov-0888080808        Contact Mariika does not exist.
                search                  Nakov -> 0888080808
                Mariika
                Nakov

    Bonus:
            What happens if the user enters the same name twice in the phonebook?
            Modify your program to keep multiple phone numbers per contact.
*/

namespace Phonebook
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    class PhoneBook
    {
        //PHONEBOOK ENTRY VALIDATION
        public static string[] GetPhoneBookEntry(string input)
        {
            Match phoneBookEntryMatch = Regex.Match(input, "([a-zA-Z0-9_()]+)-([0-9]+)");

            if (phoneBookEntryMatch.Success)
            {
                return new[]
                {
                    phoneBookEntryMatch.Groups[1].Value,
                    phoneBookEntryMatch.Groups[2].Value
                };
            }

            return new string[0];
        }

        //MAIN
        static void Main()
        {
            const string phoneBookEntryExample =
                "Valid phone book entry is only (Username-phone number)"
                + "\r\nExample: Jonh-123429 or Jack-03234212 and etc...\r\n";

            string input;
            var phoneBook = new Dictionary<string, string>();

            do
            {
                Console.Write("Phone book entry: ");
                input = Console.ReadLine();
                string[] phoneBookEntry = GetPhoneBookEntry(input);

                if (phoneBookEntry.Length == 0 && input != "search")
                {
                    Console.Clear();
                    Console.WriteLine(phoneBookEntryExample);
                    Console.WriteLine("{0} is not valid phone book entry.\r\n", input);
                }
                else
                {
                    if (input != "search")
                    {
                        //FILL DICTIONARY

                        //IF NO CONTACT WITH THIS NAME (ADD ID)
                        if (!phoneBook.ContainsKey(phoneBookEntry[0]))
                        {
                            Console.Clear();
                            Console.WriteLine("Successiful added {0} to phone book\r\n", input);
                            phoneBook.Add(phoneBookEntry[0], phoneBookEntry[1]);
                        }
                        //ELSE IF CONTACT WITH THIS NAME ALREADY EXIST
                        else
                        {
                            Console.WriteLine("\r\n{0} already exist in phone book.\r\n" +
                                              "The phone will be stored to this contact as alternative.\r\n"
                                , phoneBookEntry[0]);
                            //ADD ALTERNATIVE
                            phoneBook[phoneBookEntry[0]] += "\r\nalternative: " + phoneBookEntry[1];
                        }

                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Press ANY KEY to search or ESCAPE to EXIT");
                        while (true)
                        {
                            if (Console.KeyAvailable)
                            {
                                if (Console.ReadKey(true).Key != ConsoleKey.Escape)
                                {
                                    Console.Clear();
                                    Console.Write("Searching for(name): ");

                                    //SEARCH QUERY
                                    string searchQuery = Console.ReadLine();

                                    if (!string.IsNullOrEmpty(searchQuery))
                                    {
                                        //IF PHONE BOOK CONTAIN SEARCH QUERY
                                        if (searchQuery != null)
                                        {
                                            if (phoneBook.ContainsKey(searchQuery))
                                            {
                                                Console.WriteLine("{0} -> {1}"
                                                    , searchQuery
                                                    , phoneBook[searchQuery]);
                                                Console.WriteLine("Press ANY KEY to search again or ESCAPE to EXIT");
                                            }
                                            else
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Contact {0} does not exist.\r\n", searchQuery);
                                                Console.WriteLine("Press ANY KEY to search again or Escape to EXIT");
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Phone book is closing...\r\n");
                                    break;
                                }
                            }
                        }
                    }
                }
            } while (input != "search");
        }
    }
}
