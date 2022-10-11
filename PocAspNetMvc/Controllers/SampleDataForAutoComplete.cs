using System.Collections.Generic;

namespace PocAspNetMvc.Controllers
{
    public static class SampleDataForAutoComplete
    {
        public static IDictionary<int, string> _items;

        public static IDictionary<int, string> InitValues()
        {
            if (_items == null)
            {
                _items = new Dictionary<int, string>
                {
                    { 1, "Docker"},
                    { 2, "Google Cloud Platform" },
                    { 3, "Amazone" },
                    { 4, "Azure" },
                    { 5, "Alibaba Cloud" },
                    { 6, "Oracle" },
                    { 7, "Vault" },
                    { 71, "VMWare" },
                    { 72, "HyperV Systems" },
                    { 73, "Pentalog" },
                    { 74, "Microsoft" },
                };
            }
            return _items;
        }
    }
}