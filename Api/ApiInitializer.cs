namespace MvcApiCaller.Api
{
    // Steg två, skapa AppInitializer med en httpClient som kan ta en basadress
    public static class ApiInitializer
    {
        public static HttpClient httpClient { get; set; } = new();


    }
}
