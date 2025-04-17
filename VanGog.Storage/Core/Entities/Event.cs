using System.ComponentModel.DataAnnotations;

namespace VanGog.Storage.Core.Entities;

public record Event
{
    [Key]
    public int EventId { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public DateTime Date { get; set; }

    public TimeSpan Time { get; set; }

    public string Category { get; set; }
        
    // путь к изображению
    public string ImagePath { get; set; }

    // ID создателя события (для идентификации созданных пользователем событий)
    public string CreatorId { get; set; } = string.Empty;
}
