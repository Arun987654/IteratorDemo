/******************************************************************************
* Filename    = UnitTest1.cs
*
* Author      = Arun Sankar
*
* Product     = SoftwareDesignPatterns
* 
* Project     = UnitTests
*
* Description = Unit tests for the iterator pattern demo.
*****************************************************************************/

using ClassLibrary;

namespace StringLibraryTest
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Initializes a Cricinfo scorecard with sample data.
        /// </summary>
        /// <returns>Initialized Cricinfo scorecard.</returns>
        public static Cricinfo Initialise()
        {
            Cricinfo scorecard = new();
            for (int i = 0; i < 3; i++)
            {
                string name = "Player" + i;
                scorecard.AddPlayer( new Player( name , i + 1 , i + 1 ) );
            }
            scorecard.AddPlayer( new Player( "Test" , 0 , 0 , true ) );
            scorecard.AddPlayer( new Player( "Test2" , 0 , 0 , true ) );
            return scorecard;
        }

        /// <summary>
        /// Tests if the iterator is not null.
        /// </summary>
        [TestMethod]
        public void CheckNotNull()
        {
            Cricinfo scorecard = new();
            IPlayerIterator iterator = scorecard.CreateIterator();
            Assert.IsNotNull( iterator , "{0}" , iterator );
        }

        /// <summary>
        /// Tests if the iterator is live (has elements).
        /// </summary>
        [TestMethod]
        public void CheckIsLive()
        {
            Cricinfo scorecard = new();
            scorecard.AddPlayer( new Player( "Test" , 0 , 1 ) );
            IPlayerIterator iterator = scorecard.CreateIterator();
            Assert.IsTrue( iterator.IsLive() , "Expected : true; Actual : {0}" , iterator.IsLive() );
        }

        /// <summary>
        /// Tests if the iterator is not live (no elements to iterate).
        /// </summary>
        [TestMethod]
        public void CheckIsLiveAgain()
        {
            Cricinfo scorecard = new();
            IPlayerIterator iterator = scorecard.CreateIterator();
            Assert.IsFalse( iterator.IsLive() , "Expected : false; Actual : {0}" , iterator.IsLive() );
        }

        /// <summary>
        /// Tests the number of wickets taken.
        /// </summary>
        [TestMethod]
        public void TestWickets()
        {
            Cricinfo scorecard = Initialise();
            int wickets = scorecard.GetNumWickets();
            IPlayerIterator iterator = scorecard.CreateIterator();
            int wkts = 0;
            while (iterator.IsLive())
            {
                Player player = iterator.Next();
                if (!player.NotOut)
                {
                    wkts++;
                }
            }
            Assert.AreEqual( wkts , wickets , "Expected : {0}; Actual : {1}" , wickets , wkts );
        }

        /// <summary>
        /// Tests the number of balls bowled.
        /// </summary>
        [TestMethod]
        public void TestBalls()
        {
            Cricinfo scorecard = Initialise();
            Assert.AreEqual( scorecard.BallsBowled() , 6 );
        }

        /// <summary>
        /// Tests the team's total runs scored.
        /// </summary>
        [TestMethod]
        public void TestTotal()
        {
            Cricinfo scorecard = Initialise();
            IPlayerIterator iterator = scorecard.CreateIterator();
            int total = 0;
            while (iterator.IsLive())
            {
                Player player = iterator.Next();
                total += player.RunsScored;
            }
            Assert.AreEqual( scorecard.TeamTotal() , total );
        }

        /// <summary>
        /// Tests the number of overs bowled.
        /// </summary>
        [TestMethod]
        public void TestOvers()
        {
            Cricinfo scorecard = Initialise();
            int overs = scorecard.BallsBowled() / 6;
            int additional = scorecard.BallsBowled() % 6;
            string numOvers = overs + "." + additional;
            Assert.AreEqual( numOvers , "1.0" , "Expected: 1.0; Actual : {0}" , numOvers );
        }

        /// <summary>
        /// Tests the current run rate.
        /// </summary>
        [TestMethod]
        public void TestCRR()
        {
            Cricinfo scorecard = new();
            scorecard.AddPlayer( new Player( "X" , 50 , 25 ) );
            scorecard.AddPlayer( new Player( "Y" , 58 , 29 ) );
            scorecard.AddPlayer( new Player( "Z" , 30 , 15 ) );
            float nrr = scorecard.CurrentRunRate();
            Assert.AreEqual( nrr , 12.0 , "Expected : 12.0; Actual : {0}" , nrr );
        }
    }
}
