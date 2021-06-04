using System.Net.Http;
using System.Threading.Tasks;

namespace DotNetCore.DependencyInjection.Interfaces
{
    public interface IMyService
    {
        HttpClient Client { get; }

        string GetResponse(string path);
    }
}