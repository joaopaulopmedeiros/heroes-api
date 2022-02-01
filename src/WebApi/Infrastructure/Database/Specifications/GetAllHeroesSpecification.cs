using System;
using System.Linq.Expressions;
using WebApi.Domain.Models;

namespace WebApi.Infrastructure.Database.Specifications
{
    public class GetAllHeroesSpecification
    {
        private string Name;
        private int? Power;

        public GetAllHeroesSpecification(string name, int? power)
        {
            Name = name;
            Power = power;
        }

        public Expression<Func<Hero, bool>> Criteria()
        {
            if (String.IsNullOrEmpty(Name) && Power == null) {
                return null;
            }

            if (!String.IsNullOrEmpty(Name) && Power == null) {
                return e => e.Name.Contains(Name);
            }

            if (String.IsNullOrEmpty(Name) && Power != null) {
                return e => e.Power == Power;
            }

            return e => e.Name.Contains(Name) && e.Power == Power;
        }
    }
}