using System;
using SQLite;

namespace MANET_DTN_Mobile.Models
{
    public class Item
    {
        [PrimaryKey, Column("ItemId"), MaxLength(30)]
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

        public Item(string pItemType, string pOriginatorId, string pRecipientId, string pTitle, string pBody, 
                    DateTime pDateTimeCreated, string pPriority){
            ItemId = null;
            ItemType = pItemType;
            OriginatorId = pOriginatorId;
            RecipientId = pRecipientId;
            Title = pTitle;
            Body = pBody;
            DateTimeCreated = pDateTimeCreated;
            Priority = pPriority;
        }

        public Item(string pItemId, string pItemType, string pOriginatorId, string pRecipientId, string pTitle, string pBody,
                    DateTime pDateTimeCreated, string pPriority){
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
            // return string.Format("[Item: ItemId={0}, ItemType={1}, OriginatorId={2}, RecipientId={3}, Title={4}, Body={5}, DateTimeCreated={6}, Priority={7}]", ItemId, ItemType, OriginatorId, RecipientId, Title, Body, DateTimeCreated, Priority);
            var serialised = string.Format("'ItemId':'{0}', 'ItemType':'{1}', 'OriginatorId':'{2}'," +
                                           " 'RecipientId':'{3}', 'Title':'{4}', 'Body':'{5}', 'DateTimeCreated':'{6}', 'Priority':'{7}'",
                                           ItemId, ItemType, OriginatorId, RecipientId, Title, Body, DateTimeCreated, Priority);


            return "{" + serialised + "}";
        }
    }
}
