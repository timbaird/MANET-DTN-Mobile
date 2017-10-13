using System;

namespace MANET_DTN_Mobile.Models
{
    public class Item
    {
        public string ItemId { set; get; }
        public string ItemType { set; get; }
        public string OriginatorId{ set; get; }
        public string RecipientId{ set; get; }
        public string Title{ set; get; }
        public string Body{ set; get; }
        public DateTime DateTimeCreated{ set; get; }
        public string Priority{ set; get; }

        public Item(string pItemType, string pOriginatorId, string pRecipientId, string pTitle, string pBody, 
                    DateTime pDateTimeCreated, string pPrioirity){
            ItemId = null;
            ItemType = pItemType;
            OriginatorId = pOriginatorId;
            RecipientId = pRecipientId;
            Title = pTitle;
            Body = pBody;
            DateTimeCreated = pDateTimeCreated;
            Priority = Priority;
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
