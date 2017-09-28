using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.Services
{
    public interface IClipboard
    {
        void SetText(string text);

        [Obsolete("Use the GetTextAsync() method")]
        string GetText();

        Task<string> GetTextAsync();
    }
}
