// represents application data + business logic, often designed to represent database tables

namespace proj1.Models
{
    public class Book
    {
        public int ID { get; set; }
        public string Title { get; set; } = null!;
        public string Author { get; set; } = null!;
        public int YearPublished { get; set; }
    }
}