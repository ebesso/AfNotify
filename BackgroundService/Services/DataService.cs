using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using BackgroundWorker.Model;
using Core.Entities;
using Core.Enums;
using Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace BackgroundWorker.Services
{
    public class DataService : IDataService
    {
        private readonly string _url = "https://api.afbostader.se:442/redimo/rest/vacantproducts?lang=en_EN";
        private HttpClient _httpClient;

        private readonly ILogger<DataService> _logger;
        private readonly IServiceScopeFactory _scopeFactory;

        public DataService(ILogger<DataService> logger, IServiceScopeFactory scopeFactory)
        {
            _httpClient = new HttpClient();
            _logger = logger;
            _scopeFactory = scopeFactory;

        }

        public async Task<List<AFEntity>> DonwloadData()
        {
            var response = await _httpClient.GetAsync(_url);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var data = JsonSerializer.Deserialize<AFResponse>(content);
                var entities = data.Items;

                _logger.LogInformation($"Download data successful. Found {entities.Count} entities");

                return entities;
            }
            else
            {
                _logger.LogCritical("Failed to download data");
                return new List<AFEntity>();
            }
        }

        public List<AFEntity> FilterNewData(List<AFEntity> entities)
        {
            var ids = entities.Select(e => e.ProductId).Select(int.Parse).ToList();

            using(var scope = _scopeFactory.CreateScope())
            {
                var repository = scope.ServiceProvider.GetRequiredService<IUnitRepository>();
                var newIds = repository.FilterNewProductIds(ids).ToHashSet();
                _logger.LogInformation($"Found {newIds.Count} new entities");
                return entities.Where(e => newIds.Contains(Convert.ToInt32(e.ProductId))).ToList();
            }
        }

        public async Task<List<Unit>> SaveDataAsync(List<AFEntity> entities)
        {
            var units = entities.Select(e => new Unit()
            {
                Adress = e.Adress,
                Area = e.Area,
                Floor = Convert.ToInt32(e.Floor),
                FurnitureIncluded = e.Description.Contains("Furniture included"),
                NovishPriority = e.Priority == "Novisch",
                Rent = Convert.ToInt32(e.Rent),
                ProductId = Convert.ToInt32(e.ProductId),
                RentalPeriods = Convert.ToInt32(e.RentalPeriods),
                Rooms = e.ShortDescription == "Corridor room" ? 1 : Convert.ToInt32(e.ShortDescription.Split(' ')[0]),
                Size = Convert.ToDouble(e.Size),
                ZipCode = 0,
                ReservationDeadline = DateTime.Parse(e.ReservationDeadline),
                UnitType = e.Type == "Apartment" ? UnitType.Appartment : UnitType.Corridor

            }).ToList();

            using(var scope = _scopeFactory.CreateScope())
            {
                var repository = scope.ServiceProvider.GetRequiredService<IUnitRepository>();
                await repository.CreateAsync(units);
                _logger.LogInformation($"Saved {units.Count} new entities");

                return units;
            }



        }
    }
}
