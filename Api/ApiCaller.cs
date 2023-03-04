using Microsoft.AspNetCore.Mvc.Infrastructure;
using MvcApiCaller.Models;
using Newtonsoft.Json;

namespace MvcApiCaller.Api
{

    // Steg ett, skapa ApiCaller
    public class ApiCaller
    {
        // 1. Skapa HttpClient
        // 2. Göra själva request
        // 3. Hantera responsen

        public async Task<ApiModel?> MakeCall(string endPoint)
        {
            // Gör själva requestet till Api:n
            HttpResponseMessage response = await ApiInitializer.httpClient.GetAsync(endPoint);

            if(response.IsSuccessStatusCode)
            {
                // Konvertera http response message till en json-sträng (läs innehållet i bodyn)
                var responseStr = await response.Content.ReadAsStringAsync();

                // Vi behöver konvertera json-strängen till C#-objekt, behövs göras ett par grejer för detta.
                // Deserialisera strängen till objekt med samma struktur som innehållet.
                // 'T.ex. om API:n innehåller en lista med users, behöver vår första objekt då vara en lista med users.
                // Det bästa är om vi först skapar klasser i model som motsvarar vad det är för endpoint vi tar emot.
                // Nedan kod konverterar j-son strängen till C# objekt.
                // Finns ett nuget package som gör detta mkt enkelt för oss, kallas för NewtonSoft.Json

                ApiModel? result = JsonConvert.DeserializeObject<ApiModel>(responseStr);

                // Returnera resultatet
                return result;
            }

            // Returnera ett tomt objekt om något gick snett
            return new ApiModel();
        }


        // Detta är en snabbare, lättare och mindre kod sätt att göra samma sak som MakeCall();
        // Skillnaden är att MakeCall(); ger oss större möjlighet att göra kontroller och även möjlighet
        // att göra något med response innan det går över till deserialiserade objekt.
        public async Task<ApiModel> MakeCallVersion2(string endPoint)
        {
            ApiModel? result = await ApiInitializer.httpClient.GetFromJsonAsync<ApiModel>(endPoint);

            return result;
        }

    }
}
