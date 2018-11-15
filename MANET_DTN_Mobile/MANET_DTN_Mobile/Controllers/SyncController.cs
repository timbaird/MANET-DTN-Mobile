using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using MANET_DTN_Mobile.DataAccess;
using MANET_DTN_Mobile.Models;
using Xamarin.Forms;

namespace MANET_DTN_Mobile.Controllers
{
    public interface ISyncController{
        bool SyncRequired();
        void Sync();
    }

    public class SyncController:ISyncController
    {
        private ILocalDBHandler db;
        private IAPIClient api;

        public SyncController(string ssid)
        {
            db = new LocalDBHandler();
            api = new APIClient(ssid);
        }

        public bool SyncRequired()
        {
            /*
            try
            {
                //var throwBoxId = api.GetThrowBoxId();
                var throwBoxId = api.GetThrowBoxId();

                var tid = throwBoxId.Result;

                var lastSync = db.GetLastSyncDateTime(tid);
                var resyncThreshold = NodeData.GetMinsBetweenResync();
                var targetDateTime = lastSync.AddMinutes(resyncThreshold);

                // check if last sync was longer ago than the resync threshold
                return targetDateTime < DateTime.Now;
            }
            catch (Exception ex)
            {
                //Console.Writeline("Exception in SyncRequired() " + ex.Message);
                return false;
            }
            */
            return true;
        }

        public void Sync()
        {
            db.LogSyncStarted();

            SyncRemoveFlags();

            SyncItems();

            db.LogSyncComplete();
        }

        private void SyncRemoveFlags()
        {
            List<RemoveFlagID> remoteFlagIds = new List<RemoveFlagID>();
            List<RemoveFlag> localFlags = new List<RemoveFlag>();

            try
            {
                // get list of remove flag ID's from throwbox
                remoteFlagIds = api.GetRemoveFlagIds();
                localFlags = db.GetAllFlags();
            }
            catch(Exception ex)
            {
                throw ex;
            }

            int i;
            List<RemoveFlag> temp;

            // loop through each 
            for (i = 0; i < remoteFlagIds.Count;i++)
            {
                temp = localFlags.Where(x => x.ItemId == remoteFlagIds[i].ItemId).ToList();

                if (temp.Count() < 1){
                    // flag exists in remote but not in local
                    // pull it from remote
                    var flag = api.PullRemoveFlag(remoteFlagIds[i].ItemId);
                    // save it to local
                    db.SaveFlag(flag);
                    // delete 
                    db.DeleteItem(flag);

                }
                else
                {
                    // flag already exists in both local and remote
                    // remove it from localList
                    localFlags = localFlags.Except(temp).ToList();
                }
            }

            for (i = 0; i < localFlags.Count(); i++)
            {
                // for each local flag not in remote db push it through
                api.PushRemoveFlag(localFlags[i]);
            }
        }

        private void SyncItems()
        {
            List<ItemID> remoteItemIds = new List<ItemID>();
            List<Item> localItems = new List<Item>();

            try
            {
                remoteItemIds = api.GetItemIds();
                localItems = db.GetAllItems();
            }
            catch (Exception ex)
            {
                throw ex;
            }
                int i;
                List<Item> temp;

                // loop through each 
                for (i = 0; i < remoteItemIds.Count; i++)
                {
                    // this will give a list of local items that have a corresponding id to the current remote item
                    // if this is 0 then the remote item doesn't exist locally
                    temp = localItems.Where(x => x.ItemId == remoteItemIds[i].ItemId).ToList();

                    if (temp.Count() == 0)
                    {
                        try { 
                        // item exists in remote but not in local
                        // pull it from remote
                        var item = api.PullItem(remoteItemIds[i].ItemId);
                        // save it to local
                        db.SaveItem(item);
                        }
                        catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                else
                {
                    // flag already exists in both local and remote
                    // remove it from localList
                    localItems = localItems.Except(temp).ToList();
                }
            }

            // only local items not present in remote should remian in this list
            for (i = 0; i < localItems.Count(); i++)
            {
                try
                {
                    // for each local flag not in remote db push it through
                    //var response = api.PushItem(localItems[i]);
                    api.PushItem(localItems[i]);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
