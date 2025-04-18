using VanGog.Storage.Core.Entities;

namespace TestVanGog
{
    [TestClass]
    public class VanGogTest
    {
        [TestMethod]
        public void Title_Not_Special_Characters()
        {

            Event event1 = new Event();

            event1.Title = "@СВИДАНИЕ#";
            Assert.ThrowsException<ArgumentException>(() => event1.Title);
        }
        [TestMethod]
        public void Title_Not_Empty_String()
        {

            Event event1 = new Event();
            event1.Title = "";


            Assert.ThrowsException<ArgumentException>(() => event1.Title);
        }
        [TestMethod]
        public void Title_NotStarts_With_Space()
        {

            Event event1 = new Event();
            event1.Title = " Свидание";


            Assert.ThrowsException<ArgumentException>(() => event1.Title);
        }
        [TestMethod]
        public void Title_Not_Whitespace_String()
        {

            Event event1 = new Event();
            event1.Title = "   ";

            Assert.ThrowsException<ArgumentException>(() => event1.Title);
        }
        [TestMethod]
        public void Title_Should_Accept_Value()
        {

            Event event1 = new Event();
            var title = "Свидание";
            event1.Title = title;


            Assert.AreEqual(title, event1.Title);
        }
        [TestMethod]
        public void EventId_Should_Accept_Negative_Value()
        {

            Event event1 = new Event();

            var eventId = -1;
            event1.EventId = eventId;

            Assert.AreEqual(eventId, event1.EventId);
        }
        [TestMethod]
        public void EventId_Should_Be_Correctly()
        {
            Event event1 = new Event();

            var eventId = 1;
            event1.EventId = eventId;


            Assert.AreEqual(eventId, event1.EventId);
        }
        [TestMethod]
        public void Date_Should_Accept_Value()
        {
            var date = new DateTime(2023, 10, 5);
            Event event1 = new Event();
            event1.Date = date;
            Assert.AreEqual(date, event1.Date);
        }
        [TestMethod]
        
        public void Date_Should_Accept_Future_Date()
        {
            
            Event event1 = new Event();

            var futureDate = new DateTime(2050, 12, 31);
            event1.Date = futureDate;

            Assert.AreEqual(futureDate, event1.Date);
        }
        [TestMethod]
        public void Time_Should_Accept_Value()
        {
            var time = new TimeSpan(14, 30, 0);
            Event event1 = new Event();

            event1.Time = time;
            Assert.AreEqual(time, event1.Time);
        }
        [TestMethod]      
        public void Category_Correctly()
        {
            
            Event event1 = new Event();
            var category = "Информация";
            event1.Category = category;

            
            Assert.AreEqual(category, event1.Category);
        }
        [TestMethod]
        public void Category_Empty_String()
        {
            
            Event event1 = new Event();
            event1.Category = "";
            
            Assert.ThrowsException<ArgumentException>(() => event1.Category);
        }
        [TestMethod]
        public void Category_Not_Special_Characters()
        {
            Event eventInstance = new Event();
            eventInstance.Category = "@Информация;%";


            Assert.ThrowsException<ArgumentException>(() => eventInstance.Category);
        }
        [TestMethod]
        public void Category_Not_Whitespace_String()
        {
            
            Event event1 = new Event();
            event1.Category = "   ";
            
            Assert.ThrowsException<ArgumentException>(() => event1.Category);
        }
    }
}
