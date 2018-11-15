using MANET_DTN_Mobile.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MANET_DTN_Mobile.DataAccess
{

    public interface IAPIClient{
        List<ItemID> GetItemIds();
        List<RemoveFlagID> GetRemoveFlagIds();
        Item PullItem(string pItemId);
        RemoveFlag PullRemoveFlag(string pFlagId);
        void PushItem(Item pItem);
        void PushRemoveFlag(RemoveFlag pFlag);
        string GetThrowBoxId();
    }


    public class APIClient: IAPIClient
    {
        private HttpClient client;
      
        public APIClient(string ssid)
        {
            client = new HttpClient();

            Dictionary<string, string> ssidUrlMapping = NodeData.GetSSIDURLMapping();

            client.BaseAddress = new Uri(ssidUrlMapping[ssid]);
        }

        public List<ItemID> GetItemIds()
        {
            var vResponseAsync = client.GetAsync("/api/itemIDLists/");
            var vJsonAsString = vResponseAsync.Result.Content.ReadAsStringAsync();
            var vDeserialized = JsonConvert.DeserializeObject<List<ItemID>>(vJsonAsString.Result);
            return vDeserialized;
        }

        public List<RemoveFlagID> GetRemoveFlagIds()
        {
            var vResponseAsync = client.GetAsync("/api/removeIDLists");
            var vJsonAsString = vResponseAsync.Result.Content.ReadAsStringAsync();
            var vDeserialized = JsonConvert.DeserializeObject<List<RemoveFlagID>>(vJsonAsString.Result);
            return vDeserialized;
        }

        public string GetThrowBoxId()
        {
            var vResponseAsync = client.GetAsync("/api/nodeId");
            var vJsonAsString = vResponseAsync.Result.Content.ReadAsStringAsync();
            var vDeserialized = JsonConvert.DeserializeObject<string>(vJsonAsString.Result);
            return vDeserialized;
        }

        public Item PullItem(string pItemId)
        {
            var vResponseAsync = client.GetAsync("/api/items/" + pItemId);
            var vJsonAsString = vResponseAsync.Result.Content.ReadAsStringAsync();
            var vDeserialized = JsonConvert.DeserializeObject<Item>(vJsonAsString.Result);
            return vDeserialized;
        }

        public RemoveFlag PullRemoveFlag(string pFlagId)
        {
            var vResponseAsync = client.GetAsync("/api/removeFlags/" + pFlagId);
            var vJsonAsString = vResponseAsync.Result.Content.ReadAsStringAsync();
            var vDeserialized = JsonConvert.DeserializeObject<RemoveFlag>(vJsonAsString.Result);
            return vDeserialized;
        }

        //public async Task<HttpResponseMessage> PushItem(Item pItem)
        public void PushItem(Item pItem)
        {
            var data = new StringContent(pItem.ToJson(), Encoding.UTF8, "application/json");
            client.PostAsync("/api/items", data);
        }

        public void PushRemoveFlag(RemoveFlag pFlag)
        {
            var data = new StringContent(pFlag.ToJson(), Encoding.UTF8, "application/json");
            client.PostAsync("/api/removeFlags", data);
        }
    }
}
