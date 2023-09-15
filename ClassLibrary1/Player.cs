/******************************************************************************
 * Filename    = Player.cs
 *
 * Author      = Arun Sankar
 *
 * Product     = SoftwareDesignPatterns
 * 
 * Project     = IteratorDemo
 *
 * Description = Declares the class Player which holds the score of a batter
 *****************************************************************************/

namespace ClassLibrary
{
    /// <summary>
    /// The Player class represents a cricket player and holds information about their performance.
    /// </summary>
    public class Player
    {
        /// <summary>
        /// Gets the name of the player.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the runs scored by the player.
        /// </summary>
        public int RunsScored { get; }

        /// <summary>
        /// Gets the number of balls faced by the player.
        /// </summary>
        public int BallsFaced { get; }

        /// <summary>
        /// Gets the strike rate of the player.
        /// </summary>
        public float StrikeRate { get; }

        /// <summary>
        /// Gets a value indicating whether the player is not out (has not been dismissed).
        /// </summary>
        public bool NotOut { get; }

        /// <summary>
        /// Initializes a new instance of the Player class with the parameters as explained below.
        /// </summary>
        /// <param name="batterName">The name of the batter.</param>
        /// <param name="runs">The runs scored by him/her.</param>
        /// <param name="balls">The number of deliveries faced by the batter.</param>
        /// <param name="flag">A flag indicating whether the player is NOT OUT (optional, by default player is OUT).</param>
        public Player( string batterName , int runs , int balls , bool flag = false )
        {
            Name = batterName;
            RunsScored = runs;
            BallsFaced = balls;

            // Calculate the strike rate
            if (balls != 0)
            {
                StrikeRate = (float)RunsScored * 100 / balls;
            }
            else
            {
                StrikeRate = 0;
            }

            NotOut = flag;
        }
    }
}
