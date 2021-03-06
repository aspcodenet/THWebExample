using System;
using System.Collections.Generic;
using Microsoft.Extensions.Options;

namespace THWebExample.Services
{
    public class Interest
    {
        public DateTime Datum { get; set; }
        public decimal Value { get; set; }
    }

    public interface IInterestService
    {
        public List<Interest> GetRepoInterestValues();
    }

    public class SweaWebServiceConfig
    {
        public string Url { get; set; }
    }

    public class InterestService : IInterestService
    {
        private string url;
        public InterestService(IOptions<SweaWebServiceConfig> config)
        {
            url = config.Value.Url;
        }

        public List<Interest> GetRepoInterestValues()
        {
            return new List<Interest>
            {
                new Interest{ Datum = new DateTime(2020,3,21),Value=2.22m},
                new Interest{ Datum = new DateTime(2020,3,22),Value=2.24m},
                new Interest{ Datum = new DateTime(2020,3,23),Value=2.18m}
            };
        }
    }
}