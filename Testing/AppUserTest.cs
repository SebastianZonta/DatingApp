using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Testing
{
    public class AppUserTest
    {
        private HttpClient _client;
        public AppUserTest()
        {
            _client= new HttpClient();
        }
        [Fact]
        public async Task getAll()
        {
            
        }
    }
}