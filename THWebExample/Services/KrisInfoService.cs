using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using THWebExample.Services;

namespace THWebExample.Services
{
    public class KrisInfo
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string Emergency { get; set; }
    }

    public interface IKrisInfoService
    {
        public List<KrisInfo> GetAllKrisInformation();
    }


    public class KrisInfoService : IKrisInfoService
    {
        private string url;
        private int nrToShow;

        public KrisInfoService(IConfiguration configuration)
        {
            url = configuration.GetValue<string>("KrisInfoConfig:Url");
            nrToShow = configuration.GetValue<int>("KrisInfoConfig:NrToShow");
        }

        public class Test
        {
            public List<KrisInfo> ThemeList { get; set; } = new List<KrisInfo>();
        }

        public List<KrisInfo> GetAllKrisInformation()
        {
            var client = new HttpClient();
            string result = client.GetStringAsync(url).Result;

            var listan = JsonConvert.DeserializeObject<Test>(result);
            return listan.ThemeList.Take(nrToShow).ToList();
        }
    }
}