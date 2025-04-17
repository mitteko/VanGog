using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace VanGog.Storage.Core.Entities;

public record Event
{
    [Key]
    private string title;
    private string category;
    public int EventId { get; set; }
    public string Title
    {
        get
        {
            if (Regex.Match(title, "^[а-яА-Я]*$").Success)
            {
                if (string.IsNullOrWhiteSpace(title))
                {
                    throw new ArgumentException("Название не может быть пустым или содержать только пробелы.");
                }

                if (char.IsWhiteSpace(title[0]))
                {
                    throw new ArgumentException("Название не должно начинаться с пробела.");
                }
            }
            else
            {
                throw new ArgumentException("Название может содержать только буквенные символы", nameof(Title));
            }
            return title;
        }
        set
        {
           title = value;
        }
    }
public string Description { get; set; }

    public DateTime Date { get; set; }

    public TimeSpan Time { get; set; }

    public string Participants { get; set; } = string.Empty;

    public string Category
    {
        get
        {
            if (Regex.Match(category, "^[а-яА-Я]*$").Success)
            {
                if (string.IsNullOrWhiteSpace(category))
                {
                    throw new ArgumentException("Категория не может быть пустой или содержать только пробелы.");
                }
            }
            else
            {
                throw new ArgumentException("Категория не может содержать специальные символы", nameof(Category));
            }
            return category;
        }
        set
        {
            category = value;
        }
    }
        
    // путь к изображению
    public string ImagePath { get; set; }

    // ID создателя события (для идентификации созданных пользователем событий)
    public string CreatorId { get; set; } = string.Empty;
}
