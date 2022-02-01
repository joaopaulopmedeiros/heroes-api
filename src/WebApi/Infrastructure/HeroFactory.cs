using System.Collections.Generic;
using WebApi.Domain.Enums;
using WebApi.Domain.Models;

namespace WebApi.Infrastructure
{
    public class HeroFactory
    {
        public static List<Hero> Run()
        {
            var items = new List<Hero>();
            items.Add(new Hero { Id = 1, Name = "Superman", Power = 100, ComicsId = (int)ComicsEnum.DC });
            return items;
        }
    }
}
