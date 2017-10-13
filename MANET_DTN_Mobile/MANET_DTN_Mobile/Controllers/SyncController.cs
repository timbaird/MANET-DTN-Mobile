using System;
namespace MANET_DTN_Mobile.Controllers
{
    public interface ISyncController{
        void InitiateSync();

    }

    public class SyncController:ISyncController
    {
        public SyncController()
        {
        }

        public void InitiateSync()
        {
            throw new NotImplementedException();
        }
    }
}
