using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BackgroundWorker.Model;
using Core.Entities;

namespace BackgroundWorker.Services
{
    public interface IDataService
    {
        public Task<List<AFEntity>> DonwloadData();
        public List<AFEntity> FilterNewData(List<AFEntity> entities);
        public Task<List<Unit>> SaveDataAsync(List<AFEntity> entities);
    }
}
