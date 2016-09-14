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
    }

    class Game
    {   
        public SoccerTeam team1;
        public SoccerTeam team2;

        public Game(string team1name, string team2name)
        {
            team1 = new SoccerTeam(team1name, 0);
            team2 = new SoccerTeam(team2name, 0);
        }

        public void GamePlay()
        {
            //uses a random number generator to determine score of the game.
            Random rnd = new Random();

            team1.points = rnd.Next(1,7);
            team1.goalsFor = team1.goalsFor + team1.points;
            team2.goalsAgainst = team1.goalsFor;
            team2.points = rnd.Next(1,7);
            team2.goalsFor = team2.goalsFor + team2.points;
            team1.goalsAgainst = team2.goalsFor;
            //calculate each teams running differential
            team1.differential = team1.goalsFor - team1.goalsAgainst;
            team2.differential = team2.goalsFor - team2.goalsAgainst;
            
            Console.WriteLine('\n' + team1.name + "\tvs. \t" + team2.name + '\n' + team1.points + "\t\t" + team2.points);

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
            //reset each teams game points to zero
            team1.points = 0;
            team2.points = 0;
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
                    isNum = true;
                }
                catch
                {
                    Console.Write("\nInvalid input. Please enter a number. \n");  //if converting to an int didn't work, then show an error and begin the loop again

                }
            }
            

            //Allow user input for each team
            for (int y = 1; y < numTeams+1; y++)
            {
            
                    Console.Write("Enter team " + y + " name: ");
                    name = Console.ReadLine();
                    //Converts user input into title format (First letter upper, rest lower)
                    name = name.Substring(0, 1).ToUpper() + name.Substring(1).ToLower();
                    Console.Write("Enter " + name + "'s points: ");
                    //converts user input to type int
                    bool isString = true;

                    while (isString)
                    {
                        isString = false;
                        try
                        {
                            points = Convert.ToInt32(Console.ReadLine());
                            Console.Write("\n");
                            SoccerTeam n = new SoccerTeam(name, points);
                            soccer_teams.Add(n);
                        }
                        catch
                        {
                            Console.Write("Enter a number not a word: ");
                            isString = true;
                        }

                    }

            }

            //Creates a sorted list of the teams in descending order based on points earned
            List<SoccerTeam> sortedTeams = soccer_teams.OrderByDescending(SoccerTeam => SoccerTeam.points).ToList();

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

            //Pause at the end

            string answer;
            string team1name;
            string team2name;
            SoccerTeam team1 = new SoccerTeam(" ", 0);
            SoccerTeam team2 = new SoccerTeam(" ", 0);

            Console.Write("Would you like to play a game? (Y or N)");
            answer = Console.ReadLine();
            answer = answer.Substring(0, 1).ToUpper();      //reduces the user's responce to one letter that is capitalized
            
            if (answer == "Y")
            {
                Console.WriteLine("Which teams would you like to have play?");
                Console.WriteLine("Team 1: ");
                team1name = Console.ReadLine();
                team1name = team1name.Substring(0, 1).ToUpper() + team1name.Substring(1).ToLower();
                Console.WriteLine("Team 2: ");
                team2name = Console.ReadLine();
                team2name = team2name.Substring(0, 1).ToUpper() + team2name.Substring(1).ToLower();
                
                foreach (SoccerTeam team in sortedTeams)
                {
                    if (team.name == team1name)
                    {
                        team1 = team;
                    }
                    else if ( team.name == team2name)
                    {
                        team2 = team;
                    }
                    
                }

                if (team1.name == " ")
                {
                    team1.name = team1name;
                }
                if (team2.name == " ")
                {
                    team2.name = team2name;
                }

            }

           /* bool response = true;
            while (response == true)
            {
            Console.WriteLine("Would you like to play a game? (Y or N)");
            answer = Console.ReadLine();
            answer = answer.Substring(0,1).ToUpper();
                if (answer.Substring(0, 1) == "Y")
                {
                    Console.WriteLine("Which two teams are going to play? \nEnter Team 1's name: ");
                    team1name = Console.ReadLine();
                    team1name = team1name.Substring(0, 1).ToUpper() + team1name.Substring(1).ToLower();
                    Console.WriteLine("Enter Team 2's name: ");
                    team2name = Console.ReadLine();
                    team2name = team2name.Substring(0, 1).ToUpper() + team2name.Substring(1).ToLower();

                    Game gameplay = new Game(team1name, team2name);

                    gameplay.GamePlay();

                    Console.WriteLine("Would you like to play again? (Y or N)");
                    answer = Console.ReadLine();
                    answer = answer.Substring(0,1).ToUpper();
                    if (answer == "Y")
                    {
                        response = true;
                    }
                    else if (answer == "N")
                    {
                        response = false;
                        Console.WriteLine('\n');
                    }
                }
                else if (answer == "N")
                {
                    Console.Write("Goodbye");
                    response = false;
                }
                else
                {
                    Console.Write("Please enter Y or N");
                }
            }
            */
        }

    }
}
