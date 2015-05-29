/*
    Being a nerd means writing programs about night clubs instead of actually going to ones. 
    Spiro is a nerd and he decided to summarize some info about the most popular night clubs around the world. 
    He's come up with the following structure
    – he'll summarize the data by city,
    where each city will have a list of venues and each venue will have a list of performers.
    Help him finish the program, so he can stop staring at the computer screen and go get himself a cold beer.
    
    You'll receive the input from the console. 
    There will be an arbitrary number of lines until you receive the string "END".
    Each line will contain data in format: "city;venue;performer". 
    If either city, venue or performer don't exist yet in the database, add them.
    If either the city and/or venue already exist, update their info.
    Cities should remain in the order in which they were added, 
    venues should be sorted alphabetically and performers should be unique (per venue) and also sorted alphabetically.
    Print the data by listing the cities and for each city its venues
    (on a new line starting with "->") and performers (separated by comma and space). Check the examples to get the idea.
    And grab a beer when you're done, you deserve it. Spiro is buying.

    Example: 
                INPUT                                       OUTPUT
                
                Sofia;Biad;Preslava                         Sofia
                Pernik;Stadion na mira;Vinkel               ->Biad: Preslava
                New York;Statue of Liberty;Krisko           Pernik
                Oslo;everywhere;Behemoth                    ->Letishteto: RoYaL
                Pernik;Letishteto;RoYaL                     ->Stadion na mira: Bankin, Vinkel
                Pernik;Stadion na mira;Bankin               NewYork
                Pernik;Stadion na mira;Vinkel               ->Statue of Liberty: Krisko
                END                                         Oslo
                                                            ->everywhere: Behemoth
*/

namespace NightLife
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class NightLife
    {
        static void Main()
        {
            var mostPopularClubs = new Dictionary<string, Dictionary<string, List<string>>>();
            string inputLine;
            //ENTRIES UNTIL "END"
            do
            {
                inputLine = Console.ReadLine();
                //IF INPUT IS NOT EMPTY OR NULL
                if (inputLine != null)
                {
                    //IF DATA IS VALID
                    if (inputLine.Contains(";")
                        && inputLine.Split(new[] {';'}, StringSplitOptions.RemoveEmptyEntries)
                            .Length == 3)
                    {
                        //GET VALID DATA
                        string[] data = inputLine.Split(new[] {';'}, StringSplitOptions.RemoveEmptyEntries);

                        //GET CITY;VENUE;PERFORMER FROM DATA
                        string city = data[0],
                            venue = data[1],
                            performers = data[2];

                        //IF ANY (CITY/VENUE/PERFORMER(S)) is EMPTY PRINT ERROR
                        if (city.Trim() == "" || venue.Trim() == "" || performers.Trim() == "")
                        {
                            Console.WriteLine("Fields can not be empty");
                        }
                        else
                        {
                            //INIT LIST
                            var performersList = performers.Split(' ').ToList();

                            //IF MOST POPULAR CLUBS DOESNT CONTAIN THE CITY
                            if (!mostPopularClubs.ContainsKey(city))
                            {
                                //GROUP VENU DETAILS AND PERFORMERS LIST INTO DICTIONARY
                                var venueDetails = new Dictionary<string, List<string>> {{venue, performersList}};
                              
                                //ADD CITY AND VENU DETAILS(VENU/LIST OF PERFORMERS)
                                mostPopularClubs.Add(city, venueDetails);
                            }
                            else
                            {
                                //IF CITY EXIST, BUT THE VENUE NOT
                                if (!mostPopularClubs[city].ContainsKey(venue))
                                {
                                    //ADD VENUE AND LIST OF PERFORMERS
                                    mostPopularClubs[city].Add(venue, performersList);
                                }
                                //CITY EXIST, VENU EXIST, AND LIST EXIST BUT IS NOT ACTUAL
                                else
                                {
                                    //ADD THE PERFORMERS WHICH ARE NOT EXIST INTO THE LIST
                                    foreach (var performer in performersList)
                                    {
                                        Console.Clear();
                                        if (!mostPopularClubs[city][venue].Contains(performer))
                                        {
                                            //ADD PERFORMER
                                            mostPopularClubs[city][venue].Add(performer);
                                        }
                                        //ELSE LIST IS ACTUAL, PERFORMER CAN NOT BE ADDED
                                        else
                                        {
                                            //PRIN MESSAGE
                                            Console.WriteLine("{0} is already listed into performers", performer);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        //AFTER "END" PRINT OUTPUT IF EXIST ELSE PRINT COSING MESSAGE
                        Console.Clear();
                        Console.WriteLine(inputLine != "END"
                            ? "Invalid entry"
                            : mostPopularClubs.Count == 0 
                            ? "The program is closing...\r\n" 
                            : "ALL ENTRIES:\r\n");
                    }
                }
            } while (inputLine != "END");

            //FOREACH CITY
            foreach (var city in mostPopularClubs.Keys)
            {
                //PRINT CITY
                Console.WriteLine(city);
                //SORT VENUES ALPHABETICALLY
                foreach (var venue in mostPopularClubs[city].Keys.OrderBy(x => x, StringComparer.Ordinal))
                {
                    //PRINT VENUE
                    Console.Write("->{0}: ", venue);
                    
                    //SORT PERFORMERS LIST ALPHABETICALLY
                    mostPopularClubs[city][venue].Sort();
                    
                    //FOR EACH PERFORMER IN PERFORMERS LIST
                    foreach (var performer in mostPopularClubs[city][venue])
                    {
                        //PRINT PERFORMER
                        Console.Write(performer + " ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }
    }
}
