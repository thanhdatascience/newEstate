using Microsoft.Azure.Cosmos;
using newEstate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newEstate.Services
{
    public class CosmosDbService : ICosmosDBService
    {
        private Container _container;

        public CosmosDbService(
            CosmosClient dbClient,
            string databaseName,
            string containerName)
        {
            this._container = dbClient.GetContainer(databaseName, containerName);
        }

        public async Task AddItemAsync(EstateModel item)
        {
            await this._container.CreateItemAsync<EstateModel>(item, new PartitionKey(item.Id));
        }

        public async Task DeleteItemAsync(string id)
        {
            await this._container.DeleteItemAsync<EstateModel>(id, new PartitionKey(id));
        }

        public async Task<EstateModel> GetItemAsync(string id)
        {
            try
            {
                ItemResponse<EstateModel> response = await this._container.ReadItemAsync<EstateModel>(id, new PartitionKey(id));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }

        }

        public async Task<IEnumerable<EstateModel>> GetItemsAsync(string queryString)
        {
            var query = this._container.GetItemQueryIterator<EstateModel>(new QueryDefinition(queryString));
            List<EstateModel> results = new List<EstateModel>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();

                results.AddRange(response.ToList());
            }

            return results;
        }

        public async Task UpdateItemAsync(string id, EstateModel item)
        {
            await this._container.UpsertItemAsync<EstateModel>(item, new PartitionKey(id));
        }
    }
}
