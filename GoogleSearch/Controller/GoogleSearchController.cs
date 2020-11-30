using GoogleSearch.Logic;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GoogleSearch.Controller.Controller
{

    [Route("api/[controller]")]
    [ApiController]
    public class GoogleSearchController : ControllerBase
    {

        private readonly ISearchLogic _searchLogic;

        public GoogleSearchController(ISearchLogic searchLogic)
        {
            _searchLogic = searchLogic;
        }

        //http://localhost:55035/api/googlesearch/getsearchoccurences/e-settlements/www.sympli.com.au
        [HttpGet]
        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Any)]
        [Route("getSearchOccurences/{searchToken}/{url}")]
        public IActionResult GetSearchOccurences(string searchToken, string url)
        {
            var occurenceCount = 0;
            try
            {
                occurenceCount = _searchLogic.GetUrlOccurencesBySearchToken(searchToken, url);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }

            return Ok(occurenceCount);
        }
    }
}
