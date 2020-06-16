using System.IO;
using System.Linq;

namespace Webb.Models
{
    public static class ReturnServerIP
    {
        public static string ServerIP() => File.ReadAllLines(@"C:\Users\Michal\source\repos\MyFlix\serverPath.txt").First();
    }
}
