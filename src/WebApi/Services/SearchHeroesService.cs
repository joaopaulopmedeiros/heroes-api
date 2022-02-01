using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Threading.Tasks;
using WebApi.Infrastructure.Database.Extensions;
using WebApi.Infrastructure.Database.Repositories;
using WebApi.Infrastructure.Database.Specifications;
using WebApi.Requests;
using WebApi.Responses;

namespace WebApi.Services
{
    public class SearchHeroesService
    {
        private readonly HeroRepository _repository;
        private readonly IConfigurationProvider _mappingConfig;

        public SearchHeroesService(HeroRepository repository, IConfigurationProvider mappingConfig)
        {
            _repository = repository;
            _mappingConfig = mappingConfig;
        }

        /// <summary>
        /// Get paginated heroes resource and apply filter by name/power if any informed (not null)
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<Pagination<HeroResponse>> SearchByAsync(GetAllHeroesRequest request)
        {
            return await _repository
                .FilterBySpec(new GetAllHeroesSpecification(request.Name, request.Power))
                .ProjectTo<HeroResponse>(_mappingConfig)
                .PaginateAsync(request.CurrentPage, request.PerPage);
        }
    }
}