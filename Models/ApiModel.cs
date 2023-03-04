namespace MvcApiCaller.Models
{
    // Vår API endpoint som  vi fetchar innehåller en lista med users,
    // så vi behöver skapa en property som är en lista av users, som är av objektet UserModel
    // eftersom endpointen innehåller users inuti en lista, med egna properties.
    public class ApiModel
    {
        public List<UserModel> Users { get; set; } = new();
    }
}
