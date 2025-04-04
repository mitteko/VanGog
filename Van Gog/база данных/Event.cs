using System;

namespace VanGog
{
    // для будущей бд
    public class Event
    {
        public int EventId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        public TimeSpan Time { get; set; }

        public string Participants { get; set; }

        public string Category { get; set; }
        
        // путь к изображению
        public string ImagePath { get; set; }
    }
}