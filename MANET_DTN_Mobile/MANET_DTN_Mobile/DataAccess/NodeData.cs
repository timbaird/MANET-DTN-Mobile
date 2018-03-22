using System;
using Xamarin.Forms;

namespace MANET_DTN_Mobile.DataAccess
{
    public static class NodeData
    {
        public static string GetNodeId()
        {
            return "61438000000";
        }

        public static int SequenceNextVal()
        {
            int current = (Int32)Application.Current.Properties["sequence"];
            Application.Current.Properties["sequence"] = current + 1;
            return current;
            //return 6;
        }

        public static string GetApiBaseUrl()
        {
            return "http://manet-dtn-mock-api.azurewebsites.net";
        }

        public static string GetTargetSSID()
        {
            return "Bollocks";
        }

        public static int GetMinsBetweenResync()
        {
            return 5;
        }
    }
}
