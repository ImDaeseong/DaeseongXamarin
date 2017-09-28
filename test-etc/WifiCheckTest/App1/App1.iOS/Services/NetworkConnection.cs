﻿using System;
using System.Net;
using SystemConfiguration;
using CoreFoundation;
using Xamarin.Forms;
using App1.iOS.Services;
using App1.Services;

[assembly: Dependency(typeof(NetworkConnection))]
namespace App1.iOS.Services
{
    public class NetworkConnection : INetworkConnection
    {
        static NetworkReachability defaultRouteReachability;
        
        public static bool IsReachableWithoutRequiringConnection(NetworkReachabilityFlags flags)
        {
            // Is it reachable with the current network configuration?
            bool isReachable = (flags & NetworkReachabilityFlags.Reachable) != 0;

            // Do we need a connection to reach it?
            bool noConnectionRequired = (flags & NetworkReachabilityFlags.ConnectionRequired) == 0;

            // Since the network stack will automatically try to get the WAN up,
            // probe that
            if ((flags & NetworkReachabilityFlags.IsWWAN) != 0)
                noConnectionRequired = true;

            return isReachable && noConnectionRequired;
        }
        
        //
        // Raised every time there is an interesting reachable event,
        // we do not even pass the info as to what changed, and
        // we lump all three status we probe into one
        //
        public static event EventHandler ReachabilityChanged;

        static void OnChange(NetworkReachabilityFlags flags)
        {
            var h = ReachabilityChanged;
            if (h != null)
                h(null, EventArgs.Empty);
        }
        
        static bool IsNetworkAvailable(out NetworkReachabilityFlags flags)
        {
            if (defaultRouteReachability == null)
            {
                defaultRouteReachability = new NetworkReachability(new IPAddress(0));
                defaultRouteReachability.SetNotification(OnChange);
                defaultRouteReachability.Schedule(CFRunLoop.Current, CFRunLoop.ModeDefault);
            }
            return defaultRouteReachability.TryGetFlags(out flags) && IsReachableWithoutRequiringConnection(flags);
        }



        public bool IsConnected
        {
            get
            {
                NetworkReachabilityFlags flags;
                bool defaultNetworkAvailable = IsNetworkAvailable(out flags);
                if (defaultNetworkAvailable && ((flags & NetworkReachabilityFlags.IsDirect) != 0))
                {
                    return false;
                }
                else if ((flags & NetworkReachabilityFlags.IsWWAN) != 0)
                    return true;
                else if (flags == 0)
                    return false;
                return true;

            }
        }

        public bool IsWifi
        {
            get
            {
                NetworkReachabilityFlags flags;
                bool defaultNetworkAvailable = IsNetworkAvailable(out flags);
                if (defaultNetworkAvailable && ((flags & NetworkReachabilityFlags.IsDirect) != 0))
                {
                    return false;
                }
                else if ((flags & NetworkReachabilityFlags.IsWWAN) != 0)
                    return false;
                else if (flags == 0)
                    return false;
                return true;

            }
        }

        public bool IsMobileCarrier
        {
            get
            {
                NetworkReachabilityFlags flags;
                bool defaultNetworkAvailable = IsNetworkAvailable(out flags);
                if (defaultNetworkAvailable && ((flags & NetworkReachabilityFlags.IsDirect) != 0))
                {
                    return false;
                }
                else if ((flags & NetworkReachabilityFlags.IsWWAN) != 0)
                    return true;
                else if (flags == 0)
                    return false;
                return false;

            }
        }

    }

}