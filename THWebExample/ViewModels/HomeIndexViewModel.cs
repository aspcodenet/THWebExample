using System;
using System.Collections.Generic;

namespace THWebExample.ViewModels
{
    public class HomeIndexViewModel
    {
        public List<InterestItem> Items { get; set; }

        public class InterestItem
        {
            public DateTime Datum { get; set; }
            public decimal Value { get; set; }
        }
    }
}