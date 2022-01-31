using WebApi.Requests;
using WebApi.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApi.Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HeroesController : ControllerBase
    {
        /// <summary>
        /// Get all super heroes on catalog
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<HeroCatalog> Get
        (
            [FromQuery] GetAllHeroesRequest request, 
            [FromServices] SearchHeroesService service
        )
        {
            return await service.SearchByAsync(request);
        }
    }
}
