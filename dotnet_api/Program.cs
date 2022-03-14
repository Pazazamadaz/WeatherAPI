using static HelperFunctions.Functions;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/weatherforecast", async () =>
{
    Console.WriteLine("Please enter the name of a valid city:");
    string strCityName = "";
    strCityName = Console.ReadLine().Trim();
    bool bCityNameOK = ValidateUserInput(strCityName);
    
    if (bCityNameOK)
    {
        HttpClient client = new();

        client.DefaultRequestHeaders.Add("Key", "3ae22d492bac47b68a3184146220503");
        HttpResponseMessage response = await client.GetAsync("http://api.weatherapi.com/v1/current.json?q=" + strCityName);
        //response.EnsureSuccessStatusCode();
        string responseBody = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode)
        {
            // take the response and filter out only the values we want into a new string
            string finalResponse = FilterJSONData(responseBody);
            Console.WriteLine(finalResponse);

            return finalResponse;
        }
        else
        {

            Console.WriteLine(responseBody);

            return responseBody;
        }
    }
})
.WithName("GetWeatherForecast");

app.Run();