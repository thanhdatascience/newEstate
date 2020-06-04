using newEstate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newEstate.Services
{
    public interface ICosmosDBService
    {
        Task<IEnumerable<EstateModel>> GetItemsAsync(string query);
        Task<EstateModel> GetItemAsync(string id);
        Task AddItemAsync(EstateModel item);
        Task UpdateItemAsync(string id, EstateModel item);
        Task DeleteItemAsync(string id);
    }
}
