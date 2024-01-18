using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;

namespace tda_proj.Service.LectorServices

{
    private async Task MakePostRequest()
    {
        try
        {
            // Replace "https://api.example.com" and "/api/resource" with your API endpoint
            var apiUrl = "https://api.example.com/api/resource";

            // Create an instance of your data model (replace MyModel with your actual model)
            var dataToSend = new Lector();
            

            // Serialize the data to JSON
            var jsonContent = JsonSerializer.Serialize(dataToSend);

            // Set the content type header
            HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // Send the POST request
            var response = await HttpClient.PostAsync(apiUrl, new StringContent(jsonContent, Encoding.UTF8, "application/json"));

            // Check if the request was successful
            response.EnsureSuccessStatusCode();

            // Optionally, read and process the response
            var responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseBody);
        }
        catch (HttpRequestException ex)
        {
            // Handle exceptions
            Console.WriteLine($"Request failed: {ex.Message}");
        }
    }

}
