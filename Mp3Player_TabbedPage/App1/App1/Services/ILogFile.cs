using System.Threading.Tasks;

namespace App1
{
    public interface ILogFile
    {
        Task WriteString(string sText);
    }

}
