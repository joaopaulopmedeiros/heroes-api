using WebApi.Cache;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApi.Requests;
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
        [Cache(600)]
        public async Task<IActionResult> Get
        (
            [FromQuery] GetAllHeroesRequest request,
            [FromServices] SearchHeroesService service
        )
        {
            var result = await service.SearchByAsync(request);
            return Ok(result);
        }
    }
}
