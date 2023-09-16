/******************************************************************************
* Filename    = IPlayerIterator.cs
*
* Author      = Arun Sankar
*
* Product     = SoftwareDesignPatterns
* 
* Project     = IteratorDemo
*
* Description = Defines an interface for accessing and traversing elements
*****************************************************************************/

namespace ClassLibrary
{
    /// <summary>
    /// The IPlayerIterator interface defines methods for accessing and traversing batters.
    /// </summary>
    public interface IPlayerIterator
    {
        /// <summary>
        /// Checks if there are more live elements to iterate through.
        /// </summary>
        /// <returns>True if there are more live elements, false otherwise.</returns>
        bool IsLive();

        /// <summary>
        /// Retrieves the next element in the traversal.
        /// </summary>
        /// <returns>The next element in the traversal.</returns>
        Player Next();
    }
}
