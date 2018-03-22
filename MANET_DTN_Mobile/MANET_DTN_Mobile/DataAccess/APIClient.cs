using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using MANET_DTN_Mobile.Models;
using ModernHttpClient;
using Newtonsoft;
using Newtonsoft.Json;
using System.Text;

namespace MANET_DTN_Mobile.DataAccess
{

    public interface IAPIClient{
        Task<List<ItemID>> GetItemIds();
        Task<List<RemoveFlagID>> GetRemoveFlagIds();
        Task<Item> PullItem(string pItemId);
        Task<RemoveFlag> PullRemoveFlag(string pFlagId);
        Task<HttpResponseMessage> PushItem(Item pItem);
        Task<HttpResponseMessage> PushRemoveFlag(RemoveFlag pFlag);
        Task<string> GetThrowBoxId();
    }


    public class APIClient: IAPIClient
    {
        private HttpClient client;
      
        public APIClient()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(NodeData.GetApiBaseUrl());
        }

        public async Task<List<ItemID>> GetItemIds()
        {
            var vResponseAsync = await client.GetAsync("/api/itemIDLists/").ConfigureAwait(false);
            var vJsonAsString = await vResponseAsync.Content.ReadAsStringAsync();
            var vDeserialized = JsonConvert.DeserializeObject<List<ItemID>>(vJsonAsString);
            return vDeserialized;
        }

        public async Task<List<RemoveFlagID>> GetRemoveFlagIds()
        {
            var vResponseAsync = await client.GetAsync("/api/removeIDLists").ConfigureAwait(false);
            var vJsonAsString = await vResponseAsync.Content.ReadAsStringAsync();
            var vDeserialized = JsonConvert.DeserializeObject<List<RemoveFlagID>>(vJsonAsString);
            return vDeserialized;
        }

        public async Task<string> GetThrowBoxId()
        {
            var vResponseAsync = await client.GetAsync("/api/nodeId").ConfigureAwait(false);
            var vJsonAsString = await vResponseAsync.Content.ReadAsStringAsync();
            var vDeserialized = JsonConvert.DeserializeObject<string>(vJsonAsString);
            return vDeserialized;
        }

        public async Task<Item> PullItem(string pItemId)
        {
            var vResponseAsync = await client.GetAsync("/api/items/" + pItemId).ConfigureAwait(false);
            var vJsonAsString = await vResponseAsync.Content.ReadAsStringAsync();
            var vDeserialized = JsonConvert.DeserializeObject<Item>(vJsonAsString);
            return vDeserialized;
        }

        public async Task<RemoveFlag> PullRemoveFlag(string pFlagId)
        {
            var vResponseAsync = await client.GetAsync("/api/removeFlags/" + pFlagId).ConfigureAwait(false);
            var vJsonAsString = await vResponseAsync.Content.ReadAsStringAsync();
            var vDeserialized = JsonConvert.DeserializeObject<RemoveFlag>(vJsonAsString);
            return vDeserialized;
        }

        public async Task<HttpResponseMessage> PushItem(Item pItem)
        {
            var data = new StringContent(pItem.ToJson(), Encoding.UTF8, "application/json");
            var vResponseAsync = await client.PostAsync("/api/items/", data).ConfigureAwait(false);
            return vResponseAsync;
        }

        public async Task<HttpResponseMessage> PushRemoveFlag(RemoveFlag pFlag)
        {
            var data = new StringContent(pFlag.ToJson(), Encoding.UTF8, "application/json");
            var vResponseAsync = await client.PostAsync("/api/removeFlags/", data).ConfigureAwait(false);
            return vResponseAsync;
        }
    }
}
