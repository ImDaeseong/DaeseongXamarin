using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.Services
{
    public interface INetworkConnection
    {
        bool IsConnected { get; }

        bool IsWifi { get; }

        bool IsMobileCarrier { get; }
    }
}
