/******************************************************************************
* Filename    = IScorecard.cs
*
* Author      = Arun Sankar
*
* Product     = SoftwareDesignPatterns
* 
* Project     = IteratorDemo
*
* Description = Defines an interface for creating an IPlayerIterator object
*****************************************************************************/

namespace ClassLibrary
{
    /// <summary>
    /// The interface that facilitates creation of an IPlayerIterator object
    /// </summary>
    public interface IScorecard
    {
        /// <summary>
        /// Called to get the iterator for traversal
        /// </summary>
        IPlayerIterator CreateIterator();
    }
}
