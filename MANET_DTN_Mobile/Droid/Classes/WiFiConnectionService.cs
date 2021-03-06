﻿using System;
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
using System.Collections.Generic;
using System.Threading.Tasks;

[assembly: Dependency(typeof(WiFiConnectionService))]

namespace MANET_DTN_Mobile.Droid.Classes
{
    [BroadcastReceiver]
    public class WiFiConnectionService: BroadcastReceiver, IWiFiConnectionService
    {
        static int count = 0;

        public WiFiConnectionService()
        {
            Console.WriteLine("Creating New WiFiConnectionService");
        }

        public override void OnReceive(Context context, Intent intent)
        {
            if (count % 2 == 0)
            {

                Console.WriteLine("Checking WiFi Connection " + count.ToString());
                var ssid = GetSSID();
                ssid = ssid.Replace("\"", "");
                //ssid = ssid.Replace(@"""", "");
                Console.WriteLine("Current SSID: " + ssid);

                var targetssids = NodeData.GetTargetSSIDs();

                if (targetssids.Contains(ssid))
                {
                    Console.WriteLine("Checking if Sync Required");
                    ISyncController syncer = new SyncController(ssid);

                    //if (syncer.SyncRequired().Result)
                    if (syncer.SyncRequired())
                    {
                        Console.WriteLine("Initiating Sync " + DateTime.Now.ToString());
                        new Task(() => { syncer.Sync(); Console.WriteLine("Sync Complete " + DateTime.Now.ToString()); SetAlarm(); }).Start();
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

            }
            else
            {
                SetAlarm();
            }
            
            
        }

        public static string GetSSID()
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

            var newTime = now + 999999999999;

            Console.WriteLine("Setting Alarm for Next Sync Check at : " + newTime);

            alarm.Set(AlarmType.RtcWakeup, newTime, pi);
        }
    }
}
