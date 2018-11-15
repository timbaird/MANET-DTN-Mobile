using System;
using SQLite;

namespace MANET_DTN_Mobile.Models
{
    public class Item
    {
       // [PrimaryKey, Column("ItemId"), MaxLength(30)]
        public string ItemId { set; get; }
        [MaxLength(7)]
        public string ItemType { set; get; }
        [MaxLength(30)]
        public string OriginatorId{ set; get; }
        [MaxLength(30)]
        public string RecipientId{ set; get; }
        [MaxLength(100)]
        public string Title{ set; get; }
        [MaxLength(1000)]
        public string Body{ set; get; }
        public DateTime DateTimeCreated{ set; get; }
        [MaxLength(6)]
        public string Priority{ set; get; }

        public Item(){}

        public Item(string pItemId, string pItemType, string pOriginatorId, string pRecipientId,
                    string pTitle, string pBody, DateTime pDateTimeCreated, string pPriority){
            ItemId = pItemId;
            ItemType = pItemType;
            OriginatorId = pOriginatorId;
            RecipientId = pRecipientId;
            Title = pTitle;
            Body = pBody;
            DateTimeCreated = pDateTimeCreated;
            Priority = pPriority;
        }

        public string ToJson()
        {
            string serialised;

            if (ItemType == "MESSAGE")
            {
                serialised   = "{'ItemID': '" + ItemId + "'," +
                             "'ItemType': '" + ItemType + "'," +
                             "'PriorityLevel': '" + Priority + "'," +
                             "'OriginatorID': '" + OriginatorId + "'," +
                             "'RecipientID': '" + RecipientId + "'," +
                             "'TransFromID': null," +
                             "'Title': '" + Title + "'," +
                             "'Body': '" + Body + "'," +
                             "'DateTimeCreated': '" + DateTimeCreated + "'}";
            }
            else
            {
                serialised = "{'ItemID': '" + ItemId + "'," +
                             "'ItemType': '" + ItemType + "'," +
                             "'PriorityLevel': '" + Priority + "'," +
                             "'OriginatorID': '" + OriginatorId + "'," +
                             "'RecipientID': null," +
                             "'TransFromID': null," +
                             "'Title': '" + Title + "'," +
                             "'Body': '" + Body + "'," +
                             "'DateTimeCreated': '" + DateTimeCreated + "'}";
            }



 

            return serialised;
        }
    }
}
