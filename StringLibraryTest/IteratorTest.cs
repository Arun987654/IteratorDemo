/******************************************************************************
* Filename    = IteratorTest.cs
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
    public class IteratorTest
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
            Assert.IsNotNull( iterator );
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
            Assert.IsTrue( iterator.IsLive() );
        }

        /// <summary>
        /// Tests if the iterator is not live (no elements to iterate).
        /// </summary>
        [TestMethod]
        public void CheckIsLiveAgain()
        {
            Cricinfo scorecard = new();
            IPlayerIterator iterator = scorecard.CreateIterator();
            Assert.IsFalse( iterator.IsLive() );
        }

        /// <summary>
        /// Tests the number of wickets taken.
        /// </summary>
        [TestMethod]
        public void TestWickets()
        {
            Cricinfo scorecard = Initialise();
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
            Assert.AreEqual( wkts , 3 );
        }

        /// <summary>
        /// Tests the number of balls bowled.
        /// </summary>
        [TestMethod]
        public void TestBalls()
        {
            Cricinfo scorecard = Initialise();
            IPlayerIterator iterator = scorecard.CreateIterator();
            int balls = 0;
            while (iterator.IsLive())
            {
                Player player = iterator.Next();
                balls += player.BallsFaced;
            }
            Assert.AreEqual( balls, 6 );
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
            Assert.AreEqual( total, 6 );
        }

        /// <summary>
        /// Tests the number of overs bowled.
        /// </summary>
        [TestMethod]
        public void TestOvers()
        {
            Cricinfo scorecard = Initialise();
            IPlayerIterator iterator = scorecard.CreateIterator();
            int balls = 0;
            while (iterator.IsLive())
            {
                Player player = iterator.Next();
                balls += player.BallsFaced;
            }
            int overs = balls / 6;
            int additional = balls % 6;
            string numOvers = overs + "." + additional;
            Assert.AreEqual( numOvers , "1.0" );
        }

        /// <summary>
        /// Tests the current run rate.
        /// </summary>
        [TestMethod]
        public void TestCRR()
        {
            Cricinfo scorecard = new();
            scorecard.AddPlayer( new Player( "X" , 50 , 25 ) );
            scorecard.AddPlayer( new Player( "Y" , 58 , 29, true ) );
            scorecard.AddPlayer( new Player( "Z" , 30 , 15, true ) );
            IPlayerIterator iterator = scorecard.CreateIterator();
            int balls = 0;
            int total = 0;
            while (iterator.IsLive())
            {
                Player player = iterator.Next();
                total += player.RunsScored;
                balls += player.BallsFaced;
            }
            // Calculate the net run rate
            float nrr = (float)total*6 / balls;
            Assert.AreEqual( nrr , 12.0 );
        }

        /// <summary>
        /// Tests batsman with highest strike rate.
        /// </summary>
        [TestMethod]
        public void TestHighestSR()
        {
            Cricinfo scorecard = new();
            scorecard.AddPlayer( new Player( "X" , 50 , 25 ) );
            scorecard.AddPlayer( new Player( "Y" , 38 , 24, true ) );
            scorecard.AddPlayer( new Player( "Z" , 10 , 13, true ) );
            IPlayerIterator iterator = scorecard.CreateIterator();
            float maxSr = 0;
            string bestBatter = "";
            while (iterator.IsLive())
            {
                Player player = iterator.Next();
                float sr = player.StrikeRate;
                // If strike rate of this batsman is higher, update maxSr and bestBatter
                if(sr>maxSr)
                {
                    maxSr = sr;
                    bestBatter = player.Name;
                }
            }
            Assert.AreEqual( bestBatter , "X" );
        }
    }
}
