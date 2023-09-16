/******************************************************************************
* Filename    = PlayerIterator.cs
*
* Author      = Arun Sankar
*
* Product     = SoftwareDesignPatterns
* 
* Project     = IteratorDemo
*
* Description = Defines the class PlayerIterator which keeps track of the current position in the traversal of the aggregate object and implements the interface IPlayerIterator
*****************************************************************************/

namespace ClassLibrary
{
    /// <summary>
    /// Define methods to traverse the aggregate object and checks if it has ended or not
    /// </summary>
    public class PlayerIterator : IPlayerIterator
    {
        private readonly List<Player> _batters; // The list that holds the players
        private int _index = 0; // Current index while iterating

        /// <summary>
        /// Creates an instance of the PlayerIterator
        /// </summary>
        public PlayerIterator( List<Player> players )
        {
            _batters = players;
        }

        /// <summary>
        /// Checks if there are more players to iterate through.
        /// </summary>
        /// <returns>True if there are more players, false otherwise.</returns>
        public bool IsLive()
        {
            return _index < _batters.Count;
        }

        /// <summary>
        /// Retrieves the next element in the traversal.
        /// </summary>
        /// <returns>The next element in the traversal.</returns>
        public Player Next()
        {
            if (IsLive())
            {
                Player currentPlayer = _batters[_index++];
                return currentPlayer;
            }
            throw new InvalidOperationException( "End of innings!." );
        }
    }
}
