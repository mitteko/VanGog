using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace VanGog.Storage.Core.Entities;

public record Event
{
    [Key]
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
