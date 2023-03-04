namespace MvcApiCaller.Models
{
    // Vår api innehåller en lista med users, och dessa users innehåller en hel del properties
    // som vi behöver matcha för att få ut så mycket information av API:n som vi vill ha.
    public class UserModel
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MaidenName { get; set; }

        public int? Age { get; set; }
        public string? Gender { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }

        public string? Username { get; set; }

    }
}
