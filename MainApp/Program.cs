/******************************************************************************
* Filename    = Program.cs
*
* Author      = Arun Sankar
*
* Product     = SoftwareDesignPatterns
* 
* Project     = IteratorDemo
*
* Description = Provides a command line interface for the user
*****************************************************************************/
using ClassLibrary;

namespace MainApp
{
    internal class Program
    {
        static void Main()
        {
            Cricinfo scorecard = new();

            // Add players and their statistics to the scorecard
            scorecard.AddPlayer(new Player("Rohit Sharma", 56, 49));
            scorecard.AddPlayer(new Player("Shubman Gill", 58, 52));
            scorecard.AddPlayer(new Player("Virat Kohli", 122, 94, true));
            scorecard.AddPlayer(new Player("KL Rahul", 111, 106, true));

            IPlayerIterator iterator = scorecard.CreateIterator();

            Console.WriteLine("IND vs PAK Scorecard\n");
            Console.WriteLine("Batter\t\tR\tB\tSR\n");

            // Iterate through the players and display their information
            while (iterator.IsLive())
            {
                Player player = iterator.Next();
                Console.Write(string.Format("{0}", player.Name));

                // Mark players as not out with an asterisk
                if (player.NotOut)
                {
                    Console.Write("*");
                }
                Console.WriteLine(string.Format("\t{0}\t{1}\t{2}", player.RunsScored, player.BallsFaced, player.StrikeRate));
            }
        }
    }
}
