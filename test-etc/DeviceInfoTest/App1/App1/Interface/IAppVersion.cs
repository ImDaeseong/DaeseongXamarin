using System;

namespace App1.Interface
{
    public interface IAppVersion
    {
        string VersionString { get; }
        string DeviceName { get; }
        string DeviceId { get; }
        string PackageName { get; }
        string AppVersionName { get; }
        string AppVersionCode { get; }
        string FirmwareVersion { get; }
        string HardwareVersion { get; }
        string Manufacturer { get; }
        string ModelName { get; }
        string GetId { get; }
    }
}
