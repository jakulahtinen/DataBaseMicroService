using DataBaseMicroService.DTO;
using DataBaseMicroService.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace DataBaseMicroService.Service
{
    public class ElectricityPriceService
    {
        private readonly MyDbContext _context;

        public ElectricityPriceService()
        {
            _context = new MyDbContext();
        }

        public async Task<bool> SaveAsync(ElectricityPriceDataDtoIn electricityPriceDataDtoIn)
        {

            try
            {
                foreach (var price in electricityPriceDataDtoIn.Prices)
                {

                    var priceEntity = price.ToEntity();

                    _context.ElectricityPrices.Add(priceEntity);
                }

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.ToString());

                return false;
            }

            return true;
        }

        //public async Task<decimal> GetElectricityPriceAsync()
        //{
        //    var apiUrl = "https://localhost:7273/api/Electricity/GetSahko";

        //    try
        //    {
        //        using var httpClient = _httpClientFactory.CreateClient();
        //        var response = await httpClient.GetAsync(apiUrl);

        //        if (response.IsSuccessStatusCode)
        //        {
        //            var content = await response.Content.ReadAsStringAsync();
        //            Console.WriteLine($"Response content: {content}");

        //            // Muunna data desimaaliluvuksi
        //            if (decimal.TryParse(content, out var price))
        //            {
        //                return price;
        //            }
        //            else
        //            {
        //                Console.WriteLine("Error parsing electricity price from API response.");
        //            }
        //        }
        //        else
        //        {
        //            // Log the error for non-successful HTTP status codes
        //            Console.WriteLine($"API request failed with status code: {response.StatusCode}");
        //        }
        //    }
        //    catch (HttpRequestException ex) when (ex.InnerException is WebException webEx)
        //    {
        //        // Log the error for HTTP request exception and inner WebException
        //        Console.WriteLine($"HTTP request exception: {ex.Message}");
        //        Console.WriteLine($"Inner WebException: {webEx.Message}");
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log any other exceptions
        //        Console.WriteLine($"Error during API request: {ex.Message}");
        //    }

        //    // Return a default value if there's an error
        //    return 0.0m;
        //}
    }
}
