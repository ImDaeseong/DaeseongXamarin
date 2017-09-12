using System.Threading.Tasks;

namespace App1.Services
{
    public interface IScanner
    {
        Task<string> ScanAsync();
    }
}
