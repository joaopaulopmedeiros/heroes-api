using WebApi.Requests;
using WebApi.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApi.Services;
using WebApi.Domain.Models;

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
        public async Task<PaginationResponse<HeroResponse>> Get
        (
            [FromQuery] GetAllHeroesRequest request, 
            [FromServices] SearchHeroesService service
        )
        {
            return await service.SearchByAsync(request);
        }
    }
}
