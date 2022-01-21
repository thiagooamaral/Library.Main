using Newtonsoft.Json;
using LibraryService.WebAPI.Models;

namespace LibraryService.WebAPI.SeedData
{
    public class LibraryForm
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        public static implicit operator Library(LibraryForm form) =>
            new Library(form.Id, form.Name, form.Location);
    }
}
