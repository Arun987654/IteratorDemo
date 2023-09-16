/******************************************************************************
* Filename    = Cricinfo.cs
*
* Author      = Arun Sankar
*
* Product     = SoftwareDesignPatterns
* 
* Project     = IteratorDemo
*
* Description = Defines the class Cricinfo which implements the IScorecard interface
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
        /// Creates and returns an iterator for iterating through the list of players.
        /// </summary>
        /// <returns>An iterator for players in the scorecard.</returns>
        public IPlayerIterator CreateIterator()
        {
            return new PlayerIterator(_batters);
        }
    }
}
