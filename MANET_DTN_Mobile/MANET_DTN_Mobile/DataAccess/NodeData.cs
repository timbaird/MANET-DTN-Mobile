using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MANET_DTN_Mobile.DataAccess
{
    public static class NodeData
    {
        public static string GetNodeId()
        {
            return "61438000001";
        }

        public static int SequenceNextVal()
        {
            int current = (Int32)Application.Current.Properties["sequence"];
            Application.Current.Properties["sequence"] = current + 1;
            return current;
            //return 6;
        }

        /*
        public static string GetApiBaseUrl()
        {
            return "http://manet-dtn-mock-api.azurewebsites.net";
        }
        */

        public static List<string> GetTargetSSIDs()
        {
            List<string> retVal = new List<string> { "eduroam", "Bollocks", "AndroidWifi" };

            return retVal;
        }

        /*
         * This is only needed for testing purposes
         * where different SSID's map to different Azure API urls
         * In the production / live netwotk all throwboxes will be configured to 
         * have the same api address / althout this may be useful for DTN crossovers,
         * where each DTN operates a different SSID
         */
        public static Dictionary<string,string> GetSSIDURLMapping()
        {
            var retDict = new Dictionary<string, string>();
            retDict.Add("WiFi-C78F", "https://manet-dtn-mock-api.azurewebsites.net");
            retDict.Add("AndroidWifi", "https://manet-dtn-mock-api-2.azurewebsites.net");

            return retDict;
        }

        public static int GetMinsBetweenResync()
        {
            return 5;
        }
    }
}
