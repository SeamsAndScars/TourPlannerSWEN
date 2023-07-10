global using NUnit.Framework;
using NUnit.Framework;
using TourPlanner_Client.Models;

namespace TourPlanner_UnitTests
{
    [TestFixture]
    public class UnitTests
    {
        [Test]
        public void TestTourName()
        {
            // Arrange
            Tour tour = new Tour("Tour 1", "", "", "", TransportType.Hike);

            // Act
            string name = tour.Name;

            // Assert
            Assert.AreEqual("Tour 1", name);
        }

        [Test]
        public void TestTourDistance()
        {
            // Arrange
            Tour tour = new Tour("", "", "", "", TransportType.Hike);
            tour.Distance = 100;

            // Act
            double distance = tour.Distance;

            // Assert
            Assert.AreEqual(100, distance);
        }

        [Test]
        public void TestTourDescription()
        {
            // Arrange
            Tour tour = new Tour("", "Sample tour description", "", "", TransportType.Hike);

            // Act
            string description = tour.Description;

            // Assert
            Assert.AreEqual("Sample tour description", description);
        }

        [Test]
        public void TestTourSource()
        {
            // Arrange
            Tour tour = new Tour("", "", "Source location", "", TransportType.Hike);

            // Act
            string source = tour.Source;

            // Assert
            Assert.AreEqual("Source location", source);
        }

        [Test]
        public void TestTourDestination()
        {
            // Arrange
            Tour tour = new Tour("", "", "", "Destination location", TransportType.Hike);

            // Act
            string destination = tour.Destination;

            // Assert
            Assert.AreEqual("Destination location", destination);
        }

        [Test]
        public void TestTourLogsCount()
        {
            // Arrange
            Tour tour = new Tour("", "", "", "", TransportType.Hike);
            tour.TourLogs.Add(new TourLog(Guid.NewGuid(), DateTime.Now, "", Difficulty.Simple, "", Rating.Great));
            tour.TourLogs.Add(new TourLog(Guid.NewGuid(), DateTime.Now, "", Difficulty.Simple, "", Rating.Great));
            tour.TourLogs.Add(new TourLog(Guid.NewGuid(), DateTime.Now, "", Difficulty.Simple, "", Rating.Great));

            // Act
            int logCount = tour.TourLogs.Count;

            // Assert
            Assert.AreEqual(3, logCount);
        }

        [Test]
        public void TestTourLogDate()
        {
            // Arrange
            TourLog tourLog = new TourLog(Guid.NewGuid(), new DateTime(2023, 1, 1), "", Difficulty.Simple, "", Rating.Great);

            // Act
            DateTime date = tourLog.Date;

            // Assert
            Assert.AreEqual(new DateTime(2023, 1, 1), date);
        }

        [Test]
        public void TestTourLogComment()
        {
            // Arrange
            TourLog tourLog = new TourLog(Guid.NewGuid(), DateTime.Now, "Sample tour log comment", Difficulty.Simple, "", Rating.Great);

            // Act
            string comment = tourLog.Comment;

            // Assert
            Assert.AreEqual("Sample tour log comment", comment);
        }

        [Test]
        public void TestTourLogDifficulty()
        {
            // Arrange
            TourLog tourLog = new TourLog(Guid.NewGuid(), DateTime.Now, "", Difficulty.Advanced, "", Rating.Great);

            // Act
            Difficulty difficulty = tourLog.Difficulty;

            // Assert
            Assert.AreEqual(Difficulty.Advanced, difficulty);
        }

        [Test]
        public void TestTourLogTime()
        {
            // Arrange
            TourLog tourLog = new TourLog(Guid.NewGuid(), DateTime.Now, "", Difficulty.Simple, "1 hour 30 minutes", Rating.Great);

            // Act
            string time = tourLog.Time;

            // Assert
            Assert.AreEqual("1 hour 30 minutes", time);
        }

        [Test]
        public void TestTourLogRating()
        {
            // Arrange
            TourLog tourLog = new TourLog(Guid.NewGuid(), DateTime.Now, "", Difficulty.Simple, "", Rating.Great);

            // Act
            Rating rating = tourLog.Rating;

            // Assert
            Assert.AreEqual(Rating.Great, rating);
        }

      

        [Test]
        public void TestTourLogTourId()
        {
            // Arrange
            Guid tourId = Guid.NewGuid();
            TourLog tourLog = new TourLog(tourId, DateTime.Now, "", Difficulty.Simple, "", Rating.Great);

            // Act
            Guid logTourId = tourLog.TourId;

            // Assert
            Assert.AreEqual(tourId, logTourId);
        }


        [Test]
        public void TestTourLogRatingToString()
        {
            // Arrange
            TourLog tourLog = new TourLog(Guid.NewGuid(), DateTime.Now, "", Difficulty.Simple, "", Rating.Great);

            // Act
            string ratingString = tourLog.Rating.ToString();

            // Assert
            Assert.AreEqual("Great", ratingString); // Expected rating string representation
        }

        [Test]
        public void TestTourLogDifficultyToString()
        {
            // Arrange
            TourLog tourLog = new TourLog(Guid.NewGuid(), DateTime.Now, "", Difficulty.Simple, "", Rating.Great);

            // Act
            string difficultyString = tourLog.Difficulty.ToString();

            // Assert
            Assert.AreEqual("Simple", difficultyString); // Expected difficulty string representation
        }

        [Test]
        public void TestTourLogIdGeneration()
        {
            // Arrange
            Guid tourId = Guid.NewGuid();
            TourLog tourLog1 = new TourLog(tourId, DateTime.Now, "", Difficulty.Simple, "", Rating.Great);
            TourLog tourLog2 = new TourLog(tourId, DateTime.Now, "", Difficulty.Advanced, "", Rating.Good);

            // Assert
            Assert.AreNotEqual(tourLog1.Id, tourLog2.Id); // Tour logs should have unique IDs
        }

        [Test]
        public void TestTourLogsListInitialization()
        {
            // Arrange
            Tour tour = new Tour("", "", "", "", TransportType.Hike);

            // Assert
            Assert.IsNotNull(tour.TourLogs); // Expected TourLogs list to be initialized
            Assert.IsEmpty(tour.TourLogs); // Expected TourLogs list to be empty
        }

        [Test]
        public void TestTourLogInitialization()
        {
            // Arrange
            Guid tourId = Guid.NewGuid();
            DateTime date = DateTime.Now;
            string comment = "Sample comment";
            Difficulty difficulty = Difficulty.Simple;
            string time = "1 hour";
            Rating rating = Rating.Great;

            // Act
            TourLog tourLog = new TourLog(tourId, date, comment, difficulty, time, rating);

            // Assert
            Assert.AreEqual(tourId, tourLog.TourId); // Expected TourId to be set correctly
            Assert.AreEqual(date, tourLog.Date); // Expected Date to be set correctly
            Assert.AreEqual(comment, tourLog.Comment); // Expected Comment to be set correctly
            Assert.AreEqual(difficulty, tourLog.Difficulty); // Expected Difficulty to be set correctly
            Assert.AreEqual(time, tourLog.Time); // Expected Time to be set correctly
            Assert.AreEqual(rating, tourLog.Rating); // Expected Rating to be set correctly
        }

        [Test]
        public void TestTourLogListCountAfterAddition()
        {
            // Arrange
            Tour tour = new Tour("", "", "", "", TransportType.Hike);
            TourLog tourLog = new TourLog(Guid.NewGuid(), DateTime.Now, "", Difficulty.Simple, "", Rating.Great);

            // Act
            tour.TourLogs.Add(tourLog);

            // Assert
            Assert.AreEqual(1, tour.TourLogs.Count); // Expected TourLogs count to be 1 after addition
            Assert.Contains(tourLog, tour.TourLogs); // Expected TourLogs to contain the added TourLog
        }

        [Test]
        public void TestTourLogListCountAfterRemoval()
        {
            // Arrange
            Tour tour = new Tour("", "", "", "", TransportType.Hike);
            TourLog tourLog = new TourLog(Guid.NewGuid(), DateTime.Now, "", Difficulty.Simple, "", Rating.Great);
            tour.TourLogs.Add(tourLog);

            // Act
            tour.TourLogs.Remove(tourLog);

            // Assert
            Assert.AreEqual(0, tour.TourLogs.Count); // Expected TourLogs count to be 0 after removal
            Assert.IsFalse(tour.TourLogs.Contains(tourLog)); // Expected TourLogs to not contain the removed TourLog
        }

        [Test]
        public void TestTourLogRatingEnumValues()
        {
            // Arrange
            Rating[] ratings = Enum.GetValues(typeof(Rating)).Cast<Rating>().ToArray();

            // Assert
            Assert.AreEqual(5, ratings.Length); // Expected number of rating enum values
            Assert.Contains(Rating.Great, ratings); // Expected rating enum values to contain "Great"
            Assert.Contains(Rating.Good, ratings); // Expected rating enum values to contain "Good"
            Assert.Contains(Rating.Mediocre, ratings); // Expected rating enum values to contain "Mediocre"
            Assert.Contains(Rating.Bad, ratings); // Expected rating enum values to contain "Bad"
            Assert.Contains(Rating.Terrible, ratings); // Expected rating enum values to contain "Terrible"
        }

        [Test]
        public void TestTourLogDifficultyEnumValues()
        {
            // Arrange
            Difficulty[] difficulties = Enum.GetValues(typeof(Difficulty)).Cast<Difficulty>().ToArray();

            // Assert
            Assert.AreEqual(4, difficulties.Length); // Expected number of difficulty enum values
            Assert.Contains(Difficulty.Simple, difficulties); // Expected difficulty enum values to contain "Simple"
            Assert.Contains(Difficulty.Advanced, difficulties); // Expected difficulty enum values to contain "Advanced"
            Assert.Contains(Difficulty.Hard, difficulties); // Expected difficulty enum values to contain "Hard"
            Assert.Contains(Difficulty.Overkill, difficulties); // Expected difficulty enum values to contain "Overkill"
        }

    }
}
