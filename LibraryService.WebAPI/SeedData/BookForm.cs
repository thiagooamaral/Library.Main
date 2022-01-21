using Newtonsoft.Json;
using LibraryService.WebAPI.Models;

namespace LibraryService.WebAPI.SeedData
{
    public class BookForm
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("libraryId")]
        public int LibraryId { get; set; }

        public static implicit operator Book(BookForm form) =>
            new Book(form.Id, form.Name, form.Category, form.LibraryId);
    }
}
