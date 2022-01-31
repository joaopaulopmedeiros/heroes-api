using System.Collections.Generic;
using WebApi.Domain.Models;

namespace WebApi.Responses
{
    public class HeroCatalog
    {

        public HeroCatalog(List<Hero> data)
        {
            Data = data;
        }

        public List<Hero> Data { get; set; }
    }
}
