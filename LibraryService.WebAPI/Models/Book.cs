using System.ComponentModel.DataAnnotations;

namespace LibraryService.WebAPI.Models
{
    public class Book
    {
        public Book() { }

        public Book(int id, string name, string category, int libraryId)
        {
            Id = id;
            Name = name;
            Category = category;
            LibraryId = libraryId;
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public int LibraryId { get; set; }
        public virtual Library Library { get; set; }
    }
}