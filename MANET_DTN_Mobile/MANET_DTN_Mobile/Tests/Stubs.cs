using System;
using MANET_DTN_Mobile.Controllers;
using MANET_DTN_Mobile.Models;
using MANET_DTN_Mobile.DataAccess;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace MANET_DTN_Mobile.Tests
{
    /*
    public class StubAPIClient : IAPIClient
    {
        
    }
    */

    /*
    public class StubLocalDBHandler : ILocalDBHandler
    {
        public void DeleteItem(Item pItem)
        {
            throw new NotImplementedException();
        }

        public List<Item> GetData()
        {
            return new List<Item>{

                new Item("61438111116_1", "DATA", "61438111116", null,
                         "Stock Take Results", "Lorem ipsum dolor sit amet, consectetur " +
                         "adipiscing elit, sed do eiusmod tempor incididunt ut labore et " +
                         "dolore magna aliqua. Ut enim ad minim veniam, quis nostrud " +
                         "exercitation ullamco laboris nisi ut aliquip ex ea commodo " +
                         "consequat. Duis aute irure dolor in reprehenderit in voluptate ",
                         Convert.ToDateTime("05/05/2017"), "NORMAL"),

                new Item("61438111117_2", "DATA", "61438111117", null,
                         "Medicine Distribution Records", "Lorem ipsum dolor sit amet, consectetur " +
                         "adipiscing elit, sed do eiusmod tempor incididunt ut labore et " +
                         "dolore magna aliqua. Ut enim ad minim veniam, quis nostrud " +
                         "exercitation ullamco laboris nisi ut aliquip ex ea commodo " +
                         "consequat. Duis aute irure dolor in reprehenderit in voluptate ",
                         Convert.ToDateTime("07/05/2017"), "NORMAL"),

                new Item("61438111118_7", "DATA", "61438111118", null,
                         "TV Guide", "Lorem ipsum dolor sit amet, consectetur " +
                         "adipiscing elit, sed do eiusmod tempor incididunt ut labore et " +
                         "dolore magna aliqua. Ut enim ad minim veniam, quis nostrud " +
                         "exercitation ullamco laboris nisi ut aliquip ex ea commodo " +
                         "consequat. Duis aute irure dolor in reprehenderit in voluptate ",
                         Convert.ToDateTime("10/05/2017"), "NORMAL")
            };
        }

        public Item GetItemById(string pItemId)
        {
            throw new NotImplementedException();
        }

        public List<string> GetItemIdsToPull(List<Item> pInputList)
        {
            throw new NotImplementedException();
        }

        public List<string> GetItemIdsToPush(List<Item> pInputList)
        {
            throw new NotImplementedException();
        }

        public DateTime GetLastSync(string pThrowboxId)
        {
            throw new NotImplementedException();
        }

        public List<Item> GetReceivedMessages()
        {
            return new List<Item>{

                new Item("61438111116_1", "MESSAGE", "61438111116", "610438000000",
                         "Be Home For Dinner", "Lorem ipsum dolor sit amet, consectetur " +
                         "adipiscing elit, sed do eiusmod tempor incididunt ut labore et " +
                         "dolore magna aliqua. Ut enim ad minim veniam, quis nostrud " +
                         "exercitation ullamco laboris nisi ut aliquip ex ea commodo " +
                         "consequat. Duis aute irure dolor in reprehenderit in voluptate ",
                         Convert.ToDateTime("05/05/2017"), "NORMAL"),

                new Item("61438111117_2", "MESSAGE", "61438111117", "610438000000",
                         "Please Pick Up Some Milk", "Lorem ipsum dolor sit amet, consectetur " +
                         "adipiscing elit, sed do eiusmod tempor incididunt ut labore et " +
                         "dolore magna aliqua. Ut enim ad minim veniam, quis nostrud " +
                         "exercitation ullamco laboris nisi ut aliquip ex ea commodo " +
                         "consequat. Duis aute irure dolor in reprehenderit in voluptate ",
                         Convert.ToDateTime("07/05/2017"), "NORMAL"),

                new Item("61438111118_7", "MESSAGE", "61438111118", "610438000000",
                         "Check out this cute cat video", "Lorem ipsum dolor sit amet, consectetur " +
                         "adipiscing elit, sed do eiusmod tempor incididunt ut labore et " +
                         "dolore magna aliqua. Ut enim ad minim veniam, quis nostrud " +
                         "exercitation ullamco laboris nisi ut aliquip ex ea commodo " +
                         "consequat. Duis aute irure dolor in reprehenderit in voluptate ",
                         Convert.ToDateTime("10/05/2017"), "NORMAL"),

                new Item("61438111116_5", "MESSAGE", "61438111116", "610438000000",
                         "You're Late!", "Lorem ipsum dolor sit amet, consectetur " +
                         "adipiscing elit, sed do eiusmod tempor incididunt ut labore et " +
                         "dolore magna aliqua. Ut enim ad minim veniam, quis nostrud " +
                         "exercitation ullamco laboris nisi ut aliquip ex ea commodo " +
                         "consequat. Duis aute irure dolor in reprehenderit in voluptate ",
                         Convert.ToDateTime("05/05/2017"), "NORMAL")
            };
        }

        public RemoveFlag GetRemoveFlagById(string pFlagId)
        {
            throw new NotImplementedException();
        }

        public List<string> GetRemoveFlagIdsToPull(List<RemoveFlag> pInputList)
        {
            throw new NotImplementedException();
        }

        public List<string> GetRemoveFlagIdsToPush(List<RemoveFlag> pInputList)
        {
            throw new NotImplementedException();
        }

        public Task<ObservableCollection<Item>> GetSentMessages()
        {
            throw new NotImplementedException();

                        return new List<Item>{

                new Item("610438000000_1", "MESSAGE", "610438000000", "61438111116",
                         "Be Home For Dinner", "Lorem ipsum dolor sit amet, consectetur " +
                         "adipiscing elit, sed do eiusmod tempor incididunt ut labore et " +
                         "dolore magna aliqua. Ut enim ad minim veniam, quis nostrud " +
                         "exercitation ullamco laboris nisi ut aliquip ex ea commodo " +
                         "consequat. Duis aute irure dolor in reprehenderit in voluptate ",
                         Convert.ToDateTime("05/05/2017"), "NORMAL"),

                new Item("610438000000_2", "MESSAGE", "610438000000", "61438111117", 
                         "Please Pick Up Some Milk", "Lorem ipsum dolor sit amet, consectetur " +
                         "adipiscing elit, sed do eiusmod tempor incididunt ut labore et " +
                         "dolore magna aliqua. Ut enim ad minim veniam, quis nostrud " +
                         "exercitation ullamco laboris nisi ut aliquip ex ea commodo " +
                         "consequat. Duis aute irure dolor in reprehenderit in voluptate ",
                         Convert.ToDateTime("07/05/2017"), "NORMAL"),

                new Item("610438000000_3", "MESSAGE", "610438000000", "61438111118",
                         "Check out this cute cat video", "Lorem ipsum dolor sit amet, consectetur " +
                         "adipiscing elit, sed do eiusmod tempor incididunt ut labore et " +
                         "dolore magna aliqua. Ut enim ad minim veniam, quis nostrud " +
                         "exercitation ullamco laboris nisi ut aliquip ex ea commodo " +
                         "consequat. Duis aute irure dolor in reprehenderit in voluptate ",
                         Convert.ToDateTime("10/05/2017"), "NORMAL"),

                new Item("610438000000_4", "MESSAGE", "610438000000", "61438111116",
                         "You're Late!", "Lorem ipsum dolor sit amet, consectetur " +
                         "adipiscing elit, sed do eiusmod tempor incididunt ut labore et " +
                         "dolore magna aliqua. Ut enim ad minim veniam, quis nostrud " +
                         "exercitation ullamco laboris nisi ut aliquip ex ea commodo " +
                         "consequat. Duis aute irure dolor in reprehenderit in voluptate ",
                         Convert.ToDateTime("05/05/2017"), "NORMAL")
            }
         
        }

        public void GetSentMessages(List<Item> pMessages)
        {
            throw new NotImplementedException();
        }

        public void LogSyncComplete()
        {
            throw new NotImplementedException();
        }

        public void LogSyncStarted()
        {
            throw new NotImplementedException();
        }

        public void SaveItem(Item pItem)
        {
            throw new NotImplementedException();
        }

        public void SaveRemoveFlag(RemoveFlag pFlag)
        {
            throw new NotImplementedException();
        }

    }
    */


}
