using BingSearh.Logic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BingSearch.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class BingSearchController : ControllerBase
    {
        private readonly ISearchLogic _searchLogic;

        public BingSearchController(ISearchLogic searchLogic)
        {
            _searchLogic = searchLogic;
        }

        //http://localhost:55036/api/bingsearch/getsearchoccurences/e-settlements/www.sympli.com.au
        [HttpGet]
        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Any)]
        [Route("getSearchOccurences/{searchToken}/{url}")]
        public IActionResult GetSearchOccurences(string searchToken, string url)
        {
            int occurenceCount = 0;
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
