using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Assignment
{
    /*The team class creates different teams with a record of their past performance in games*/
    class Team
    {
        public string name;
    }

    class SoccerTeam : Team
    {
        
        public int draw;
        public int goalsFor;
        public int goalsAgainst;
        public int differential;
        public int points;

        public SoccerTeam(string team_name, int team_points)
        {
            this.name = team_name;
            this.points = team_points;
        }


        //Additional function that displays running statistics for a given team
        public void showTeamStats()
        {
            Console.WriteLine('\n' + name + " Season Statistics");
            Console.WriteLine("Goals For: " + goalsFor);
            Console.WriteLine("Goals Against: " + goalsAgainst);
            Console.WriteLine("Differential: " + differential);
            Console.WriteLine("Draws: " + draw);
        }

    }

    class Game
    {   
        public SoccerTeam team1;
        public SoccerTeam team2;

        //Initializes a game or match between two teams
        public Game(SoccerTeam team1, SoccerTeam team2)
        {
            this.team1 = team1;
            this.team2 = team2;
        }


        //Plays out the game between the two teams and displays the results 
        //(points are randomly generated with a max of 10 in a single game)

        public void GamePlay()
        {
            //uses a random number generator to determine score of the game.
            Random rnd = new Random();

            team1.points = rnd.Next(1,7);
            team1.goalsFor = team1.goalsFor + team1.points;
            team2.goalsAgainst = team2.goalsAgainst + team1.points;

            team2.points = rnd.Next(1,7);
            team2.goalsFor = team2.goalsFor + team2.points;
            team1.goalsAgainst = team1.goalsAgainst + team2.points;

            //calculate each teams running differential
            team1.differential = team1.goalsFor - team1.goalsAgainst;
            team2.differential = team2.goalsFor - team2.goalsAgainst;

            Console.WriteLine("_____________________________");
            Console.WriteLine('\n' + team1.name + "\tvs. \t" + team2.name);
            Console.WriteLine("_____________________________");
            Console.WriteLine(team1.points + "\t\t" + team2.points + '\n');

            //determine the winner based on the points, if it's a tie add a draw to each team's record
            if (team1.points > team2.points)
            {
                Console.WriteLine(team1.name + " WINS!");
            }
            else if (team2.points > team1.points)
            {
                Console.WriteLine(team2.name + " WINS!");
            }
            else
            {
                Console.WriteLine("It's a Tie!");
                team1.draw = team1.draw + 1;
                team2.draw = team2.draw + 2;
            }

            Console.WriteLine("_______________");
            //reset each teams game points to zero
            team1.points = 0;
            team2.points = 0;

            team1.showTeamStats();
            Console.WriteLine("_______________");
            team2.showTeamStats();
            
        }

    }



    class Project
    {
        static void Main(string[] args)
        {
            
            string name;
            int points;
            int numTeams = 0;
            List<SoccerTeam> soccer_teams = new List<SoccerTeam>();


      //create variable list object, fill with the teams in no particular order
            
            
            bool isNum = false;     
            while (isNum == false)  //do the following until the user gives the correct input
            {
                try
                {
                    Console.Write("How many teams? ");
                    numTeams = Convert.ToInt32(Console.ReadLine());  //convert the user input into a int, if it throws an error jump down to catch statement
                    Console.Write("\n");
                    if (numTeams > 0)
                    {
                        isNum = true;
                    }
                    else
                    {
                        Console.WriteLine("Numbers must be positive.");
                    }
                }
                catch(Exception ex)
                {
                    Console.Write("\nInvalid input. Please enter a number. \n");  //if converting to an int didn't work, then show an error and begin the loop again

                }
            }
            

            //Allow user input for each team
            for (int y = 1; y < numTeams+1; y++)
            {
            
                    Console.Write("\nEnter team " + y + " name: ");
                    name = Console.ReadLine();
                    //Converts user input into title format (First letter upper, rest lower)
                    name = name.Substring(0, 1).ToUpper() + name.Substring(1).ToLower();
                   
                    //converts user input to type int
                    isNum = false;

                    while (isNum == false)
                    {
                        Console.Write("\nEnter " + name + "'s points: ");
                        try                                                             //checks that the input is a number if it isn't an error is thrown
                        {
                            points = Convert.ToInt32(Console.ReadLine());
                            if (points > 0)                                             //checks that the number is greater than zero and throws an error if it isn't
                            {
                                Console.Write("\n");
                                SoccerTeam n = new SoccerTeam(name, points);
                                soccer_teams.Add(n);
                                isNum = true;
                            }
                            else
                            {
                                Console.WriteLine("Points must be positive.\n");
                            }
                        }

                        catch(Exception ex)
                        {
                            Console.WriteLine("Enter a number not a word.\n");
                            
                        }

                    }

            }

            //Creates a sorted list of the teams in descending order based on points earned
            List<SoccerTeam> sortedTeams = soccer_teams.OrderByDescending(SoccerTeam => SoccerTeam.points).ToList();
            Console.WriteLine("\nHere is the sorted list:\n");

            //Create title bar
            Console.Write("Position \t Name \t\t Points \n");
            Console.Write("________\t ____\t\t ______\n");
            //For each team in the sorted list display the order number, the name and the points they have
            int i = 1;
            foreach (SoccerTeam team in sortedTeams)
            {
                Console.Write(i.ToString().PadRight(17,' '));
                Console.Write(team.name.PadRight(16,' '));
                Console.WriteLine(team.points);
                i++;
            }

            //End of Assignment Requirements

            //Beginning of "Above and Beyond"
            //   ______     ______     ______     ______     ______     ______        ______     ______     __    __     ______    
            //  /\  ___\   /\  __ \   /\  ___\   /\  ___\   /\  ___\   /\  == \      /\  ___\   /\  __ \   /\ "-./  \   /\  ___\   
            //  \ \___  \  \ \ \/\ \  \ \ \____  \ \ \____  \ \  __\   \ \  __<      \ \ \__ \  \ \  __ \  \ \ \-./\ \  \ \  __\   
            //   \/\_____\  \ \_____\  \ \_____\  \ \_____\  \ \_____\  \ \_\ \_\     \ \_____\  \ \_\ \_\  \ \_\ \ \_\  \ \_____\ 
            //    \/_____/   \/_____/   \/_____/   \/_____/   \/_____/   \/_/ /_/      \/_____/   \/_/\/_/   \/_/  \/_/   \/_____/ 
            //                                                                                                                     

            string answer = " ";
            string team1name;
            string team2name;
            bool invalidInput = true ;

            while (invalidInput)
            {
                Console.WriteLine("\nWould you like to play a game? (Y or N)");
                answer = Console.ReadLine();
                answer = answer.Substring(0, 1).ToUpper();      //reduces the user's responce to one letter that is capitalized


                if (answer != "Y" && answer != "N")
                {
                    Console.WriteLine("Invalid input, please try again.");
                }
                else
                {
                    invalidInput = false;
                }
            }
            //As long as the user wants to continue playing the game go through gameplay and add each team played into the sorted list
            //to keep a record.

            string response = " ";
            while (answer == "Y")
            {

                SoccerTeam team1 = new SoccerTeam(" ", 0);
                SoccerTeam team2 = new SoccerTeam(" ", 0);

                Console.WriteLine("\nWhich teams would you like to have play?");
                Console.Write("Team 1: ");
                team1name = Console.ReadLine();
                team1name = team1name.Substring(0, 1).ToUpper() + team1name.Substring(1).ToLower();     //formats team name into title format
                Console.Write("Team 2: ");
                team2name = Console.ReadLine();
                team2name = team2name.Substring(0, 1).ToUpper() + team2name.Substring(1).ToLower();


                //Finds the team in the list if it's already played
                foreach (SoccerTeam team in sortedTeams)
                {
                    if (team.name == team1name)
                    {
                        team1 = team;
                    }
                    else if (team.name == team2name)
                    {
                        team2 = team;
                    }
                }

                //if either team hasn't played before (i.e. wasn't in the list) they are created and added to the list
                //the list is then re-sorted
                if (team1.name == " ")
                {
                    team1.name = team1name;
                    sortedTeams.Add(team1);
                    sortedTeams = sortedTeams.OrderByDescending(SoccerTeam => SoccerTeam.points).ToList();
                }
                if (team2.name == " ")
                {
                    team2.name = team2name;
                    sortedTeams.Add(team2);
                    sortedTeams = sortedTeams.OrderByDescending(SoccerTeam => SoccerTeam.points).ToList();
                }

                Game game = new Game(team1, team2);                             //A match is made now that the teams have been found or created
                game.GamePlay();                                                //Gameplay begins once a match is made

                
                //As long as invalid input is given keep asking the question
                invalidInput = true;
                while (invalidInput)
                {
                    Console.WriteLine("\nWould you like to play again? (Y or N)");
                    response = Console.ReadLine().Substring(0, 1).ToUpper();      //reduces the user's responce to one letter that is capitalized


                    if (response != "Y" && response != "N")
                    {
                        Console.WriteLine("Invalid input, please try again.");
                    }
                    else
                    {
                        answer = response;
                        invalidInput = false;                        
                    }
                }
            }
            Console.WriteLine("\nGoodbye!");
            Console.ReadLine();                                                //pause at the end for user input to exit console
        }
    }
}
