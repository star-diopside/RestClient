using PropertyChanged;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace RestClient.Model
{
    [ImplementPropertyChanged]
    public class RestResult
    {
        public string URL { get; set; } = "http://www.google.co.jp/";
        public string Content { get; set; }

        private readonly CookieContainer cookieContainer = new CookieContainer();

        public async Task Get()
        {
            using (var client = new HttpClient(new HttpClientHandler()
            {
                UseCookies = true,
                CookieContainer = cookieContainer
            }))
            {
                Content = await client.GetStringAsync(URL);
            }
        }
    }
}
