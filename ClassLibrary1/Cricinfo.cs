/******************************************************************************
* Filename    = Cricinfo.cs
*
* Author      = Arun Sankar
*
* Product     = SoftwareDesignPatterns
* 
* Project     = IteratorDemo
*
* Description = Declares the class Cricinfo which implements the IScorecard interface
*****************************************************************************/

namespace ClassLibrary
{
    /// <summary>
    /// Helps add objects to the aggregate
    /// </summary>
    public class Cricinfo : IScorecard
    {
        private readonly List<Player> _batters = new();  // Initialize a list to store players.

        /// <summary>
        /// Adds a player to the cricket scorecard.
        /// </summary>
        /// <param name="player">The player to be added.</param>
        public void AddPlayer(Player player)
        {
            _batters.Add(player);
        }

        /// <summary>
        /// Calculates and returns the number of wickets taken in the team.
        /// </summary>
        /// <returns>The number of wickets taken.</returns>
        public int GetNumWickets()
        {
            int wicket = 0;
            foreach (Player batsman in _batters)
            {
                if (!batsman.NotOut)
                {
                    wicket++;
                }
            }
            return wicket;
        }

        /// <summary>
        /// Calculates and returns the total runs scored by the team.
        /// </summary>
        /// <returns>The total runs scored by the team.</returns>
        public int TeamTotal()
        {
            int total = 0;
            foreach (Player batsman in _batters)
            {
                total += batsman.RunsScored;
            }
            return total;
        }

        /// <summary>
        /// Calculates and returns the total balls bowled by the team.
        /// </summary>
        /// <returns>The total balls bowled by the team.</returns>
        public int BallsBowled()
        {
            int balls = 0;
            foreach (Player batsman in _batters)
            {
                balls += batsman.BallsFaced;
            }
            return balls;
        }

        /// <summary>
        /// Calculates and returns the current run rate of the team.
        /// </summary>
        /// <returns>The current run rate of the team.</returns>
        public float CurrentRunRate()
        {
            return (float)TeamTotal()*6/BallsBowled();
        }

        /// <summary>
        /// Creates and returns an iterator for iterating through the list of players.
        /// </summary>
        /// <returns>An iterator for players in the scorecard.</returns>
        public IPlayerIterator CreateIterator()
        {
            return new PlayerIterator(_batters);
        }
    }
}
