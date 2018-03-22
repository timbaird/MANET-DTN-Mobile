using System;
using MANET_DTN_Mobile.Controllers;
using MANET_DTN_Mobile.DataAccess;
using MANET_DTN_Mobile.Models;
using MANET_DTN_Mobile.Views;
using MANET_DTN_Mobile.Droid.DataAccess;
using Android.App;
using Android.Content;
using Android.OS;
using MANET_DTN_Mobile.Droid.Classes;
using Xamarin.Forms;
using Android.Net.Wifi;


[assembly: Dependency(typeof(WiFiConnectionService))]

namespace MANET_DTN_Mobile.Droid.Classes
{
    [BroadcastReceiver]
    public class WiFiConnectionService: BroadcastReceiver, IWiFiConnectionService
    {
        static int count = 0;

        public WiFiConnectionService()
        {
            
        }

        public override void OnReceive(Context context, Intent intent)
        {
            Console.WriteLine("Checking WiFi Connection " + count.ToString());
            var ssid = GetSSID();
            Console.WriteLine("Current SSID: " + ssid);
            if (ssid == NodeData.GetTargetSSID())
            {
                Console.WriteLine("Checking if Sync Required");
                ISyncController syncer = new SyncController();
                if (syncer.SyncRequired())
                {
                    Console.WriteLine("Initiating Sync " + DateTime.Now.ToString());
                    syncer.Sync();
                    Console.WriteLine("Sync Complete " + DateTime.Now.ToString());
                }
                else
                {
                    Console.WriteLine("Sync Not Required");
                }
            }
            else
            {
                Console.WriteLine("Not connected to MANET-DTN");
            }

            SetAlarm();
        }

        public string GetSSID()
        {
            var manager = Android.App.Application.Context.GetSystemService(Context.WifiService) as WifiManager;

            return manager.ConnectionInfo.SSID;
            //return "Bollocks";
        }

        public void SetAlarm()
        {
            count++;
            Context context = Android.App.Application.Context;
            long now = SystemClock.CurrentThreadTimeMillis();

            var alarm = context.GetSystemService(Context.AlarmService) as AlarmManager;

            Intent intent = new Intent(context, this.Class);
            PendingIntent pi = PendingIntent.GetBroadcast(context, 0, intent, 0);

            //alarm.Set(AlarmType.RtcWakeup, now + ((long)(10 * 10000)), pi);

            alarm.Set(AlarmType.RtcWakeup, now + ((long)(600 * 10000)), pi);
        }
    }
}
