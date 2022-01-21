using System.ComponentModel.DataAnnotations;

namespace LibraryService.WebAPI.Models
{
    public class Library
    {
        public Library() { }

        public Library(int id, string name, string location)
        {
            Id = id;
            Name = name;
            Location = location;
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
    }
}