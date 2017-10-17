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
                    DateTime pDateTimeCreated, string pPrioirity){
            ItemId = pItemId;
            ItemType = pItemType;
            OriginatorId = pOriginatorId;
            RecipientId = pRecipientId;
            Title = pTitle;
            Body = pBody;
            DateTimeCreated = pDateTimeCreated;
            Priority = Priority;
        }
    }
}
