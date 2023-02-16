using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BackgroundWorker.Services;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BackgroundWorker
{
    public class UpdateDataWorker : IHostedService
    {
        private readonly ILogger<UpdateDataWorker> _logger;

        private readonly IDataService _dataService;
        private readonly INotifyService _notifyService;

        public UpdateDataWorker(ILogger<UpdateDataWorker> logger, IDataService dataService, INotifyService notifyService)
        {
            _logger = logger;
            _dataService = dataService;
            _notifyService = notifyService;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            var updateTimer = new Timer(UpdateData, null, 0, 1000 * 10); //Runs every 10 seconds.
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async void UpdateData(object state)
        {
            var downloadedData = await _dataService.DonwloadData();
            var filterData = _dataService.FilterNewData(downloadedData);
            var savedUnits = await _dataService.SaveDataAsync(filterData);

            await _notifyService.SendNotification(savedUnits);


        }
    }
}
